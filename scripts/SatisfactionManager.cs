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
        float bonus = 0.0f;
        
        uint ads = UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads);
        bonus -= ads * 0.05f;
        
        uint blogLevel = UpgradeManager.Instance.CheckUpgrade(Upgrade.Blog);
        bonus += blogLevel * 0.05f;
        
        float integrity = IntegrityManager.Instance.Integrity;
        this.Satisfaction = Math.Clamp(1.0f + bonus, 0.0f, 1.0f) * integrity;
    }
}
