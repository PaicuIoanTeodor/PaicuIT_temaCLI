using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace ConsoleApp3
{
    class Grid
    {
        private bool visibility;
        private const int GRID_SIZE = 50;
        private const int GRID_SPACING = 5;

        public Grid()
        {
            visibility = true;
        }

        public void Draw()
        {
            if (!visibility) return;

            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Gray);

            for (int i = -GRID_SIZE; i <= GRID_SIZE; i += GRID_SPACING)
            {
                // Linii pe direcția X
                GL.Vertex3(i, 0, -GRID_SIZE);
                GL.Vertex3(i, 0, GRID_SIZE);

                // Linii pe direcția Z
                GL.Vertex3(-GRID_SIZE, 0, i);
                GL.Vertex3(GRID_SIZE, 0, i);
            }

            GL.End();
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void Show() => visibility = true;
        public void Hide() => visibility = false;
    }
}
