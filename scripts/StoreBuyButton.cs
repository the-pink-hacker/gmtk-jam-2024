using Godot;
using System;

public partial class StoreBuyButton : MenuButton
{
    [Export]
    public Upgrade Upgrade { get; private set; }
    
    [Export]
    public ulong Cost { get; private set; }
    
    [Export]
    public double Time { get; private set; }
    
    [Export]
    public uint MaxUpgrades { get; private set; }
    
    public override void _Ready()
    {
        this.SetLabel(0);
    }
    
    public void _on_pressed()
    {
        if (UpgradeManager.Instance.IsCurrentlyDeveloping()) return;
        uint amount = UpgradeManager.Instance.CheckUpgrade(this.Upgrade);

        if (amount < MaxUpgrades && Wallet.Instance.TakeMoney(this.Cost))
        {
            UpgradeManager.Instance.DevelopeUpgrade(this.Upgrade, this.Time);

            if (amount + 1 >= MaxUpgrades)
            {
                this.FullyUpgraded();
            }
            else
            {
                this.SetLabel(amount + 1);
            }
        }
    }
    
    private void SetLabel(uint amount)
    {
        string key = $"{this.Upgrade.ToTranslationKey()}.{amount}";
        this.SetText(key);
    }
    
    private void FullyUpgraded()
    {
        this.SetDisabled(true);
        string key = "upgrade.full";
        this.SetText(key);
    }
}
