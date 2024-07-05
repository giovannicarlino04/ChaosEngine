namespace ChaosEngine.ChaosEngine
{
    public class Shape2D
    {
        public Vector2 position = null;
        public Vector2 scale = null;
        public string tag = "";
        public Shape2D(Vector2 position, Vector2 scale, string tag)
        {
            this.position = position;
            this.scale = scale;
            this.tag = tag;

            Debug.Info($"[SHAPE2D]({tag}) - Has been registered");
            ChaosEngine.RegisterShape(this);
        }

        public void DestroySelf()
        {
            Debug.Info($"[SHAPE2D]({tag}) - Has been destroyed");
            ChaosEngine.UnregisterShape(this);
        }
    }
}
