namespace PongAvalonia.Models;

public class Paddle
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; } = 14;
    public float Height { get; set; } = 100;

    public Paddle(float x, float y)
    {
        X = x;
        Y = y;
    }

    public void Move(float delta) => Y += delta;

    public void ContainIn(float minX, float minY, float maxX, float maxY)
    {
        if (Y < minY) Y = minY;
        if (Y + Height > maxY) Y = maxY - Height;
    }
}