# Regul�ris kifejez�sek haszn�lata C# konzolos alkalmaz�sban

A regul�ris kifejez�sek (regex) hat�kony eszk�z�k sz�veges adatokban val� keres�sre �s elemz�sre. A C# nyelv a `System.Text.RegularExpressions` n�vt�r seg�ts�g�vel biztos�tja ezt a funkcionalit�st.


## Fontos regex elemek

1. **Speci�lis karakterek**:
   - `\d` - sz�mjegy (0-9)
   - `\w` - sz� karakter (a-z, A-Z, 0-9, _)
   - `\s` - whitespace karakter
   - `.` - b�rmely karakter

2. **Kvantifik�torok**:
   - `*` - 0 vagy t�bbsz�r
   - `+` - 1 vagy t�bbsz�r
   - `?` - 0 vagy 1 alkalommal
   - `{n}` - pontosan n alkalommal
   - `{n,}` - legal�bb n alkalommal
   - `{n,m}` - n �s m k�z�tt

3. **Csoportok**:
   - `()` - csoport k�pz�se
   - `(?:)` - nem r�gz�t� csoport

## Gyakori m�dszerek

1. **Egyez�s ellen�rz�se**:
   ```csharp
   bool isMatch = Regex.IsMatch(input, pattern);
   ```

2. **Egyez�s kinyer�se**:
   ```csharp
   Match match = Regex.Match(input, pattern);
   if (match.Success)
   {
       Console.WriteLine(match.Value);
   }
   ```

3. **�sszes egyez�s**:
   ```csharp
   MatchCollection matches = Regex.Matches(input, pattern);
   ```

4. **Sz�veg cser�je**:
   ```csharp
   string result = Regex.Replace(input, pattern, "REPLACEMENT");
   ```

5. **Sz�veg feloszt�sa**:
   ```csharp
   string[] parts = Regex.Split(input, pattern);
   ```

## P�lda: Email c�mek kinyer�se

```csharp
string emails = "�rj a info@example.com vagy a support@company.com c�mre!";
string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

var emailMatches = Regex.Matches(emails, emailPattern);
foreach (Match email in emailMatches)
{
    Console.WriteLine(email.Value);
}
```

## Tippek

1. Haszn�lj `@` jelet a regex minta el�tt, hogy ne kelljen escape-elni a backslash-eket
2. Fontold meg a `RegexOptions.Compiled` haszn�latot gyakran haszn�lt mint�khoz
    **Norm�l esetben (Compiled n�lk�l):**
    - A regex �rtelmezve van fut�sid�ben
    - Lassabb, de kevesebb mem�ri�t haszn�l

**RegexOptions.Compiled haszn�lat�val:**
    - A regex MSIL k�dra fordul
    - A regex el�re leford�tva ker�l v�grehajt�sra
    - Gyorsabb v�grehajt�s (ak�r 10x gyorsabb is lehet)
    - H�tr�nyok:
        - De nagyobb mem�riahaszn�latot ig�nyel
        - Hosszabb inicializ�l�si id� sz�ks�ges
    - El�ny�k:
        - Gyorsabb v�grehajt�s
        - Jobb teljes�tm�ny nagy adathalmazok eset�n
        - Kevesebb CPU terhel�s

3. Haszn�lj online regex tesztel�ket (pl. [regex101.com](https://regex101.com/)) a mint�k kipr�b�l�s�hoz
