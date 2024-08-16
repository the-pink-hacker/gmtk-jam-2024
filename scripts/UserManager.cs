using Godot;
using System;

public partial class UserManager : Node
{
    public static UserManager Instance { get; private set; }

    public ulong Users { get; set; }

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        this.Users += 1;
    }
}
