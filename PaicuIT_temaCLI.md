# PaicuIT_temaCLI
 
1. Ce este un viewport?
Un viewport în OpenGL reprezintă secțiunea din fereastră unde se va desena scena 3D.

2. Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?
Frames per second (FPS) reprezintă numărul de cadre pe care OpenGL le poate genera și afișa într-o secundă. 
Un cadru (frame) este o imagine completă a scenei care este desenată în timpul unei actualizări a ferestrei de afișare.

3. Când este rulată metoda OnUpdateFrame()?
Metoda OnUpdateFrame() este rulată în fiecare ciclu de actualizare a aplicației, înainte de a randa un nou cadru.

4. Ce este modul imediat de randare?
Modul imediat de randare în OpenGL este o tehnică veche de randare în care informațiile grafice sunt specificate și desenate direct
folosind funcții precum gl.Begin() și gl.End().

5. Care este ultima versiune de OpenGL care acceptă modul imediat?
Ultima versiune de OpenGL care acceptă modul imediat de randare este OpenGL 3.3 în modul de compatibilitate.

6. Când este rulată metoda OnRenderFrame()?
Metoda OnRenderFrame() este rulată de fiecare dată când este necesar să fie randat un nou cadru.

7. De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
Metoda OnResize() trebuie executată cel puțin o dată pentru a inițializa corect dimensiunile ferestrei și viewport-ului, chiar și dacă nu există o modificare de dimensiune.

8. Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?

Metoda CreatePerspectiveFieldOfView() este utilizată pentru a seta o proiecție de perspectivă într-o scenă 3D. 
Parametrii principali sunt FOV (field of view), aspect ratio, nearPlane, farPlane.


----------------------------------------------------------------------------------------
Lab3

1.Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)?
Implicit, OpenGL consideră că o față este față (vizibilă) atunci când vertexurile sunt definite în sens anti-orar.

2. Ce este anti-aliasing? Prezentați această tehnică pe scurt.
Anti-aliasing este o tehnică de îmbunătățire a calității imaginii prin "netezirea" marginilor.
Metoda implică eșantionarea suplimentară a pixelilor și combinarea valorilor acestora pentru a crea o tranziție gradată, 
reducând discontinuitățile vizuale.

3. Care este efectul rulării comenzii GL.LineWidth(float)? Dar pentru GL.PointSize(float)? 
Funcționează în interiorul unei zone GL.Begin()?
GL.LineWidth(float) setează grosimea liniilor în unități de pixeli. Aceasta influențează grosimea liniilor desenate după această comandă.
GL.PointSize(float) setează dimensiunea punctelor (pixelilor individuali) desenate.
Da, pot functiona într-un GL.Begin().

4. Răspundeți la următoarele întrebări (utilizați ca referință eventual și
tutorii OpenGL Nate Robbins):
• Care este efectul utilizării directivei LineLoop atunci când desenate segmente de dreaptă multiple în OpenGL?

LineLoop: Desenează o secvență de linii conectate, similar cu LineStrip, dar adaugă automat o linie între ultimul vertex și primul, închizând forma.
• Care este efectul utilizării directivei LineStrip atunci când desenate segmente de dreaptă multiple în OpenGL?
LineStrip: Desenează o linie continuă care leagă fiecare vertex de cel anterior, dar fără a închide forma.

• Care este efectul utilizării directivei TriangleFan atunci când desenate segmente de dreaptă multiple în OpenGL?
TriangleFan: Când se desenează triunghiuri, TriangleFan formează un „evantai” de triunghiuri dintr-un punct central către exterior, economisind vertexuri și creând o formă circulară.

• Care este efectul utilizării directivei TriangleStrip atunci când desenate segmente de dreaptă multiple în OpenGL?
TriangleStrip: Desenează un lanț de triunghiuri care împart laturi comune, economisind vertexuri și memorie pentru desenarea eficientă a unor suprafețe continue.


6. Urmăriți aplicația „shapes.exe” din tutorii OpenGL Nate Robbins. De ce este importantă utilizarea de culori diferite (în gradient sau
culori selectate per suprafață) în desenarea obiectelor 3D? Care este avantajul?
Utilizarea culorilor diferite sau a unui gradient adaugă profunzime vizuală și realism obiectelor 3D, permițând observatorilor să distingă mai ușor forma și textura acestora.
Culoarea per față ajută, de asemenea, la înțelegerea orientării suprafețelor.

7. Ce reprezintă un gradient de culoare? Cum se obține acesta în OpenGL?
Un gradient de culoare reprezintă o tranziție graduală între două sau mai multe culori. În OpenGL, gradientul se obține prin atribuirea unor culori diferite fiecărui vertex.

8. Ce efect va apare la utilizarea canalului de transparență?
Prin utilizarea canalului de transparență (canalul alfa), obiectele pot deveni parțial transparente, permițându-se vizualizarea parțială a obiectelor din spatele lor.

10. Ce efect are utilizarea unei culori diferite pentru fiecare vertex atunci când desenați o linie sau un triunghi în modul strip?
Pentru o linie, rezultă un gradient de-a lungul liniei. 
În cazul unui strip de triunghiuri, se creează un efect de gradient pe suprafața triunghiurilor, ceea ce îmbunătățește vizual calitatea redării și poate adăuga realism obiectului.