using Godot;
using System;

public partial class PopupAd : Window
{
    public void OnClose()
    {
        this.QueueFree();
    }
}
