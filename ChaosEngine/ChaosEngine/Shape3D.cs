namespace ChaosEngine.ChaosEngine
{
    public class Shape3D
    {
        public Vector3 position = null;
        public Vector3 scale = null;
        public string tag = "";

        public Shape3D(Vector3 position, Vector3 scale, string tag)
        {
            this.position = position;
            this.scale = scale;
            this.tag = tag;

            Log.Info($"[SHAPE3D]({tag}) - Has been registered");
            ChaosEngine.RegisterShape(this);
        }

        public void DestroySelf()
        {
            Log.Info($"[SHAPE3D]({tag}) - Has been destroyed");
            ChaosEngine.UnregisterShape(this);
        }
    }
}
