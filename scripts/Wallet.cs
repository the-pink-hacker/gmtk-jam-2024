using Godot;
using System;

public partial class Wallet : Node
{
    public static Wallet Instance { get; private set; }

    [Export]
    public int Money { get; set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Process(double delta)
    {
        if (UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads))
        {
            this.Money += 1;
        }
    }
}
