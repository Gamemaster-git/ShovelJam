using Godot;
using Godot.Collections;

public partial class Battery : Interactable
{
    [ExportGroup("Refrences")]
    [Export]
    private CollisionShape2D interactionAreaCollisionBox;
    [Export]
    private PointLight2D glow;
    [Export]
    private Control interactionPopUpControl;
    [Export]
    private Player player;
    [ExportGroup("InteractionAreaValues")]
    [Export]
    private float interactionAreaRadius;
    [ExportGroup("InteractableValues")]
    [Export]
    private Dictionary<StringName, string> batteryPickUpText;
    [Export]
    private float energyFadeTime;


    public override void _Ready()
    {
        interactionAreaCollisionBox.Shape.Set((StringName)"radius", interactionAreaRadius);
    }

    public override void Interaction()
    {
        if (!player.hasBattery)
        {
            Text = batteryPickUpText[(StringName)"BatteryFalse"];

            Interactable.InteractionPopUp(interactionPopUpControl, PopUp.HIDE);

            Tween energyTween = CreateTween();

            energyTween.TweenProperty(glow, "energy", 0, energyFadeTime);

            GetTree().CreateTimer(energyFadeTime).Timeout += () => QueueFree();

            player.hasBattery = true;
        }
        else
        {
            Text = batteryPickUpText[(StringName)"BatteryTrue"];

            Interactable.InteractionPopUp(interactionPopUpControl, PopUp.HIDE);
        }
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
