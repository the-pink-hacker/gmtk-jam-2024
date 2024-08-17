using Godot;
using System;
using System.Collections.Generic;

public partial class EventManager : Node
{
    public static EventManager Instance { get; private set; }

    public Dictionary<Event, SceneTreeTimer> CurrentEvents = new Dictionary<Event, SceneTreeTimer>();

    public override void _Ready()
    {
        Instance = this;
        GameLoop.Instance.GameUpdate += OnGameUpdate;
    }
    
    private void OnGameUpdate()
    {
        if (RandomBool(1000)) {
            GD.Print("DDoS");
            this.CreateEvent(Event.DDoS, 10.0f);
        }
        
        uint adLevel = UpgradeManager.Instance.CheckUpgrade(Upgrade.Ads);
        
        if (adLevel > 1 && RandomBool(10))
        {
            GD.Print("Ad");
            PackedScene adScene = GD.Load<PackedScene>("res://scenes/ui/popup_ad.tscn");
            Node root = GetTree().GetRoot();
            root.AddChild(adScene.Instantiate());
        }
    }
    
    private static bool RandomBool(int chance)
    {
        return RandomNumber(chance) == 0;
    }
    
    private static int RandomNumber(int restrict)
    {
        return (int)(GD.Randi() % restrict);
    }
    
    public async void CreateEvent(Event selectedEvent, float durration)
    {
        if (this.CurrentEvents.ContainsKey(selectedEvent)) return;
        
        SceneTreeTimer timer = GetTree().CreateTimer(durration);
        this.CurrentEvents.Add(selectedEvent, timer);
        
        // Wait for timer to end
        await ToSignal(timer, SceneTreeTimer.SignalName.Timeout);
        this.CurrentEvents.Remove(selectedEvent);
    }
    
    public bool IsEventActive(Event selectedEvent)
    {
        return this.CurrentEvents.ContainsKey(selectedEvent);
    }
}
