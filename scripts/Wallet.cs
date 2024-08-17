using Godot;
using System;

public partial class Wallet : Node
{
    public static Wallet Instance { get; private set; }

    [Export]
    public double Money;

    public override void _Ready()
    {
        Instance = this;
        this.Money = 100;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }

    private void OnGameUpdate()
    {
        if (UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads) >= 1)
        {
            this.Money += UserManager.Instance.Users * 0.01;
        }
    }
    
    public bool TakeMoney(double amount)
    {
        double newMoney = this.Money - amount;
        
        if (newMoney <= 0.0)
        {
            return false;
        }
        else
        {
            this.Money = newMoney;
            return true;
        }
    }
}
