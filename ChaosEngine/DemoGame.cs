using System;
using System.Drawing;
using ChaosEngine.ChaosEngine;

namespace ChaosEngine
{
    class DemoGame : ChaosEngine.ChaosEngine
    {
        public DemoGame() : base(new Vector2(1280,720), "DemoGame") { }
        public override void OnLoad()
        {
            backgroundColour = Color.Black;
        }
        public override void OnDraw()
        {
        }
        int frame = 0;
        public override void OnUpdate()
        {
            Console.WriteLine($"Frame Count: {frame}");
            frame++;
        }
    }
}
