using Godot;
using System;
using System.Collections.Generic;

public partial class UpgradeManager : Node
{
    public static UpgradeManager Instance { get; private set; }

    private Dictionary<Upgrade, uint> Upgrades = new Dictionary<Upgrade, uint>();
    private Upgrade CurrentlyDeveloping = (Upgrade)0;
    public double DevelopmentTime { get; private set; } = 0.0;
    public SceneTreeTimer DevelopmentTimer { get; private set; } = null;

    public override void _Ready()
    {
        Instance = this;
    }
    
    private void GrantUpgrade(Upgrade upgrade)
    {
        uint amount = this.Upgrades.ContainsKey(upgrade) ? this.Upgrades[upgrade] + 1: 1;
        this.Upgrades[upgrade] = amount;
    }
    
    public uint CheckUpgrade(Upgrade upgrade)
    {
        return this.Upgrades.ContainsKey(upgrade) ? this.Upgrades[upgrade] : 0;
    }
    
    public async void DevelopeUpgrade(Upgrade upgrade, double time)
    {
        this.CurrentlyDeveloping = upgrade;
        this.DevelopmentTime = time;
        this.DevelopmentTimer = GetTree().CreateTimer(time);
        await ToSignal(this.DevelopmentTimer, SceneTreeTimer.SignalName.Timeout);
        this.GrantUpgrade(upgrade);
        this.DevelopmentTimer = null;
    }
    
    public bool IsCurrentlyDeveloping()
    {
        return this.DevelopmentTimer is not null;
    }
}
