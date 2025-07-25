# �tvonal keres�s Dijkstra algoritmussal

Forr�s f�jlok
- nodes.csv - a csom�pontok koordin�t�i
- edges.csv - az ir�ny�tott �lek, amelyek �sszek�tik a csom�pontokat t�vols�g �rt�kekkel. Ha k�tir�ny�, akkor k�tszer szerepel a p�r a f�jlban.

## Feladat
K�t tesz�leges csom�pont k�z�tti legr�videbb �t megtal�l�sa.

## Megold�s l�p�sei
1. A csom�pontok �s �lek beolvas�sa a f�jlokb�l.
1. A gr�f kirajzol�sa a form-ra
1. A Dijkstra algoritmus alkalmaz�sa a legr�videbb �t megtal�l�s�ra.
1. Az �tvonal jel�l�se a megrajzolt gr�fon.

## A Dijkstra algoritmus bemutat�sa
A Dijkstra algoritmus egy hat�kony m�dszer a gr�fokban l�v� legr�videbb utak megtal�l�s�ra. 
A k�vetkez� l�p�sekb�l �ll:
1. Kezdj�k a forr�s csom�ponttal, �s �ll�tsuk be a t�vols�g�t 0-ra.
1. Minden m�s csom�pont t�vols�g�t �ll�tsuk be v�gtelenre.
1. Hozzunk l�tre egy �res halmazt a feldolgozott csom�pontok sz�m�ra.
1. Am�g vannak feldolgozatlan csom�pontok:
   - V�lasszuk ki a legkisebb t�vols�g� csom�pontot a feldolgozatlan halmazb�l.
   - Friss�ts�k a szomsz�dos csom�pontok t�vols�g�t, ha az �j �t r�videbb, mint a jelenlegi.
   - Adjuk hozz� a kiv�lasztott csom�pontot a feldolgozott halmazhoz.

   1. A folyamat addig folytat�dik, am�g el nem �rj�k a c�l csom�pontot vagy a feldolgozatlan halmaz �res lesz.



   ## P�lda

   A k�vetkez� p�ld�ban a csom�pontok �s �lek a `nodes.csv` �s `edges.csv` f�jlokban tal�lhat�k. A program beolvassa ezeket a f�jlokat, majd kirajzolja a gr�fot. A Dijkstra algoritmus seg�ts�g�vel megtal�lja a legr�videbb utat k�t kiv�lasztott csom�pont k�z�tt, �s megjelen�ti azt a gr�fon.

YouTube vide�: [Dijkstra algoritmus](https://www.youtube.com/watch?v=GazC3A4OQTE)
YouTube vide�: [Dijkstra algoritmus Visualized and Explained](https://www.youtube.com/watch?v=71Z-Jpnm3D4)

