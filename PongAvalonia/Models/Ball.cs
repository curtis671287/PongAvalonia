namespace PongAvalonia.Models;

public class Ball
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Vx { get; set; }
    public float Vy { get; set; }
    public float Radius { get; set; }

    public Ball(float x, float y, float vx, float vy, float radius = 9f)
    {
        X = x - radius;
        Y = y - radius;
        Vx = vx;
        Vy = vy;
        Radius = radius;
    }

    public void Update()
    {
        X += Vx;
        Y += Vy;
    }

    public bool Collides(Paddle p)
    {
        float left = X;
        float right = X + Radius * 2;
        float top = Y;
        float bottom = Y + Radius * 2;
        return !(right < p.X || left > p.X + p.Width || bottom < p.Y || top > p.Y + p.Height);
    }
}