using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_console_sample02
{
    class SimpleWindow3D : GameWindow
    {
        const float movement_speed = 0.1f; // Viteza de mișcare
        const float rotation_speed = 180.0f;

        float angleY;
        float objectX = 0.0f;
        float objectY = 0.0f;
        float objectZ = -5.0f;

        bool showCube = true;
        float lastMouseX;

        public SimpleWindow3D() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Blue);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            if (keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
                return;
            }

            if (keyboard[OpenTK.Input.Key.W])
            {
                objectY += movement_speed;
            }
            if (keyboard[OpenTK.Input.Key.S])
            {
                objectY -= movement_speed;
            }

            if (keyboard[OpenTK.Input.Key.A])
            {
                objectX -= movement_speed;
            }
            if (keyboard[OpenTK.Input.Key.D])
            {
                objectX += movement_speed;
            }

            if (keyboard[OpenTK.Input.Key.Up])
            {
                objectZ += movement_speed;
            }
            if (keyboard[OpenTK.Input.Key.Down])
            {
                objectZ -= movement_speed;
            }

            MouseState mouse = OpenTK.Input.Mouse.GetState();
            float mouseX = mouse.X;

            if (mouse[OpenTK.Input.MouseButton.Left])
            {
                float deltaX = mouseX - lastMouseX;
                angleY += deltaX * 0.1f;
            }

            lastMouseX = mouseX;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(0, 0, 10, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Translate(objectX, objectY, objectZ);
            GL.Rotate(angleY, 0.0f, 1.0f, 0.0f);

            if (showCube == true)
            {
                DrawPyramid();
            }

            SwapBuffers();
        }

        private void DrawPyramid()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.Color3(Color.Wheat);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(Color.Yellow);
            GL.Vertex3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);


            GL.Color3(Color.Red);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);

            GL.End();
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