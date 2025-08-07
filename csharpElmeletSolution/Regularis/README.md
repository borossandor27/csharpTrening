# Reguláris kifejezések használata C# konzolos alkalmazásban

A reguláris kifejezések (regex) hatékony eszközök szöveges adatokban való keresésre és elemzésre. A C# nyelv a `System.Text.RegularExpressions` névtér segítségével biztosítja ezt a funkcionalitást.


## Fontos regex elemek

1. **Speciális karakterek**:
   - `\d` - számjegy (0-9)
   - `\w` - szó karakter (a-z, A-Z, 0-9, _)
   - `\s` - whitespace karakter
   - `.` - bármely karakter

2. **Kvantifikátorok**:
   - `*` - 0 vagy többször
   - `+` - 1 vagy többször
   - `?` - 0 vagy 1 alkalommal
   - `{n}` - pontosan n alkalommal
   - `{n,}` - legalább n alkalommal
   - `{n,m}` - n és m között

3. **Csoportok**:
   - `()` - csoport képzése
   - `(?:)` - nem rögzítõ csoport

## Gyakori módszerek

1. **Egyezés ellenõrzése**:
   ```csharp
   bool isMatch = Regex.IsMatch(input, pattern);
   ```

2. **Egyezés kinyerése**:
   ```csharp
   Match match = Regex.Match(input, pattern);
   if (match.Success)
   {
       Console.WriteLine(match.Value);
   }
   ```

3. **Összes egyezés**:
   ```csharp
   MatchCollection matches = Regex.Matches(input, pattern);
   ```

4. **Szöveg cseréje**:
   ```csharp
   string result = Regex.Replace(input, pattern, "REPLACEMENT");
   ```

5. **Szöveg felosztása**:
   ```csharp
   string[] parts = Regex.Split(input, pattern);
   ```

## Példa: Email címek kinyerése

```csharp
string emails = "Írj a info@example.com vagy a support@company.com címre!";
string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

var emailMatches = Regex.Matches(emails, emailPattern);
foreach (Match email in emailMatches)
{
    Console.WriteLine(email.Value);
}
```

## Tippek

1. Használj `@` jelet a regex minta elõtt, hogy ne kelljen escape-elni a backslash-eket
2. Fontold meg a `RegexOptions.Compiled` használatot gyakran használt mintákhoz
    **Normál esetben (Compiled nélkül):**
    - A regex értelmezve van futásidõben
    - Lassabb, de kevesebb memóriát használ

**RegexOptions.Compiled használatával:**
    - A regex MSIL kódra fordul
    - A regex elõre lefordítva kerül végrehajtásra
    - Gyorsabb végrehajtás (akár 10x gyorsabb is lehet)
    - Hátrányok:
        - De nagyobb memóriahasználatot igényel
        - Hosszabb inicializálási idõ szükséges
    - Elõnyök:
        - Gyorsabb végrehajtás
        - Jobb teljesítmény nagy adathalmazok esetén
        - Kevesebb CPU terhelés

3. Használj online regex tesztelõket (pl. [regex101.com](https://regex101.com/)) a minták kipróbálásához
