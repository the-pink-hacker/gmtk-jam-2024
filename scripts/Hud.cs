using Godot;
using System;
using System.Collections.Generic;

public partial class Hud : Node
{
    [Export]
    public RichTextLabel TextNode;

    public override void _Process(double delta)
    {
        double money = Wallet.Instance.Money;
        ulong users = UserManager.Instance.Users;
        float integrity = IntegrityManager.Instance.Integrity * 100.0f;
        float satisfaction = SatisfactionManager.Instance.Satisfaction * 100.0f;
        
        string text = "";
        
        text += $"Money: ${RoundDecimalPlaces(money, 2)}";
        
        text += $"\nUsers: {users}\nIntegrity: {integrity}%\nSatisfaction: {satisfaction}%";
        
        Dictionary<Event, SceneTreeTimer> currentEvents = EventManager.Instance.CurrentEvents;
        
        if (currentEvents.Count > 0)
        {
            text += "\nCurrent Events:";
            foreach (KeyValuePair<Event, SceneTreeTimer> entry in currentEvents)
            {
                string eventName = $"{entry.Key}";
                string timeLeft = SecondsLeftToText(entry.Value.TimeLeft);
                text += $"\n    {eventName}: {timeLeft}";
            }
        }
        
        this.TextNode.SetText(text);
    }
    
    private String SecondsLeftToText(double time)
    {
        double roundedTime = RoundDecimalPlaces(time, 1);
        return $"{roundedTime} seconds";
    }
    
    private double RoundDecimalPlaces(double value, uint places)
    {
        double factor = Math.Pow(10, places);
        return Math.Round(value * factor) / factor;
    }
}
