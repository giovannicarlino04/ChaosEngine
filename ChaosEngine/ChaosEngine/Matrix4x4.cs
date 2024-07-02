using System;

namespace ChaosEngine.ChaosEngine
{
    public class Matrix4x4
    {
        public float[,] m = new float[4, 4];

        public static Matrix4x4 CreateTranslation(Vector3 position)
        {
            var result = Identity();
            result.m[3, 0] = position.x;
            result.m[3, 1] = position.y;
            result.m[3, 2] = position.z;
            return result;
        }

        public static Matrix4x4 CreateRotationX(float radians)
        {
            var result = Identity();
            result.m[1, 1] = (float)Math.Cos(radians);
            result.m[1, 2] = (float)Math.Sin(radians);
            result.m[2, 1] = -(float)Math.Sin(radians);
            result.m[2, 2] = (float)Math.Cos(radians);
            return result;
        }

        public static Matrix4x4 CreateRotationY(float radians)
        {
            var result = Identity();
            result.m[0, 0] = (float)Math.Cos(radians);
            result.m[0, 2] = -(float)Math.Sin(radians);
            result.m[2, 0] = (float)Math.Sin(radians);
            result.m[2, 2] = (float)Math.Cos(radians);
            return result;
        }

        public static Matrix4x4 CreateRotationZ(float radians)
        {
            var result = Identity();
            result.m[0, 0] = (float)Math.Cos(radians);
            result.m[0, 1] = (float)Math.Sin(radians);
            result.m[1, 0] = -(float)Math.Sin(radians);
            result.m[1, 1] = (float)Math.Cos(radians);
            return result;
        }

        public static Matrix4x4 CreatePerspectiveFieldOfView(float fov, float aspectRatio, float nearPlane, float farPlane)
        {
            var result = new Matrix4x4();
            float yScale = 1f / (float)Math.Tan(fov / 2f);
            float xScale = yScale / aspectRatio;
            float nearFarDiff = nearPlane - farPlane;

            result.m[0, 0] = xScale;
            result.m[1, 1] = yScale;
            result.m[2, 2] = (farPlane + nearPlane) / nearFarDiff;
            result.m[2, 3] = -1;
            result.m[3, 2] = (2 * nearPlane * farPlane) / nearFarDiff;

            return result;
        }

        public static Matrix4x4 Identity()
        {
            var result = new Matrix4x4();
            result.m[0, 0] = 1f;
            result.m[1, 1] = 1f;
            result.m[2, 2] = 1f;
            result.m[3, 3] = 1f;
            return result;
        }

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            var result = new Matrix4x4();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.m[i, j] = a.m[i, 0] * b.m[0, j] + a.m[i, 1] * b.m[1, j] + a.m[i, 2] * b.m[2, j] + a.m[i, 3] * b.m[3, j];
                }
            }

            return result;
        }
    }
}
