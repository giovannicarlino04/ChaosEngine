namespace ChaosEngine.ChaosEngine
{
    public class Camera3D
    {
        public Vector3 position { get; set; }
        public Vector3 rotation { get; set; }
        public float fieldOfView { get; set; }
        public float nearPlane { get; set; }
        public float farPlane { get; set; }

        public Camera3D(Vector3 position, Vector3 rotation, float fieldOfView, float nearPlane, float farPlane)
        {
            this.position = position;
            this.rotation = rotation;
            this.fieldOfView = fieldOfView;
            this.nearPlane = nearPlane;
            this.farPlane = farPlane;
        }

        public Matrix4x4 GetViewMatrix()
        {
            Matrix4x4 translation = Matrix4x4.CreateTranslation(-position);
            Matrix4x4 rotationX = Matrix4x4.CreateRotationX(rotation.x);
            Matrix4x4 rotationY = Matrix4x4.CreateRotationY(rotation.y);
            Matrix4x4 rotationZ = Matrix4x4.CreateRotationZ(rotation.z);

            return translation * rotationX * rotationY * rotationZ;
        }

        public Matrix4x4 GetProjectionMatrix(float aspectRatio)
        {
            return Matrix4x4.CreatePerspectiveFieldOfView(
                fieldOfView,
                aspectRatio,
                nearPlane,
                farPlane
            );
        }
    }
}
