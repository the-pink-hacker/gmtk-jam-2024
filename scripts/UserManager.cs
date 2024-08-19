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
        float joinIncentive = 1.0f;
        
        long newUsers = (long)Math.Round(joinIncentive * 2.0f * (satisfaction - 0.5f));
        
        this.Users = (ulong)Math.Max((long)this.Users + joinIncentive, 0);
    }
}
