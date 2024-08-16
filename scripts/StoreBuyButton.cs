using Godot;
using System;

public partial class StoreBuyButton : MenuButton
{
    [Export]
    public Upgrade Upgrade { get; private set; }
    
    public void _on_pressed()
    {
        UpgradeManager.Instance.GrantUpgrade(this.Upgrade);
        this.SetDisabled(true);
    }
}
