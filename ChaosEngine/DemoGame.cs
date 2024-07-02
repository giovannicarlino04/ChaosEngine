using System;
using System.Drawing;
using System.Windows.Forms;
using ChaosEngine.ChaosEngine;

namespace ChaosEngine
{
    class DemoGame : ChaosEngine.ChaosEngine
    {
        public DemoGame() : base(new Vector2(512,512), "Test") { }
        public override void OnLoad()
        { 
        }
        public override void OnDraw()
        {
        }
        public override void OnUpdate()
        {
        }
        public override void GetKeyDown(KeyEventArgs e)
        {
        }
        public override void GetKeyUp(KeyEventArgs e)
        {
        }
    }
}
