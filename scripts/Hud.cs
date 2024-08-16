using Godot;
using System;
using System.Collections.Generic;

public partial class Hud : Node
{
    [Export]
    public RichTextLabel TextNode;

    public override void _Process(double delta)
    {
        long money = Wallet.Instance.Money;
        ulong users = UserManager.Instance.Users;
        float integrity = IntegrityManager.Instance.Integrity * 100.0f;
        float satisfaction = SatisfactionManager.Instance.Satisfaction * 100.0f;
        
        string text = $"Money: ${money}\nUsers: {users}\nIntegrity: {integrity}%\nSatisfaction: {satisfaction}%";
        
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
        int decimalFactor = 10;
        double roundedTime = Math.Round(time * decimalFactor) / decimalFactor;
        return $"{roundedTime} seconds";
    }
}
