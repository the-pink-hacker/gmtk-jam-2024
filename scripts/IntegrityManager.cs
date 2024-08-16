using Godot;
using System;

public partial class IntegrityManager : Node
{
    public static IntegrityManager Instance { get; private set; }

    [Export]
    public float Integrity { get; set; } = 1.0f;

    public override void _Ready()
    {
        Instance = this;
    }
}
