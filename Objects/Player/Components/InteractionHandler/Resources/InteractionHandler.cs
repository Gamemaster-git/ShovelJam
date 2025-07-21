using Godot;

public partial class InteractionHandler : Node2D
{
    [ExportGroup("Refrences")]
    [Export]
    private CollisionShape2D interactionAreaCollisionBox;
    [Export]
    private Area2D interactionArea;
    [Export]
    private Player player;
    [ExportGroup("InteractionAreaValues")]
    [Export]
    private float interactionAreaRadius;

    private Interactable currentInteractable;


    public override void _Ready()
    {
        interactionAreaCollisionBox.Shape.Set((StringName)"radius", interactionAreaRadius);
    }

    public override void _Input(InputEvent @event)
    {
        if (currentInteractable is null)
        {
            player.hideUserInterface();
            player.ChangeDialogueText("");

            return;
        }

        if (@event.IsActionPressed("Interact"))
        {
            player.showUserInterface();
            currentInteractable.Interaction();
            player.ChangeDialogueText(currentInteractable.Text);
        }
    }

    public void OnInteractionAreaAreaEntered(Area2D area)
    {
        Interactable areaAsInteractable = area as Interactable;

        if (areaAsInteractable is null)
        {
            return;
        }

        currentInteractable = areaAsInteractable;
    }

    public void OnInteractionAreaAreaExited(Area2D area)
    {
        Interactable areaAsInteractable = area as Interactable;

        if (areaAsInteractable is null)
        {
            return;
        }

        if (currentInteractable == areaAsInteractable)
        {
            currentInteractable = null;
        }
    }

    public void OnInteractionAreaBodyEntered(Node2D body)
    {
        Enemy bodyAsEnemy = body as Enemy;

        if (bodyAsEnemy is null)
        {
            return;
        }

        player.gameManager.Lose();
    }
}
