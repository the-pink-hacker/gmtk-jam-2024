using Godot;
using System;

public partial class UserManager : Node
{
    public static UserManager Instance { get; private set; }

    public int Users { get; set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Process(double delta)
    {
        this.Users += 1;
    }
}
