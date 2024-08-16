using Godot;
using System;

public partial class Wallet : Node
{
    public static Wallet Instance { get; private set; }

    [Export]
    public long Money { get; set; }

    public override void _Ready()
    {
        Instance = this;
        this.Money = 100;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }

    public void OnGameUpdate()
    {
        if (UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads) >= 1)
        {
            this.Money += (long)UserManager.Instance.Users;
        }
    }
    
    public bool TakeMoney(ulong amount)
    {
        long newMoney = this.Money - (long)amount;
        
        if (newMoney <= 0)
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
