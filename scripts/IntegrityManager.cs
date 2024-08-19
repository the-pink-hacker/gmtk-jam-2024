using Godot;
using System;

public partial class IntegrityManager : Node
{
    public static IntegrityManager Instance { get; private set; }

    private float _integrity = 1.0f;
    public float Integrity {
        get => this._integrity;
        set
        {
            this._integrity = value;
            EmitSignal(SignalName.IntegrityUpdate, value);
        }
    }

    [Signal]
    public delegate void IntegrityUpdateEventHandler(float integrity);

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
        float serverFactor = 1.0f - ((float)users / (float)supportedUsers);
        this.Integrity = ddosFactor * Math.Max(serverFactor, 0.0f);
    }
}
