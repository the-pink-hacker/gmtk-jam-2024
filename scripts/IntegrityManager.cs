using Godot;
using System;

public partial class IntegrityManager : Node
{
    public static IntegrityManager Instance { get; private set; }

    [Export]
    public float Integrity = 1.0f;

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        float ddosFactor = EventManager.Instance.IsEventActive(Event.DDoS) ? 0.0f : 1.0f;
        this.Integrity = ddosFactor;
    }
}
