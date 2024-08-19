using Godot;
using System;

public partial class UserManager : Node
{
    public static UserManager Instance { get; private set; }

    private ulong _users;
    public ulong Users {
        get => this._users;
        private set
        {
            this._users = value;
            EmitSignal(SignalName.UsersUpdate, value);
        }
    }

    [Signal]
    public delegate void UsersUpdateEventHandler(ulong users);

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        float satisfaction = SatisfactionManager.Instance.Satisfaction;
        float joinIncentive = 2.0f * (satisfaction - 0.5f);
        
        long newUsers = (long)this.CalculateVisitors() * (long)Math.Round(satisfaction);
        this.Users = (ulong)Math.Max((long)this.Users + newUsers, 0);
    }
    
    private ulong CalculateVisitors()
    {
        ulong visitors = 0;
        
        uint blogLevel = UpgradeManager.Instance.CheckUpgrade(Upgrade.Blog);
        
        if (blogLevel > 0) visitors += (ulong)Math.Pow(2, blogLevel - 1);
        
        return visitors;
    }
}
