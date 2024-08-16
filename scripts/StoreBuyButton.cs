using Godot;
using System;

public partial class StoreBuyButton : MenuButton
{
    [Export]
    public Upgrade Upgrade { get; private set; }
    
    [Export]
    public int Cost { get; private set; }
    
    [Export]
    public int MaxUpgrades { get; private set; }
    
    public void _on_pressed()
    {
        int amount = UpgradeManager.Instance.CheckUpgrade(this.Upgrade);

        if (amount < MaxUpgrades && Wallet.Instance.TakeMoney(this.Cost))
        {
            UpgradeManager.Instance.GrantUpgrade(this.Upgrade);

            if (amount + 1 >= MaxUpgrades)
            {
                this.SetDisabled(true);
            }
        }
    }
}
