# Dijkstra algoritmus
A Dijkstra algoritmus egy mohó algoritmus, amely a legrövidebb utat találja meg egy gráfban egy adott forráscsúcstól az összes többi csúcshoz, feltéve, hogy az élek súlya nem negatív. A lépések sorozata a következõ:

1.  **Inicializálás:**
    * Hozzon létre egy távolság tömböt `dist`, és inicializálja az összes elemet végtelennel, kivéve a forráscsúcsot, amelynek távolsága 0 lesz (`dist[forrás] = 0`). Ez a tömb fogja tárolni az eddig ismert legrövidebb távolságot a forráscsúcstól az egyes csúcsokig.
    * Hozzon létre egy `látogatott` halmazt vagy logikai tömböt, amely nyomon követi, hogy mely csúcsokat dolgozták már fel (azaz a legrövidebb útjukat már megtalálták). Inicializálja az összes csúcsot nem látogatottnak.
    * Hozzon létre egy prioritási sort (min-halmaz), amely a `(távolság, csúcs)` párokat tárolja, és kezdetben csak a `(0, forrás)` párt tartalmazza. A prioritási sor biztosítja, hogy mindig a legközelebbi, még fel nem dolgozott csúcsot válasszuk ki.

2.  **Iteráció (amíg a prioritási sor nem üres):**
    * **Kiválasztás:** Vegye ki a prioritási sorból azt a `(távolság, csúcs)` párt, amelynek a `távolság` értéke a legkisebb. Nevezzük ezt a csúcsot `u`-nak.
    * **Látogatottság ellenõrzése:** Ha `u` már látogatott volt, folytassa a következõ iterációval (ez azt jelenti, hogy már találtunk egy rövidebb utat `u`-hoz, mielõtt ezt az elemet kivettük volna a prioritási sorból).
    * **Megjelölés látogatottnak:** Jelölje meg `u`-t látogatottnak. Ez azt jelenti, hogy a `dist[u]` érték már a végleges legrövidebb távolságot tartalmazza a forrástól `u`-ig.
    * **Szomszédok frissítése (relaxáció):**
        * Vizsgálja meg `u` összes szomszédját (`v`).
        * Minden `v` szomszédra számolja ki a távolságot a forrástól `v`-ig `u`-n keresztül: `új_távolság = dist[u] + súly(u, v)`.
        * Ha `új_távolság` kisebb, mint a jelenlegi `dist[v]`:
            * Frissítse `dist[v]`-t az `új_távolság`-ra.
            * Tegye be a `(új_távolság, v)` párt a prioritási sorba.

3.  **Befejezés:**
    * Amikor a prioritási sor üres lesz, az algoritmus befejezõdött.
    * A `dist` tömb ekkor tartalmazza a legrövidebb távolságot a forráscsúcstól minden más csúcsig.

**Összefoglalva, a Dijkstra algoritmus mûködési logikája:**

* **Mohó megközelítés:** Minden lépésben kiválasztja azt a fel nem dolgozott csúcsot, amely a legközelebb van a forráshoz (az eddig ismert legrövidebb útvonal alapján).
* **Relaxáció:** Amikor egy csúcsot feldolgoz, megpróbálja javítani a szomszédos csúcsokhoz vezetõ utak becsült hosszát. Ha talál egy rövidebb utat, frissíti a távolságot, és hozzáadja a csúcsot a prioritási sorhoz.
* **Prioritási sor:** Kritikus fontosságú az algoritmus hatékonyságához, mivel biztosítja, hogy mindig a legrövidebb ideig tartó elérési útvonallal rendelkezõ csúcsot dolgozza fel elõször.
* **Nem negatív élsúlyok:** Fontos feltétel, mivel a negatív élsúlyok esetén az algoritmus nem garantálja a helyes eredményt (ebben az esetben a Bellman-Ford algoritmusra van szükség).

Ez a lépéssorozat biztosítja, hogy az algoritmus szisztematikusan feltárja a gráfot, mindig a legígéretesebb útvonalat követve, és így garantálja a legrövidebb út megtalálását az érvényes feltételek mellett.