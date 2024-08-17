using Godot;
using System;

public enum Upgrade
{
    Ads,
    Donations,
    DDoSProtection,
    Servers,
    Developer
}

public static class UpgradeMethods
{
    public static string ToTranslationKey(this Upgrade upgrade)
    {
        return upgrade switch
        {
            Upgrade.Ads => "upgrade.ads",
            Upgrade.Donations => "upgrade.donations",
            Upgrade.DDoSProtection => "upgrade.ddos",
            Upgrade.Servers => "upgrade.server",
            Upgrade.Developer => "upgrade.developer",
            _ => "null",
        };
    }
}
