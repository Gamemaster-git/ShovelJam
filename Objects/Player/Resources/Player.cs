using Godot;

public partial class Player : CharacterBody2D
{
    [ExportGroup("Refrences")]
    [Export]
    private RayCast2D visionRay;
    [Export]
    public StateMachine stateMachine;


    public override void _PhysicsProcess(double delta)
    {
        if ((visionRay is null) || (stateMachine is null))
        {
            return;
        }

        if (!visionRay.IsColliding())
        {
            return;
        }

        if (visionRay.GetCollider() is DetectionHandler)
        {
            DetectionHandler enemyDetectionHandler = visionRay.GetCollider() as DetectionHandler;

            enemyDetectionHandler.IsBeingWatched(this);
        }
    }
}
