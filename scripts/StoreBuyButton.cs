using Godot;
using System;

public partial class StoreBuyButton : MenuButton
{
    [Export]
    private Upgrade Upgrade;
    
    [Export]
    private ulong Cost;
    
    [Export]
    private double Time;
    
    [Export]
    private uint MaxUpgrades;
    
    private uint Amount;
    
    public override void _Ready()
    {
        this.SetLabel(0);
    }
    
    private void OnPressed()
    {
        if (UpgradeManager.Instance.IsCurrentlyDeveloping()) return;
        uint amount = UpgradeManager.Instance.CheckUpgrade(this.Upgrade);

        if (amount < MaxUpgrades && Wallet.Instance.TakeMoney(this.Cost))
        {
            UpgradeManager.Instance.DevelopeUpgrade(this.Upgrade, this.Time);
            this.Amount = amount + 1;

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
    
    private void OnHover()
    {
        Label preview = GetTree().GetRoot().GetNode<Label>("Main/CanvasLayer/TabContainer/Store/Preview/Label");
        string key = this.Upgrade.ToTranslationKey();
        string category = Tr(key);
        string upgrade = Tr($"{key}.{this.Amount}");
        string description = Tr($"{key}.{this.Amount}.description");
        preview.SetText($"{category}: {upgrade}\n{description}");
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
