namespace MonoGame.Extended
{
    public interface IRotatable
    {
        float Rotation { get; set; }

        public void  RotateDegrees(float degrees);
        public void Rotate(float radians);
    }
}
