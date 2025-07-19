using Godot;

public partial class Enemy : CharacterBody2D
{
    [ExportGroup("Refrences")]
    [Export]
    public Player player;
}
