using Godot;
using System;
using System.Collections.Generic;

public partial class UpgradeManager : Node
{
    public static UpgradeManager Instance { get; private set; }

    private Dictionary<Upgrade, uint> Upgrades = new Dictionary<Upgrade, uint>();

    public override void _Ready()
    {
        Instance = this;
    }
    
    public void GrantUpgrade(Upgrade upgrade)
    {
        uint amount = this.Upgrades.ContainsKey(upgrade) ? this.Upgrades[upgrade] + 1: 1;
        this.Upgrades[upgrade] = amount;
    }
    
    public uint CheckUpgrade(Upgrade upgrade)
    {
        return this.Upgrades.ContainsKey(upgrade) ? this.Upgrades[upgrade] : 0;
    }
}
