using Godot;
using System;

public partial class SatisfactionStatLabel : StatLabel<float>
{
    protected override string TranslationKey => "stat.satisfaction";
    
    protected override void SubscribeToEvents()
    {
        SatisfactionManager.Instance.SatisfactionUpdate += this.UpdateLabel;
    }
    
    protected override float GetStat()
    {
        return SatisfactionManager.Instance.Satisfaction;
    }
}
