using System.Collections.Concurrent;
using Avalonia.Input;

namespace PongAvalonia.Services;

public class InputService : IInputService
{
    private readonly ConcurrentDictionary<Key, bool> _keys = new();

    public void SetKeyState(Key key, bool down) => _keys[key] = down;

    public bool IsKeyDown(Key key) => _keys.TryGetValue(key, out var v) && v;
}