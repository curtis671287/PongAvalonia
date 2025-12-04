using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using PongAvalonia.ViewModels;
using System;

namespace PongAvalonia.Views
{
    public partial class GameCanvas : UserControl
    {
        private readonly GameViewModel _viewModel;
        private readonly DispatcherTimer _timer;

        public GameCanvas()
        {
            InitializeComponent();
            _viewModel = new GameViewModel();

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
            _timer.Tick += (_, _) =>
            {
                // Update score text
                LeftScoreText.Text = _viewModel.LeftScore.ToString();
                RightScoreText.Text = _viewModel.RightScore.ToString();
                WinnerText.Text = _viewModel.WinnerMessage;

                // Show Play Again button if there is a winner
                PlayAgainButton.IsVisible = !string.IsNullOrEmpty(_viewModel.WinnerMessage);

                InvalidateVisual();
            };
            _timer.Start();

            Focusable = true;
            this.Focus();
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            // Draw paddles
            context.FillRectangle(Brushes.White, new Rect(_viewModel.LeftPaddleX, _viewModel.LeftPaddleY, 14, 100));
            context.FillRectangle(Brushes.White, new Rect(_viewModel.RightPaddleX, _viewModel.RightPaddleY, 14, 100));

            // Draw ball
            context.FillRectangle(Brushes.White, new Rect(_viewModel.BallX, _viewModel.BallY, _viewModel.BallRadius * 2, _viewModel.BallRadius * 2));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _viewModel.InputService.SetKeyState(e.Key, true);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            _viewModel.InputService.SetKeyState(e.Key, false);
        }

        private void PlayAgainButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _viewModel.RestartGame();
        }
    }
}



