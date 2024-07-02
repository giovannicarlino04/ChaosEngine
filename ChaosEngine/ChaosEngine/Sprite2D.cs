using System.Drawing;

namespace ChaosEngine.ChaosEngine
{
    public class Sprite2D
    {
        public Vector2 position;
        public Vector2 scale;
        public string directory;
        public string tag;
        public Bitmap sprite;

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

        // Detect collision with another Sprite2D
        public bool DetectCollision(Sprite2D other)
        {
            Rectangle thisRect = new Rectangle(
                (int)this.position.x,
                (int)this.position.y,
                (int)this.scale.x,
                (int)this.scale.y
            );

            Rectangle otherRect = new Rectangle(
                (int)other.position.x,
                (int)other.position.y,
                (int)other.scale.x,
                (int)other.scale.y
            );

            return thisRect.IntersectsWith(otherRect);
        }
    }
}
