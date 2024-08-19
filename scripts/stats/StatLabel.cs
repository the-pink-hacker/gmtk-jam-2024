using Godot;
using System;

public abstract partial class StatLabel<T> : Label
{
    protected abstract string TranslationKey { get; }
    
    public override void _Ready()
    {
        this.SubscribeToEvents();
        this.UpdateLabel(this.GetStat());
    }
    
    protected abstract void SubscribeToEvents();
    protected abstract T GetStat(); 
    
    protected void UpdateLabel(T stat)
    {
        string text = String.Format(Tr(this.TranslationKey), stat);
        this.SetText(text);
    }
    
    protected static double RoundDecimalPlaces(double stat, uint places)
    {
        double factor = Math.Pow(10, places);
        return Math.Round(stat * factor) / factor;
    }
}
