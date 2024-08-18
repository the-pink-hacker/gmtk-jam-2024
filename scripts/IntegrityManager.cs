using Godot;
using System;

public partial class IntegrityManager : Node
{
    public static IntegrityManager Instance { get; private set; }

    [Export]
    public float Integrity = 1.0f;

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        float ddosFactor = EventManager.Instance.IsEventActive(Event.DDoS) ? 0.0f : 1.0f;
        ulong users = UserManager.Instance.Users;
        uint servers = UpgradeManager.Instance.CheckUpgrade(Upgrade.Servers);
        uint supportedUsers = (uint)Math.Pow(10, servers + 2);
        float serverFactor = 1.0f - (users / supportedUsers);
        this.Integrity = ddosFactor * Math.Max(serverFactor, 0.0f);
    }
}
