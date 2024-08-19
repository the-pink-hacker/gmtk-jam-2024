using Godot;
using System;

public partial class PopupAd : Window
{
    [Export]
    private Vector2I PopupSize;
    
    private const uint TEXT_VARIANTS = 6;
    
    [Export]
    public Label AdLabel { get; private set; }
    
    public override void _Ready()
    {
        Vector2I windowSize = GetTree().GetRoot().GetWindow().Size;
        this.PopupOnParent(new Rect2I(
            RandomNumber(windowSize.X - PopupSize.X),
            RandomNumber(windowSize.Y - PopupSize.Y),
            PopupSize.X,
            PopupSize.Y
        ));
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
    
    private static int RandomNumber(int restrict)
    {
        return (int)(GD.Randi() % restrict);
    }
}
