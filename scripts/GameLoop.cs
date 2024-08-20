using Godot;
using System;

public partial class GameLoop : Node
{
    public static GameLoop Instance { get; private set; }
    public string WebsiteName { get; private set; } = "My Website";
    public string WebsiteDomain { get; private set; } = "mywebsite.com";
    
    private Label NameLabel;
    private Label UrlLabel;

    [Signal]
    public delegate void GameUpdateEventHandler();

    public async override void _Ready()
    {
        Instance = this;
        GD.Randomize();
        
        Node root = this.GetTree().GetRoot();
        this.NameLabel = root.GetNode<Label>("Main/CanvasLayer/PanelContainer/MarginContainer/BrowserBar/WebsiteName");
        this.UrlLabel = root.GetNode<Label>("Main/CanvasLayer/PanelContainer/MarginContainer/BrowserBar/WebsiteURL");

        while (true)
        {
            await ToSignal(GetTree().CreateTimer(1.0f), SceneTreeTimer.SignalName.Timeout);
            EmitSignal(SignalName.GameUpdate);
        }
    }
    
    public void UpdateWebsiteName(string name, string domain)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(domain)) return;
        
        NameLabel.SetText(name);
        UrlLabel.SetText($"https://{domain}");
    }
}
