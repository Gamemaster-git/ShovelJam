using Godot;

public partial class NavigationHandler : Node
{
    [ExportGroup("Refrences")]
    [Export]
    private Enemy parent;
    [Export]
    private NavigationAgent2D navigationAgent;
    [Export]
    private Timer pathFindingIntervalTimer;
    [ExportGroup("NavigationValues")]
    [Export]
    private float pathFindingInterval;
    // To be passed on to the navigation agent.
    [Export]
    private float pathDesiredDistance;
    [Export]
    private float targetDesiredDistance;
    [Export]
    private float pathMaxDistance;


    public override void _Ready()
    {
        pathFindingIntervalTimer.WaitTime = pathFindingInterval;
        pathFindingIntervalTimer.OneShot = false;
        pathFindingIntervalTimer.Autostart = true;

        pathFindingIntervalTimer.Start();

        navigationAgent.PathDesiredDistance = pathDesiredDistance;
        navigationAgent.TargetDesiredDistance = targetDesiredDistance;
        navigationAgent.PathMaxDistance = pathMaxDistance;

        MakePath(navigationAgent, parent.player.GlobalPosition);
    }

    public void OnTimerTimeout()
    {
        MakePath(navigationAgent, parent.player.GlobalPosition);
    }

    public Vector2 GetNextPathPosition()
    {
        return navigationAgent.GetNextPathPosition();
    }

    private static void MakePath(NavigationAgent2D navigationAgent, Vector2 targetPosition)
    {
        navigationAgent.TargetPosition = targetPosition;
    }
}
