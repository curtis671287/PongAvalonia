using System;
using PongAvalonia.Models;
using PongAvalonia.Services;

namespace PongAvalonia.Controllers;

public class GameController : IGameController
{
    public Ball Ball { get; private set; }
    public Paddle LeftPaddle { get; private set; }
    public Paddle RightPaddle { get; private set; }

    public int LeftScore { get; private set; }
    public int RightScore { get; private set; }

    private readonly IBallFactory _ballFactory;
    private readonly Random _rnd = new();

    public GameController(IBallFactory ballFactory)
    {
        _ballFactory = ballFactory;
        LeftPaddle = new Paddle(30, 250);
        RightPaddle = new Paddle(800 - 44, 250);
        Ball = _ballFactory.CreateBall(400, 300, 6f, 3f);
    }

    public void Update(float width, float height, IInputService input)
    {
        LeftPaddle.ContainIn(0,0,width,height);
        RightPaddle.ContainIn(0,0,width,height);

        if (input.IsKeyDown(Avalonia.Input.Key.W)) LeftPaddle.Move(-8f);
        if (input.IsKeyDown(Avalonia.Input.Key.S)) LeftPaddle.Move(8f);
        if (input.IsKeyDown(Avalonia.Input.Key.Up)) RightPaddle.Move(-8f);
        if (input.IsKeyDown(Avalonia.Input.Key.Down)) RightPaddle.Move(8f);

        Ball.Update();

        // bounce top/bottom
        if (Ball.Y <= 0) { Ball.Y = 0; Ball.Vy = -Ball.Vy; }
        if (Ball.Y + Ball.Radius * 2 >= height) { Ball.Y = height - Ball.Radius * 2; Ball.Vy = -Ball.Vy; }

        // collisions
        if (Ball.Collides(LeftPaddle) && Ball.Vx < 0)
        {
            Ball.Vx = -Ball.Vx * 1.06f;
            Ball.Vy += (float)(_rnd.NextDouble() - 0.5f) * 2f;
            Ball.X = LeftPaddle.X + LeftPaddle.Width + 0.1f;
        }
        if (Ball.Collides(RightPaddle) && Ball.Vx > 0)
        {
            Ball.Vx = -Ball.Vx * 1.06f;
            Ball.Vy += (float)(_rnd.NextDouble() - 0.5f) * 2f;
            Ball.X = RightPaddle.X - Ball.Radius * 2 - 0.1f;
        }

        // scoring and reset
        if (Ball.X < -100)
        {
            RightScore++;
            Ball = _ballFactory.CreateBall(width/2f, height/2f, 6f, 3f);
        }
        if (Ball.X > width + 100)
        {
            LeftScore++;
            Ball = _ballFactory.CreateBall(width/2f, height/2f, 6f, 3f);
        }
    }

    // reset everything for Play Again
    public void ResetGame(float width, float height)
    {
        LeftScore = 0;
        RightScore = 0;
        Ball = _ballFactory.CreateBall(width / 2f, height / 2f, 6f, 3f);
        LeftPaddle.Y = 250;
        RightPaddle.Y = 250;
    }
}
