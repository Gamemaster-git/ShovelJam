using Godot;

public partial class StartButton : TextureButton
{
    [ExportGroup("Refrences")]
    [Export]
    private GameManager gameManager;


    public void OnPressed()
    {
        gameManager.Start();
    }
}
