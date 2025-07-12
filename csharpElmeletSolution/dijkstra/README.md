# Útvonal keresés Dijkstra algoritmussal

Forrás fájlok
- nodes.csv - a csomópontok koordinátái
- edges.csv - az irányított élek, amelyek összekötik a csomópontokat távolság értékekkel. Ha kétirányú, akkor kétszer szerepel a pár a fájlban.

## Feladat
Két teszõleges csomópont közötti legrövidebb út megtalálása.

## Megoldás lépései
1. A csomópontok és élek beolvasása a fájlokból.
1. A gráf kirajzolása a form-ra
1. A Dijkstra algoritmus alkalmazása a legrövidebb út megtalálására.
1. Az útvonal jelölése a megrajzolt gráfon.

## A Dijkstra algoritmus bemutatása
A Dijkstra algoritmus egy hatékony módszer a gráfokban lévõ legrövidebb utak megtalálására. 
A következõ lépésekbõl áll:
1. Kezdjük a forrás csomóponttal, és állítsuk be a távolságát 0-ra.
1. Minden más csomópont távolságát állítsuk be végtelenre.
1. Hozzunk létre egy üres halmazt a feldolgozott csomópontok számára.
1. Amíg vannak feldolgozatlan csomópontok:
   - Válasszuk ki a legkisebb távolságú csomópontot a feldolgozatlan halmazból.
   - Frissítsük a szomszédos csomópontok távolságát, ha az új út rövidebb, mint a jelenlegi.
   - Adjuk hozzá a kiválasztott csomópontot a feldolgozott halmazhoz.

   1. A folyamat addig folytatódik, amíg el nem érjük a cél csomópontot vagy a feldolgozatlan halmaz üres lesz.



   ## Példa

   A következõ példában a csomópontok és élek a `nodes.csv` és `edges.csv` fájlokban találhatók. A program beolvassa ezeket a fájlokat, majd kirajzolja a gráfot. A Dijkstra algoritmus segítségével megtalálja a legrövidebb utat két kiválasztott csomópont között, és megjeleníti azt a gráfon.

YouTube videó: [Dijkstra algoritmus](https://www.youtube.com/watch?v=GazC3A4OQTE)
Youtube videó: [Dijkstra algoritmus Visualized and Explained](https://www.youtube.com/watch?v=71Z-Jpnm3D4)

