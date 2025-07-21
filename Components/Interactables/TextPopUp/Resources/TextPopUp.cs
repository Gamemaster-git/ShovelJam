using Godot;

public partial class TextPopUp : Interactable
{
    [ExportGroup("Refrences")]
    [Export]
    private CollisionShape2D interactionAreaCollisionBox;
    [Export]
    private PointLight2D glow;
    [Export]
    private Control interactionPopUpControl;
    [ExportGroup("InteractionAreaValues")]
    [Export]
    private float interactionAreaRadius;
    [ExportGroup("InteractableValues")]
    [Export]
    private string text;
    [ExportGroup("InteractableValues")]
    [Export]
    private float energyFadeTime;


    public override void _Ready()
    {
        interactionAreaCollisionBox.Shape.Set((StringName)"radius", interactionAreaRadius);

        Text = text;
    }


    public override void Interaction()
    {
        Interactable.InteractionPopUp(interactionPopUpControl, PopUp.HIDE);

        Tween energyTween = CreateTween();

        energyTween.TweenProperty(glow, "energy", 0, energyFadeTime);
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area.GetParent() is InteractionHandler)
        {
            Interactable.InteractionPopUp(interactionPopUpControl, PopUp.SHOW);
        }
    }

    public void OnAreaExited(Area2D area)
    {
        if (area.GetParent() is InteractionHandler)
        {
            Interactable.InteractionPopUp(interactionPopUpControl, PopUp.HIDE);
        }
    }
}
