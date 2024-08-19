using Godot;
using System;

public partial class MoneyStatLabel : StatLabel<double>
{
    protected override string TranslationKey => "stat.money";
    
    protected override void SubscribeToEvents()
    {
        Wallet.Instance.MoneyUpdate += this.UpdateLabel;
    }
    
    protected override double GetStat()
    {
        return Wallet.Instance.Money;
    }
}
