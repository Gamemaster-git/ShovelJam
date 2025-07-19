using Godot;

public partial class Chasing : State
{
    [ExportGroup("Refrences")]
    [Export]
    private VelocityHandler velocityHandler;
    [Export]
    private Timer chaseTimer;
    [Export]
    private NavigationHandler navigationHandler;
    [ExportGroup("MovementValues")]
    [Export]
    private float speed;
    [ExportGroup("chaseTimerValues")]
    [Export]
    private float chaseIntervals;

    private bool chaseTimerOver = false;

    public override void Enter()
    {
        chaseTimer.WaitTime = chaseIntervals;
        chaseTimer.OneShot = false;
        chaseTimer.Autostart = false;

        chaseTimer.Start();
    }

    public override void Exit()
    {
        chaseTimer.Stop();
    }

    public override void PhysicsUpdate(double delta)
    {
        Enemy parentAsEnemy = parent as Enemy;
        Player player = parentAsEnemy.player;

        if ((player is null) || (velocityHandler is null) || (navigationHandler is null))
        {
            return;
        }

        Vector2 velocity = navigationHandler.GetNextPathPosition();
        velocity = parent.ToLocal(velocity).Normalized();

        if (chaseTimerOver)
        {
            EmitSignal(SignalName.Transitioned, this, (StringName)"Listening");

            velocity = new Vector2(0, 0);
        }

        velocityHandler.SetVelocityX(velocity.X * speed);
        velocityHandler.SetVelocityY(velocity.Y * speed);

        chaseTimerOver = false;
    }

    public void OnListeningTimerTimeout()
    {
        chaseTimerOver = true;
    }
}
