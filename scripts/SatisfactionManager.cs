using Godot;
using System;

public partial class SatisfactionManager : Node
{
    public static SatisfactionManager Instance { get; private set; }

    [Export]
    public float Satisfaction { get; set; } = 1.0f;

    public override void _Ready()
    {
        Instance = this;
    }
}
