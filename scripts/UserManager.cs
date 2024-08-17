using Godot;
using System;

public partial class UserManager : Node
{
    public static UserManager Instance { get; private set; }

    public ulong Users;

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        float satisfaction = SatisfactionManager.Instance.Satisfaction;
        long userChange = 0;
        
        if (satisfaction >= 0.80f)
        {
            userChange++;
        }
        else
        {
            userChange--;
        }
        
        this.Users = (ulong)Math.Max((long)this.Users + userChange, 0);
    }
}
