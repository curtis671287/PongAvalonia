using System;
using System.ComponentModel;
using System.Windows.Input;
using Avalonia.Threading;
using PongAvalonia.Controllers;
using PongAvalonia.Services;

namespace PongAvalonia.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private readonly GameController _controller;
        private readonly IInputService _inputService;
        private readonly DispatcherTimer _timer;
        private bool _gameOver;

        public event PropertyChangedEventHandler? PropertyChanged;

        public IInputService InputService => _inputService;

        public int LeftScore => _controller.LeftScore;
        public int RightScore => _controller.RightScore;
        public string WinnerMessage { get; private set; } = "";

        public float BallX => _controller.Ball.X;
        public float BallY => _controller.Ball.Y;
        public float BallRadius => _controller.Ball.Radius;
        public float LeftPaddleX => _controller.LeftPaddle.X;
        public float LeftPaddleY => _controller.LeftPaddle.Y;
        public float RightPaddleX => _controller.RightPaddle.X;
        public float RightPaddleY => _controller.RightPaddle.Y;

        private readonly float _windowWidth = 800f;
        private readonly float _windowHeight = 600f;

        public GameViewModel()
        {
            _inputService = new InputService();
            var ballFactory = new BallFactory();
            _controller = new GameController(ballFactory);

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
            _timer.Tick += (_, _) =>
            {
                if (_gameOver) return;

                _controller.Update(_windowWidth, _windowHeight, _inputService);

                OnPropertyChanged(nameof(LeftScore));
                OnPropertyChanged(nameof(RightScore));

                if (_controller.LeftScore >= 5)
                {
                    _gameOver = true;
                    WinnerMessage = "Left Player Wins!";
                    OnPropertyChanged(nameof(WinnerMessage));
                }
                else if (_controller.RightScore >= 5)
                {
                    _gameOver = true;
                    WinnerMessage = "Right Player Wins!";
                    OnPropertyChanged(nameof(WinnerMessage));
                }
            };
            _timer.Start();
        }

        public void RestartGame()
        {
            _controller.ResetGame(_windowWidth, _windowHeight);
            _gameOver = false;
            WinnerMessage = "";
            OnPropertyChanged(nameof(LeftScore));
            OnPropertyChanged(nameof(RightScore));
            OnPropertyChanged(nameof(WinnerMessage));
        }

        public ICommand RestartCommand => new RelayCommand(_ => RestartGame());

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

