---
tags: [MIP, csharp, winforms, entityframework, sqlite, egyetem]
tantargy: Medii și instrumente de programare
tipus: mini proiect
leadas: Blackboard, .zip
---

# Proiect 2 – Bolt-kezelő EF + SQLite, kategóriákkal és eladási előzményekkel

> [!summary] Röviden
> Ez a [[Lab5 - Magazin EF]] továbbfejlesztése. Ugyanaz a bolt-kezelő (lista, keresés, hozzáadás, eladás, `Task.Run` + `Invoke`), de:
> - **SQLite** adatbázis (egy `magazin.db` fájl) a LocalDB helyett,
> - új EF entitás: **CategorieProdus** (termékkategóriák) → a termékeknek van **kategóriája**,
> - új EF entitás: **IstoricVanzari** (eladások naplója) → az eladásoknál **látszik a kategória** is.

Kapcsolódó: [[Lab5 - Magazin EF]] · [[Proiect1 - WebBrowser]]

---

## 1. Mi volt a feladat (cerințe)

| # | Követelmény | Magyarul | Hol van megoldva |
|---|---|---|---|
| 1 | Opțiunile din lab 5 (adăugare, vânzare, cumpărare) **cu SQLite** | Minden, ami a lab 5-ben, csak SQLite-tal | egész projekt |
| 2 | AsyncTask pentru DB (ca în lab 5) | `Task.Run` + `Invoke` | minden Form |
| 3 | **CategorieProdus**: id, denumire | Új tábla a kategóriáknak | `CategorieProdus.cs`, `FormCategorii` |
| 4 | Câmpul **idCategorie** la Produs + administrare ținând cont de categorie | A terméknek legyen kategóriája, kategóriánként lehessen kezelni | `Produs.cs`, `FormAdaugare`, szűrő a fő Formon |
| 5 | **IstoricVanzari**: id, idProdus, cantitate | Eladási napló | `IstoricVanzari.cs`, `FormVanzare`, `FormIstoric` |
| 5 | La afișarea vânzărilor se afișează și **categoria** | Az eladások listájában legyen ott a kategória | `FormIstoric` (join) |

> A kódban a kommentek erre a számozásra hivatkoznak (`// cerinta 3 - ...`).

> "cumpărare" (vásárlás) = a boltba érkező áru → ez nálunk az **"Cantitate la produs existent"** (mennyiség hozzáadása).

---

## 2. Fájlok

```
Proiect2_MagazinEF/
├─ Proiect2Magazin.slnx
└─ Proiect2Magazin/
   ├─ Produs.cs               ← + IdCategorie, + Categorie (NotMapped, csak kiíráshoz)
   ├─ CategorieProdus.cs      ← Id, Denumire
   ├─ IstoricVanzari.cs       ← Id, IdProdus, Cantitate (+ DenumireProdus, IdCategorie, DataVanzare)
   ├─ MagazinDbContext.cs     ← SQLite kapcsolat, 3 DbSet, CreeazaTabele()
   ├─ Program.cs              ← Database.SetInitializer<MagazinDbContext>(null)
   ├─ Form1.cs                ← fő ablak: grid + keresés + kategória szűrő + menü
   ├─ FormAdaugare.cs         ← új termék (kategória választással) / mennyiség hozzáadás
   ├─ FormVanzare.cs          ← eladás + bejegyzés az IstoricVanzari-ba
   ├─ FormCategorii.cs        ← kategóriák: hozzáadás, átnevezés, törlés
   ├─ FormIstoric.cs          ← eladások listája kategóriával + összesítő
   ├─ App.config              ← EF + SQLite provider beállítások
   └─ packages.config         ← EntityFramework 6.4.4, System.Data.SQLite 1.0.119
```

---

## 3. A legfontosabb különbség: EF + SQLite

> [!important] Az SQLite provider **nem tud adatbázist létrehozni** Code First-tel
> A LocalDB-nél (lab 5) az EF magától megcsinálta a táblákat. SQLite-nál ezt a provider nem támogatja, ezért:
> 1. `Program.cs`: `Database.SetInitializer<MagazinDbContext>(null);` → az EF ne próbálja létrehozni / ellenőrizni az adatbázist.
> 2. `MagazinDbContext.CreeazaTabele()` → induláskor `CREATE TABLE IF NOT EXISTS ...` mindhárom táblára (`db.Database.ExecuteSqlCommand`).
> 3. Ha még nincs kategória, betesz egy **"Diverse"** nevűt, hogy rögtön lehessen terméket felvenni.

A kapcsolat:
```csharp
public MagazinDbContext()
    : base(new SQLiteConnection("Data Source=magazin.db"), true) { }
```
→ a fájl a `bin\Debug\magazin.db` lesz.

A táblaneveket kézzel adtuk meg (`[Table("Produse")]`, `[Table("Categorii")]`, `[Table("IstoricVanzari")]`), hogy biztosan egyezzenek a `CREATE TABLE`-ben lévőkkel (különben az EF angolul többes számba tenné a nevet).

Az `App.config`-ban azért van két `provider` sor is az SQLite-hoz (`System.Data.SQLite.EF6` és `System.Data.SQLite`), mert a contextnek közvetlenül egy `SQLiteConnection`-t adunk, és az EF a `System.Data.SQLite` néven keresi a providert.

---

## 4. Hogyan működik

### 4.1 Kategóriák (`FormCategorii`)
Menü **Categorii**. Bal oldalt lista, jobb oldalt: `Adauga`, `Redenumeste`, `Sterge`.
- Hozzáadásnál LINQ-val ellenőrzi, hogy nincs-e már ilyen nevű.
- **Törlés csak akkor**, ha nincs benne termék (`db.Produse.Count(p => p.IdCategorie == id)`), különben hibaüzenet.
- Minden művelet a `RuleazaOperatie(...)` segédfüggvényen megy át: `Task.Run` → művelet → `SaveChanges` → `Invoke` → lista újratöltése.
- Bezárás után a fő Form mindent újratölt (a nevek változhattak).

### 4.2 Termékek a kategóriával (fő Form)
A termék csak `IdCategorie`-t tárol, a nevet **LINQ join**-nal kapjuk meg:
```csharp
var rez = (from p in db.Produse
           join c in db.Categorii on p.IdCategorie equals c.Id
           orderby p.Id
           select new { Produs = p, NumeCategorie = c.Denumire }).ToList();
```
A nevet a `Produs.Categorie` property-be tesszük, ami `[NotMapped]` → **nem oszlop** az adatbázisban, csak a gridnek kell.

A fő Form tetején van egy **Categorie** ComboBox `(toate)` elemmel → kategóriára szűr. A szöveges keresés és a kategória szűrő **együtt** is működik (LINQ `Where` a listán).

> [!note] Betöltési sorrend
> Előbb a kategóriák töltődnek be (`IncarcaCategorii`), és **utána** a termékek (`AfiseazaCategorii` végén hívjuk az `IncarcaProduse`-t), hogy a szűrő mindig érvényes kategóriát mutasson.

### 4.3 Új termék
`FormAdaugare(List<CategorieProdus> categorii)` – a kategóriákat a fő Form adja át, egy ComboBoxból kell választani. Meglévő termék mennyiségénél (`FormAdaugare(int id)`) a kategória nem módosítható.

### 4.4 Eladás + napló
`FormVanzare` – ugyanaz, mint a lab 5-ben, plusz **ugyanabban a `SaveChanges`-ben** beír egy sort az `IstoricVanzari`-ba:
```csharp
IstoricVanzari v = new IstoricVanzari();
v.IdProdus = p.Id;
v.Cantitate = cantitate;
v.DenumireProdus = p.Denumire;
v.IdCategorie = p.IdCategorie;
v.DataVanzare = DateTime.Now;
db.Vanzari.Add(v);
```

> [!question] Miért van az IstoricVanzari-ban több mező, mint amit a feladat kér?
> A feladat: `id, idProdus, cantitate`. **De:** ha egy termék elfogy, a lab 5 szabálya szerint **törlődik**. Ha a naplóban csak az `idProdus` lenne, utána már nem tudnánk megmondani, mi volt a neve és **milyen kategóriában** volt – pedig a feladat kéri, hogy a kategória látszódjon. Ezért eltároljuk az eladás pillanatában a **nevét** és a **kategória Id-ját** is, plusz a **dátumot**. A kért 3 mező ugyanúgy megvan.

### 4.5 Eladások listája (`FormIstoric`)
Menü **Istoric vanzari**. Az eladásokat és a kategóriákat betölti, és **left join**-nal összekapcsolja (ha közben egy kategóriát töröltek, az eladás akkor is látszik, `-`-szal):
```csharp
from v in vanzari
join c in categorii on v.IdCategorie equals c.Id into cj
from c in cj.DefaultIfEmpty()
select new { ..., Categorie = c != null ? c.Denumire : "-", ... }
```
Alul **összesítő**: mennyit adtunk el összesen és **kategóriánként** (`GroupBy` + `Sum`).

---

## 5. Futtatás

1. `Proiect2Magazin.slnx` megnyitása → **Build** (a NuGet letölti a csomagokat).
2. **F5**. Első indításkor létrejön a `bin\Debug\magazin.db` a "Diverse" kategóriával.
3. Javasolt teszt sorrend:
   1. **Categorii** → adj hozzá 2-3 kategóriát (pl. Lactate, Panificatie).
   2. **Adaugare produse → Produs nou** → vegyél fel termékeket különböző kategóriákba.
   3. Fent a **Categorie** szűrővel nézd meg, hogy szűr-e.
   4. **Dupla klikk** egy terméken → adj el belőle. Adj el egyet **teljesen** is → eltűnik a listából.
   5. **Istoric vanzari** → ott van mindkét eladás, kategóriával, alul az összesítővel.
   6. Próbálj törölni egy kategóriát, amiben van termék → nem engedi.

> [!warning] Ha a NuGet referenciák hibásak (sárga felkiáltójel / "missing package")
> Tools → NuGet Package Manager → Package Manager Console:
> ```
> Update-Package -reinstall
> ```
> Ez újrarakja a csomagokat és rendbe teszi a `.csproj`-ot.
> Ha futáskor `SQLite.Interop.dll` hibát kapsz, ugyanez a megoldás (az SQLite natív DLL-jét a csomag másolja a `bin\Debug\x86|x64` mappába).

Az adatbázis tartalmát meg lehet nézni pl. a **DB Browser for SQLite** programmal (`bin\Debug\magazin.db`).

---

## 6. Kérdések, amikre jó, ha tudod a választ

> [!question]- Miért kell a `SetInitializer(null)`?
> Mert az SQLite EF provider nem tud adatbázist létrehozni / migrálni. Enélkül az EF megpróbálná, és hibát dobna.

> [!question]- Mi a `[NotMapped]`?
> Az EF ezt a property-t kihagyja az adatbázisból – nem oszlop, csak a programban használjuk (itt: a kategória neve a gridhez).

> [!question]- Mi a különbség a sima `join` és a `join ... into ... DefaultIfEmpty()` között?
> Sima join = inner join: csak ahol mindkét oldalon van egyezés. `DefaultIfEmpty` = left join: a bal oldal (eladás) mindig megmarad, ha nincs párja, `null` lesz.

> [!question]- Miért nem lehet törölni egy kategóriát, amiben van termék?
> Mert akkor a termékek `IdCategorie`-je egy nem létező kategóriára mutatna, és a fő Form join-ja kihagyná őket.

> [!question]- Mi a különbség a lab 5-höz képest a Task-oknál?
> Semmi – ugyanaz a minta: `Task.Run` (thread pool) → DB művelet → `this.Invoke(...)` → GUI frissítés az eredménnyel.
