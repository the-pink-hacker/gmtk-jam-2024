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
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }

    public void OnGameUpdate()
    {
        if (UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads))
        {
            this.Money += UserManager.Instance.Users;
        }
    }
}
