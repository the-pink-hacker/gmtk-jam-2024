using Godot;
using System;

public partial class GameLoop : Node
{
    public static GameLoop Instance { get; private set; }
    public string WebsiteName { get; private set; } = "My Website";
    public string WebsiteDomain { get; private set; } = "mywebsite.com";

    [Signal]
    public delegate void GameUpdateEventHandler();

    public async override void _Ready()
    {
        Instance = this;
        GD.Randomize();

        while (true)
        {
            await ToSignal(GetTree().CreateTimer(1.0f), SceneTreeTimer.SignalName.Timeout);
            EmitSignal(SignalName.GameUpdate);
        }
    }
    
    public void UpdateWebsiteName(string name, string domain)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(domain)) return;
        
        Node root = this.GetTree().GetRoot();
        Label nameLabel = root.GetNode<Label>("Main/CanvasLayer/BrowserBar/WebsiteName");
        Label urlLabel = root.GetNode<Label>("Main/CanvasLayer/BrowserBar/WebsiteURL");
        nameLabel.SetText(name);
        urlLabel.SetText($"https://{domain}");
    }
}
