using Godot;
using System;

public partial class UserManager : Node
{
    public static UserManager Instance { get; private set; }

    public ulong Users { get; private set; }

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        float satisfaction = SatisfactionManager.Instance.Satisfaction;
        float joinIncentive = 1.0f;
        
        long newUsers = (long)Math.Round(joinIncentive * 2.0f * (satisfaction - 0.5f));
        
        this.Users = (ulong)Math.Max((long)this.Users + joinIncentive, 0);
    }
}
