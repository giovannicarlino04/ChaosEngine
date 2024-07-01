using System.Drawing;

namespace ChaosEngine.ChaosEngine
{
    public class Sprite2D
    {
        public Vector2 position = null;
        public Vector2 scale = null;
        public string directory = "";
        public string tag = "";
        public Bitmap sprite = null;
        public Sprite2D(Vector2 position, Vector2 scale, string directory, string tag)
        {
            this.position = position;
            this.scale = scale;
            this.directory = directory;
            this.tag = tag;

            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            Bitmap sprite = new Bitmap(tmp);
            this.sprite = sprite;
            Log.Info($"[SPRITE2D]({tag}) - Has been registered");
            ChaosEngine.RegisterSprite(this);
        }
        public void DestroySelf()
        {
            ChaosEngine.UnregisterSprite(this);
        }
    }
}
