using Godot;
using System;

public partial class StoreBuyButton : MenuButton
{
    [Export]
    public Upgrade Upgrade { get; private set; }
    
    [Export]
    public ulong Cost { get; private set; }
    
    [Export]
    public uint MaxUpgrades { get; private set; }
    
    [Export]
    public string TranslationKey { get; private set; }
    
    public override void _Ready()
    {
        this.SetLabel(0);
    }
    
    public void _on_pressed()
    {
        uint amount = UpgradeManager.Instance.CheckUpgrade(this.Upgrade);

        if (amount < MaxUpgrades && Wallet.Instance.TakeMoney(this.Cost))
        {
            UpgradeManager.Instance.GrantUpgrade(this.Upgrade);

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
        string key = $"{this.TranslationKey}.{amount}";
        this.SetText(key);
    }
    
    private void FullyUpgraded()
    {
        this.SetDisabled(true);
        string key = "upgrade.full";
        this.SetText(key);
    }
}
