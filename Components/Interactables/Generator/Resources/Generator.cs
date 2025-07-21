using Godot;
using Godot.Collections;

public partial class Generator : Interactable
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
    [Export]
    private GameManager gameManager;
    [ExportGroup("InteractionAreaValues")]
    [Export]
    private float interactionAreaRadius;
    [ExportGroup("InteractableValues")]
    [Export]
    private Dictionary<StringName, string> generatorText;
    [Export]
    private float energyFadeTime;
    [Export]
    private int totalBatteries;

    private int batteriesCollected = 0;


    public override void _Ready()
    {
        interactionAreaCollisionBox.Shape.Set((StringName)"radius", interactionAreaRadius);
    }

    public override void Interaction()
    {
        batteriesCollected++;

        if (batteriesCollected == totalBatteries)
        {
            Text = "Thats all of them huh?...";

            Interactable.InteractionPopUp(interactionPopUpControl, PopUp.HIDE);

            GetTree().CreateTimer(2).Timeout += () => gameManager.Win();

            return;
        }

        if (player.hasBattery)
        {
            Text = $"{generatorText[(StringName)"BatteryTrue"]} {totalBatteries - batteriesCollected} to go...";

            Interactable.InteractionPopUp(interactionPopUpControl, PopUp.HIDE);

            player.hasBattery = false;
        }
        else
        {
            Text = generatorText[(StringName)"BatteryFalse"];

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
