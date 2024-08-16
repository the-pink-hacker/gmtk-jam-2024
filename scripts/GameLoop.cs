using Godot;
using System;

public partial class GameLoop : Node
{
    public static GameLoop Instance { get; private set; }

    [Signal]
    public delegate void GameUpdateEventHandler();

    public async override void _Ready()
    {
        Instance = this;

        while (true)
        {
            await ToSignal(GetTree().CreateTimer(1.0f), SceneTreeTimer.SignalName.Timeout);
            EmitSignal(SignalName.GameUpdate);
        }
    }
}
