using Godot;
using System;

public partial class Wallet : Node
{
    public static Wallet Instance { get; private set; }

    private double _money;
    public double Money
    {
        get => this._money;
        set
        {
            _money = value;
            EmitSignal(SignalName.MoneyUpdate, value);
        }
    }

    [Signal]
    public delegate void MoneyUpdateEventHandler(double money);

    public override void _Ready()
    {
        Instance = this;
        this.Money = 1_000;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }

    private void OnGameUpdate()
    {
        double moneyChange = 0.0;
        ulong users = UserManager.Instance.Users;
        uint adAmount = UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads);
        moneyChange += users * 0.01 * adAmount;
        moneyChange -= users * 0.01;
        
        uint serverLevel = UpgradeManager.Instance.CheckUpgrade(Upgrade.Servers);
        if (serverLevel > 0)
        {
            moneyChange -= Math.Pow(10, serverLevel - 1);
        }
        
        uint devs = UpgradeManager.Instance.CheckUpgrade(Upgrade.Developer);
        if (serverLevel > 2)
        {
            moneyChange += Math.Pow(2, devs - 3);
        }
        
        this.Money += moneyChange;
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
