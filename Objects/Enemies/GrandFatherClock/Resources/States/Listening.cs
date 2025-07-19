using Godot;

public partial class Listening : State
{
    [ExportGroup("Refrences")]
    [Export]
    private Timer listeningTimer;
    [Export]
    private Area2D listenerArea;
    [ExportGroup("listeningTimerValues")]
    [Export]
    private float listeningTime;
    [Export]
    private float waitingTime;
    [Export]
    private float reactionDelay;

    private bool listening = false;

    public override void Enter()
    {
        listeningTimer.WaitTime = waitingTime + reactionDelay;
        listeningTimer.OneShot = false;
        listeningTimer.Autostart = true;

        listeningTimer.Start();
    }

    public override void Exit()
    {
        listeningTimer.Stop();
    }

    public override void Update(double delta)
    {
        Enemy parentAsEnemy = parent as Enemy;
        Player player = parentAsEnemy.player;

        if ((listeningTimer is null) || (player is null) || (listenerArea is null))
        {
            return;
        }

        if (!listenerArea.OverlapsBody(player))
        {
            return;
        }

        if ((listening) && (player.stateMachine.currentState.Name == "Moving"))
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Chasing");
        }
    }

    public void OnListeningTimerTimeout()
    {
        if (listening)
        {
            listeningTimer.WaitTime = listeningTime + reactionDelay;
            listening = false;
        }
        else
        {
            listeningTimer.WaitTime = waitingTime;
            listening = true;
        }
    }
}
