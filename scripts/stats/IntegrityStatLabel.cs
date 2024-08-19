using Godot;
using System;

public partial class IntegrityStatLabel : StatLabel<float>
{
    protected override string TranslationKey => "stat.integrity";
    
    protected override void SubscribeToEvents()
    {
        IntegrityManager.Instance.IntegrityUpdate += this.UpdateLabel;
    }
    
    protected override float GetStat()
    {
        return IntegrityManager.Instance.Integrity;
    }
}
