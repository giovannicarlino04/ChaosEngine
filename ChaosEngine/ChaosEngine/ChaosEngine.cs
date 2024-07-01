using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ChaosEngine.ChaosEngine
{
    class Canvas : Form
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

        static List<Shape2D> allShapes = new List<Shape2D>();

        public Color backgroundColour = Color.Beige;
        public ChaosEngine(Vector2 screenSize, string windowTitle, Icon windowIcon = null)
        {
            if(windowIcon == null)
                windowIcon = new Icon("Assets/icon.ico");
            this.screenSize = screenSize;
            this.windowTitle = windowTitle;
            this.windowIcon = windowIcon;
            window = new Canvas();
            window.Size = new Size((int)this.screenSize.x, (int)this.screenSize.y);
            window.Text = this.windowTitle;
            window.Icon = this.windowIcon;
            window.Paint += Renderer;

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(window);
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
                    Console.WriteLine("Loading Game...");
                }
                
            }
        }
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(backgroundColour);
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

    }
}
