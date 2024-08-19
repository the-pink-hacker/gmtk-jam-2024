using Godot;
using System;

public partial class SatisfactionManager : Node
{
    public static SatisfactionManager Instance { get; private set; }

    private float _satisfaction = 1.0f;
    public float Satisfaction {
        get => this._satisfaction;
        set
        {
            this._satisfaction = value;
            EmitSignal(SignalName.SatisfactionUpdate, value);
        }
    }

    [Signal]
    public delegate void SatisfactionUpdateEventHandler(float satisfaction);

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += this.OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        float integrity = IntegrityManager.Instance.Integrity;
        float ads = UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads);
        float bonus = 0.0f;
        bonus -= ads * 0.05f;
        this.Satisfaction = Math.Clamp(1.0f + bonus, 0.0f, 1.0f) * integrity;
    }
}
