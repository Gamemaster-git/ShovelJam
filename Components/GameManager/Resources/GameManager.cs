using Godot;

public partial class GameManager : Control
{
    [ExportGroup("Refrences")]
    [Export]
    private Control winUserInterface;
    [Export]
    private Control loseUserInterface;
    [Export]
    private Control startUserInterface;
    [Export]
    private TextureRect background;


    public override void _Ready()
    {
        Tween opacityTween = CreateTween();
        opacityTween.TweenProperty(background, "modulate:a", 1, Global.UserInterfaceAnimationSpeed);
        opacityTween.TweenProperty(startUserInterface, "modulate:a", 1, Global.UserInterfaceAnimationSpeed);

    }

    public void Win()
    {
        Tween opacityTween = CreateTween();
        opacityTween.TweenProperty(background, "modulate:a", 1, Global.UserInterfaceAnimationSpeed);
        opacityTween.TweenProperty(winUserInterface, "modulate:a", 1, Global.UserInterfaceAnimationSpeed);
    }

    public void Lose()
    {
        Tween opacityTween = CreateTween();
        opacityTween.TweenProperty(background, "modulate:a", 1, Global.UserInterfaceAnimationSpeed);
        opacityTween.TweenProperty(loseUserInterface, "modulate:a", 1, Global.UserInterfaceAnimationSpeed);
    }

    public void Start()
    {
        Tween opacityTween = CreateTween();
        opacityTween.TweenProperty(background, "modulate:a", 0, Global.UserInterfaceAnimationSpeed);
        opacityTween.TweenProperty(startUserInterface, "modulate:a", 0, Global.UserInterfaceAnimationSpeed);

        startUserInterface.QueueFree();
    }
}
