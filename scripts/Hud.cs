using Godot;
using System;

public partial class Hud : Node
{
    [Export]
    public RichTextLabel TextNode;

    public override void _Process(double delta)
    {
        int money = Wallet.Instance.Money;
        int users = UserManager.Instance.Users;
        
        this.TextNode.SetText($"Money: ${money}\nUsers: {users}");
    }
}
