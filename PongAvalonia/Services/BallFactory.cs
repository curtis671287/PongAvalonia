using PongAvalonia.Models;
using System;

namespace PongAvalonia.Services;

public class BallFactory : IBallFactory
{
    private readonly Random _rnd = new();
    public Ball CreateBall(float x, float y, float vx, float vy)
    {
        var rvx = vx * (float)(_rnd.NextDouble() * 0.4 + 0.8);
        var rvy = vy * (float)(_rnd.NextDouble() * 0.6 + 0.7) * (_rnd.Next(0,2)==0 ? 1 : -1);
        return new Ball(x, y, rvx, rvy, 9f);
    }
}