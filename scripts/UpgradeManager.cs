using Godot;
using System;
using System.Collections.Generic;

public partial class UpgradeManager : Node
{
    public static UpgradeManager Instance { get; private set; }

    private Dictionary<Upgrade, bool> Upgrades = new Dictionary<Upgrade, bool>();

    public override void _Ready()
    {
        Instance = this;
    }
    
    public void GrantUpgrade(Upgrade upgrade)
    {
        this.Upgrades.Add(upgrade, true);
    }
    
    public void RevokeUpgrade(Upgrade upgrade)
    {
        this.Upgrades.Add(upgrade, false);
    }
    
    public bool CheckUpgrade(Upgrade upgrade)
    {
        return this.Upgrades.ContainsKey(upgrade) ? this.Upgrades[upgrade] : false;
    }
}
