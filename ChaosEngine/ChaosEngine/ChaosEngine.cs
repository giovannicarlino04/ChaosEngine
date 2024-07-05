using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ChaosEngine.ChaosEngine
{
    public class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;  // Enabling this fixes the flickering
        }
    }
    public abstract class ChaosEngine
    {
        private Vector2 screenSize = new Vector2(1280, 720);
        private string windowTitle = "New Game";
        private Icon windowIcon = new Icon("Assets/icon.ico");
        private Canvas window = null;
        private Thread GameLoopThread = null;

        public static List<Shape2D> allShapes = new List<Shape2D>();

        public static List<Sprite2D> allSprites = new List<Sprite2D>();

        public Color backgroundColour = Color.Beige;
        public Vector2 cameraPosition = Vector2.Zero();
        public float cameraAngle = 0;


        public ChaosEngine(Vector2 screenSize, string windowTitle, Icon windowIcon = null)
        {
            Debug.Info("Game is starting");

            if (windowIcon == null)
                windowIcon = new Icon("Assets/icon.ico");

            this.screenSize = screenSize;
            this.windowTitle = windowTitle;
            this.windowIcon = windowIcon;

            window = new Canvas();
            window.Size = new Size((int)this.screenSize.x, (int)this.screenSize.y);
            window.Text = this.windowTitle;
            window.Icon = this.windowIcon;
            window.Paint += Renderer;
            window.KeyDown += Window_KeyDown;
            window.KeyUp += Window_KeyUp;

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(window);

        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        public static void RegisterShape(Shape2D shape)
        {
            allShapes.Add(shape);
        }
        public static void UnregisterShape(Shape2D shape)
        {
            allShapes.Remove(shape);
        }

        public static void RegisterSprite(Sprite2D sprite)
        {
            allSprites.Add(sprite);
        }
        public static void UnregisterSprite(Sprite2D sprite)
        {
            allSprites.Remove(sprite);
        }

        void GameLoop()
        {
            OnLoad();
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    Debug.Error("Window has not been found.");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(backgroundColour);

            // 2D rendering Debugic
            g.TranslateTransform(cameraPosition.x, cameraPosition.y);
            g.RotateTransform(cameraAngle);
            foreach (Shape2D shape in allShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.position.x, shape.position.y, shape.scale.x, shape.scale.y);
            }
            foreach (Sprite2D sprite in allSprites)
            {
                g.DrawImage(sprite.sprite, sprite.position.x, sprite.position.y, sprite.scale.x, sprite.scale.y);
            }
        }

        /// <summary>
        /// Called at the start of the game
        /// </summary>
        public abstract void OnLoad();
        /// <summary>
        /// Called after every frame, useful for movement/physics stuff
        /// </summary>
        public abstract void OnUpdate();
        /// <summary>
        /// Called before every frame, useful for drawing stuff
        /// </summary>
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }
}