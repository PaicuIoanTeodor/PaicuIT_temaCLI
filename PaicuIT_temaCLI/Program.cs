using System;
using System.Drawing;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_console_sample02
{
    class SimpleWindow3D : GameWindow
    {
        const float movement_speed = 0.1f;
        const float rotation_speed = 0.1f;
        const float initialTransparency = 1.0f;
        float transparency = initialTransparency;
        private bool isVisible = true;

        float angleY;
        float angleX;
        float objectX = 0.0f;
        float objectY = 0.0f;
        float objectZ = -30.0f;

        //stocare culori
        private (int R, int G, int B)[] vertexColors;
        private (int R, int G, int B)[] initialVertexColors;

        static bool isRPressed = false;
        static bool isGPressed = false;
        static bool isBPressed = false;
        static bool isTPressed = false;
        static bool isQPressed = false;

        float lastMouseX;
        float lastMouseY;

        private Vector3[] triangleVertices;
        private Random random;

        public SimpleWindow3D() : base(800, 600)
        {
            VSync = VSyncMode.On;
            random = new Random();
            vertexColors = new (int, int, int)[3]; //stocare culori
            initialVertexColors = new (int, int, int)[3];
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Blue);
            LoadTriangleVertices("triangle.txt");

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            InitializeVertexColors();

            Console.WriteLine("Comenzi:");
            Console.WriteLine("R - Modifica random valoarea culorii rosu pentru fiecare vertex");
            Console.WriteLine("G - Modifica random valoarea culorii verde pentru fiecare vertex");
            Console.WriteLine("B - Modifica random valoarea culorii albastru pentru fiecare vertex");
            Console.WriteLine("T - Modifica vizibilitatea triunghiului");
            Console.WriteLine("Q - Reseteaza culoarea si transparenta");
            Console.WriteLine("W - Muta obiectul in sus");
            Console.WriteLine("S - Muta obiectul in jos");
            Console.WriteLine("A - Muta obiectul in stanga");
            Console.WriteLine("D - Muta obiectul in dreapta");
            Console.WriteLine("Mouse pentru miscarea camerei");
            Console.WriteLine("ESC - Iesire din aplicasie");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 100);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        private void InitializeVertexColors()
        {
            //initializare vertex-uri
            for (int i = 0; i < vertexColors.Length; i++)
            {
                vertexColors[i] = (255, 0, 0); 
                initialVertexColors[i] = vertexColors[i]; //salvare culoare initiala
            }
            DisplayVertexColors();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard[Key.Escape])
            {
                Exit();
                return;
            }

            // modificarea culoare pentru fiecare vertex
            if (keyboard[Key.R] && !isRPressed)
            {
                for (int i = 0; i < vertexColors.Length; i++)
                {
                    vertexColors[i].R = random.Next(0, 256);
                }
                isRPressed = true;
                DisplayVertexColors();
            }
            else if (!keyboard[Key.R])
            {
                isRPressed = false;
            }

            if (keyboard[Key.G] && !isGPressed)
            {
                for (int i = 0; i < vertexColors.Length; i++)
                {
                    vertexColors[i].G = random.Next(0, 256);
                }
                isGPressed = true;
                DisplayVertexColors();
            }
            else if (!keyboard[Key.G])
            {
                isGPressed = false;
            }

            if (keyboard[Key.B] && !isBPressed)
            {
                for (int i = 0; i < vertexColors.Length; i++)
                {
                    vertexColors[i].B = random.Next(0, 256);
                }
                isBPressed = true;
                DisplayVertexColors();
            }
            else if (!keyboard[Key.B])
            {
                isBPressed = false;
            }

            // transparenta
            if (keyboard[Key.T] && !isTPressed)
            {
                transparency = transparency == 1.0f ? 0.5f : 1.0f;
                isTPressed = true;
            }
            else if (!keyboard[Key.T])
            {
                isTPressed = false;
            }

            // buton de reset
            if (keyboard[Key.Q] && !isQPressed)
            {
                for (int i = 0; i < vertexColors.Length; i++)
                {
                    vertexColors[i] = initialVertexColors[i];
                }
                transparency = initialTransparency;
                isQPressed = true;
                DisplayVertexColors();
            }
            else if (!keyboard[Key.Q])
            {
                isQPressed = false;
            }

          //pentru miscarea mouse-ului
            MouseState mouse = Mouse.GetState();
            float mouseX = mouse.X;
            float mouseY = mouse.Y;

            if (mouse[MouseButton.Left])
            {
                float deltaX = mouseX - lastMouseX;
                float deltaY = mouseY - lastMouseY;

                angleY += deltaX * rotation_speed;
                angleX += deltaY * rotation_speed;
                angleX = MathHelper.Clamp(angleX, -89.0f, 89.0f);
            }

            lastMouseX = mouseX;
            lastMouseY = mouseY;

            if (keyboard[Key.W]) objectY += movement_speed;
            if (keyboard[Key.S]) objectY -= movement_speed;
            if (keyboard[Key.A]) objectX -= movement_speed;
            if (keyboard[Key.D]) objectX += movement_speed;
            if (keyboard[Key.Up]) objectZ += movement_speed;   //fata
            if (keyboard[Key.Down]) objectZ -= movement_speed; //spate
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(angleY, 0.0f, 1.0f, 0.0f);
            GL.Translate(objectX, objectY, objectZ);

            DrawTriangle();

            SwapBuffers();
        }

        private void DrawTriangle()
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < triangleVertices.Length; i++)
            {
                var color = vertexColors[i];
                GL.Color4(color.R / 255f, color.G / 255f, color.B / 255f, transparency);
                GL.Vertex3(triangleVertices[i]);
            }
            GL.End();
        }

        private void DisplayVertexColors()
        {
            for (int i = 0; i < vertexColors.Length; i++)
            {
                var color = vertexColors[i];
                Console.WriteLine($"Vertex {i + 1} - R: {color.R}, G: {color.G}, B: {color.B}");
            }
        }

        private void LoadTriangleVertices(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            triangleVertices = new Vector3[3];

            for (int i = 0; i < 3; i++)
            {
                string[] parts = lines[i].Split(',');
                triangleVertices[i] = new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow3D example = new SimpleWindow3D())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
