using PongAvalonia.Models;

namespace PongAvalonia.Services;

public interface IBallFactory
{
    Ball CreateBall(float x, float y, float vx, float vy);
}