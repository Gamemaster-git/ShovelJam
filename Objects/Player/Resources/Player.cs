using Godot;

public partial class Player : CharacterBody2D
{
    [ExportGroup("Refrences")]
    [Export]
    private RayCast2D visionRay;
    [Export]
    public StateMachine stateMachine;
    [Export]
    public CanvasLayer userInterface;
    [Export]
    public GameManager gameManager;

    public bool hasBattery = false;


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

    public void ChangeDialogueText(string dialogueBoxText)
    {
        Label dialogueBoxLabel = userInterface.GetNode<Label>("DialogueBox/Label");

        dialogueBoxLabel.Text = dialogueBoxText;
    }

    public void showUserInterface()
    {
        Tween opacityTween = CreateTween();

        opacityTween.TweenProperty(userInterface.GetNode("DialogueBox"), "modulate:a", 1, Global.UserInterfaceAnimationSpeed);
    }
    public void hideUserInterface()
    {
        Tween opacityTween = CreateTween();

        opacityTween.TweenProperty(userInterface.GetNode("DialogueBox"), "modulate:a", 0, Global.UserInterfaceAnimationSpeed);
    }
}
