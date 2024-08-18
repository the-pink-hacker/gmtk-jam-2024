using Godot;
using System;

public partial class PopupAd : Window
{
    private const uint TEXT_VARIANTS = 6;
    
    [Export]
    public Label AdLabel { get; private set; }
    
    public override void _Ready()
    {
        uint variant = RandomNumber(TEXT_VARIANTS - 1);
        string translationKey = $"ad.popup.{variant}";
        this.AdLabel.SetText(translationKey);
    }
    
    private void OnClose()
    {
        this.QueueFree();
    }
    
    private static uint RandomNumber(uint restrict)
    {
        return (uint)(GD.Randi() % restrict);
    }
}
