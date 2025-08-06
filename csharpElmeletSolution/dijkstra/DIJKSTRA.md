# Dijkstra algoritmus
A Dijkstra algoritmus egy moh� algoritmus, amely a legr�videbb utat tal�lja meg egy gr�fban egy adott forr�scs�cst�l az �sszes t�bbi cs�cshoz, felt�ve, hogy az �lek s�lya nem negat�v. A l�p�sek sorozata a k�vetkez�:

1.  **Inicializ�l�s:**
    * Hozzon l�tre egy t�vols�g t�mb�t `dist`, �s inicializ�lja az �sszes elemet v�gtelennel, kiv�ve a forr�scs�csot, amelynek t�vols�ga 0 lesz (`dist[forr�s] = 0`). Ez a t�mb fogja t�rolni az eddig ismert legr�videbb t�vols�got a forr�scs�cst�l az egyes cs�csokig.
    * Hozzon l�tre egy `l�togatott` halmazt vagy logikai t�mb�t, amely nyomon k�veti, hogy mely cs�csokat dolgozt�k m�r fel (azaz a legr�videbb �tjukat m�r megtal�lt�k). Inicializ�lja az �sszes cs�csot nem l�togatottnak.
    * Hozzon l�tre egy priorit�si sort (min-halmaz), amely a `(t�vols�g, cs�cs)` p�rokat t�rolja, �s kezdetben csak a `(0, forr�s)` p�rt tartalmazza. A priorit�si sor biztos�tja, hogy mindig a legk�zelebbi, m�g fel nem dolgozott cs�csot v�lasszuk ki.

2.  **Iter�ci� (am�g a priorit�si sor nem �res):**
    * **Kiv�laszt�s:** Vegye ki a priorit�si sorb�l azt a `(t�vols�g, cs�cs)` p�rt, amelynek a `t�vols�g` �rt�ke a legkisebb. Nevezz�k ezt a cs�csot `u`-nak.
    * **L�togatotts�g ellen�rz�se:** Ha `u` m�r l�togatott volt, folytassa a k�vetkez� iter�ci�val (ez azt jelenti, hogy m�r tal�ltunk egy r�videbb utat `u`-hoz, miel�tt ezt az elemet kivett�k volna a priorit�si sorb�l).
    * **Megjel�l�s l�togatottnak:** Jel�lje meg `u`-t l�togatottnak. Ez azt jelenti, hogy a `dist[u]` �rt�k m�r a v�gleges legr�videbb t�vols�got tartalmazza a forr�st�l `u`-ig.
    * **Szomsz�dok friss�t�se (relax�ci�):**
        * Vizsg�lja meg `u` �sszes szomsz�dj�t (`v`).
        * Minden `v` szomsz�dra sz�molja ki a t�vols�got a forr�st�l `v`-ig `u`-n kereszt�l: `�j_t�vols�g = dist[u] + s�ly(u, v)`.
        * Ha `�j_t�vols�g` kisebb, mint a jelenlegi `dist[v]`:
            * Friss�tse `dist[v]`-t az `�j_t�vols�g`-ra.
            * Tegye be a `(�j_t�vols�g, v)` p�rt a priorit�si sorba.

3.  **Befejez�s:**
    * Amikor a priorit�si sor �res lesz, az algoritmus befejez�d�tt.
    * A `dist` t�mb ekkor tartalmazza a legr�videbb t�vols�got a forr�scs�cst�l minden m�s cs�csig.

**�sszefoglalva, a Dijkstra algoritmus m�k�d�si logik�ja:**

* **Moh� megk�zel�t�s:** Minden l�p�sben kiv�lasztja azt a fel nem dolgozott cs�csot, amely a legk�zelebb van a forr�shoz (az eddig ismert legr�videbb �tvonal alapj�n).
* **Relax�ci�:** Amikor egy cs�csot feldolgoz, megpr�b�lja jav�tani a szomsz�dos cs�csokhoz vezet� utak becs�lt hossz�t. Ha tal�l egy r�videbb utat, friss�ti a t�vols�got, �s hozz�adja a cs�csot a priorit�si sorhoz.
* **Priorit�si sor:** Kritikus fontoss�g� az algoritmus hat�konys�g�hoz, mivel biztos�tja, hogy mindig a legr�videbb ideig tart� el�r�si �tvonallal rendelkez� cs�csot dolgozza fel el�sz�r.
* **Nem negat�v �ls�lyok:** Fontos felt�tel, mivel a negat�v �ls�lyok eset�n az algoritmus nem garant�lja a helyes eredm�nyt (ebben az esetben a Bellman-Ford algoritmusra van sz�ks�g).

Ez a l�p�ssorozat biztos�tja, hogy az algoritmus szisztematikusan felt�rja a gr�fot, mindig a leg�g�retesebb �tvonalat k�vetve, �s �gy garant�lja a legr�videbb �t megtal�l�s�t az �rv�nyes felt�telek mellett.