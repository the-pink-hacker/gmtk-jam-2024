using Godot;
using System;

public partial class UsersStatLabel : StatLabel<ulong>
{
    protected override string TranslationKey => "stat.users";
    
    protected override void SubscribeToEvents()
    {
        UserManager.Instance.UsersUpdate += this.UpdateLabel;
    }
    
    protected override ulong GetStat()
    {
        return UserManager.Instance.Users;
    }
}
