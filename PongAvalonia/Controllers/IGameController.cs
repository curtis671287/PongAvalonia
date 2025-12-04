using PongAvalonia.Models;
using PongAvalonia.Services;

namespace PongAvalonia.Controllers;

public interface IGameController
{
    Ball Ball { get; }
    Paddle LeftPaddle { get; }
    Paddle RightPaddle { get; }

    int LeftScore { get; }
    int RightScore { get; }

    void Update(float width, float height, IInputService input);
}