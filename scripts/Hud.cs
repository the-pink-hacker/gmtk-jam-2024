using Godot;
using System;

public partial class Hud : Node
{
    [Export]
    public RichTextLabel TextNode;

    public override void _Ready()
    {
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }

    public void OnGameUpdate()
    {
        int money = Wallet.Instance.Money;
        int users = UserManager.Instance.Users;
        
        this.TextNode.SetText($"Money: ${money}\nUsers: {users}");
    }
}
