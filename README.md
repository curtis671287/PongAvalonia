Pong Avalonia
Overview

Pong Avalonia is a modern version of the classic Pong game, built using C# and Avalonia UI. The game allows two players to compete in real-time, keeping track of scores, declaring a winner, and providing a restart feature for continuous play.

Features

Two-player gameplay:

Left Paddle: W / S keys

Right Paddle: Up / Down keys

Automatic scoring system

Winner detection: first player to reach 5 points wins

“Play Again” button to restart the game instantly

Smooth ball physics with bouncing and speed increase after paddle hits

Designed to run on Mac and Windows with Avalonia UI

Project Structure
PongAvalonia/
├─ Controllers/         # Game logic and controller
├─ Models/              # Ball and Paddle models
├─ Services/            # Input, BallFactory, and RelayCommand
├─ ViewModels/          # GameViewModel for state management
├─ Views/               # GameCanvas (UI)
├─ App.axaml            # Application styles and setup
├─ MainWindow.axaml     # Main application window
├─ Program.cs           # Entry point

How to Play

Run the application.

Control the left paddle with W (up) and S (down).

Control the right paddle with Up Arrow (up) and Down Arrow (down).

Scores automatically update when a player misses the ball.

The first player to reach 5 points wins.

Click Play Again to restart the game.

Installation / Running

Clone the repository:

git clone <your-repo-url>


Open the project in JetBrains Rider (or Visual Studio if preferred).

Ensure the project targets .NET 9.0.

Restore NuGet packages (Avalonia, Avalonia.Desktop).

Build and run the project.

Technical Notes

Game loop handled with DispatcherTimer (~60 FPS).

Scoreboard and winner message updated manually in the view for performance and stability.

Keyboard input captured via InputService for smooth paddle movement.

Ball physics managed with BallFactory to introduce slight randomization on speed and angle after paddle collisions.
