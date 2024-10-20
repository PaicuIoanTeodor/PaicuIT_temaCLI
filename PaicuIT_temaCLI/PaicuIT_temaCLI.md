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