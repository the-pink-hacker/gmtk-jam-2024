using Godot;
using System;
using System.Collections.Generic;

public partial class UpgradeManager : Node
{
    public static UpgradeManager Instance { get; private set; }

    private Dictionary<Upgrade, int> Upgrades = new Dictionary<Upgrade, int>();

    public override void _Ready()
    {
        Instance = this;
    }
    
    public void GrantUpgrade(Upgrade upgrade)
    {
        int amount = this.Upgrades.ContainsKey(upgrade) ? this.Upgrades[upgrade] + 1: 1;
        this.Upgrades[upgrade] = amount;
    }
    
    public int CheckUpgrade(Upgrade upgrade)
    {
        return this.Upgrades.ContainsKey(upgrade) ? this.Upgrades[upgrade] : 0;
    }
}
