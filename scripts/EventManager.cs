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
    
    public void OnGameUpdate()
    {
        int randomNumber = RandomNumber(10);
        
        if (randomNumber == 0) {
            GD.Print("DDoS");
            this.CreateEvent(Event.DDoS, 10.0f);
        }
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
}
