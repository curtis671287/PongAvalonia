using Avalonia.Input;

namespace PongAvalonia.Services;

public interface IInputService
{
    void SetKeyState(Key key, bool down);
    bool IsKeyDown(Key key);
}