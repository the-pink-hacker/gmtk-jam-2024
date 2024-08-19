using Godot;
using System;

public partial class UpgradeProgress : ProgressBar
{
    public override void _Process(double delta)
    {
        this.SetValueNoSignal(this.GetProgress());
    }
    
    private float GetProgress()
    {
        double totalTime = UpgradeManager.Instance.DevelopmentTime;
        SceneTreeTimer timer = UpgradeManager.Instance.DevelopmentTimer;
        
        if (timer is null) return 0.0f;
        
        double timeLeft = timer.GetTimeLeft();
        double progress = (1.0 - timeLeft / totalTime) * 100.0;
        return (float)progress;
    }
}
