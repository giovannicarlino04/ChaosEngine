using System;
using System.Drawing;
using System.Windows.Forms;
using ChaosEngine.ChaosEngine;

namespace ChaosEngine
{
    class DemoGame : ChaosEngine.ChaosEngine
    {
        bool left;
        bool right;
        bool up;
        bool down;

        string[,] Map =
        {
            {".",".",".",".",".",".","."},
            {".",".",".",".",".",".","."},
            {".",".",".",".",".",".","."},
            {".",".",".",".",".","g","."},
            {"g","g","g","g","g","g","g"},
            {".",".",".",".",".",".","."},
        };
        public DemoGame() : base(new Vector2(615,615), "DemoGame") { }
        public override void OnLoad()
        {
            cameraPosition.x = 100;
            backgroundColour = Color.Black;
            for(int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j,i] == "g")
                        new Sprite2D(new Vector2(i * 50,j * 50), new Vector2(50, 50), "ground", "Ground");
                }
            }
        }
        public override void OnDraw()
        {
        }
        public override void OnUpdate()
        {
            if (up)
            {
                cameraPosition.y--;
            }
            if (down)
            {
                cameraPosition.y++;
            }
            if (left)
            {
                cameraPosition.x--;

            }
            if (right)
            {
                cameraPosition.x++;

            }
        }
        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                up = true; 
            if (e.KeyCode == Keys.S)
                down = true; 
            if (e.KeyCode == Keys.A)
                left = true; 
            if (e.KeyCode == Keys.D)
                right = true;
        }
        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                up = false;
            if (e.KeyCode == Keys.S)
                down = false;
            if (e.KeyCode == Keys.A)
                left = false;
            if (e.KeyCode == Keys.D)
                right = false;
        }
    }
}
