using Godot;

public partial class Mob : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        
		// Gets the list of animation names from the AnimatedSprite2D's frames property
        // and returns an Array containing all three animation names: ["walk", "swim", "fly"]
        string[] mobTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();

        // Picks a random number between 0 and 2 to select one of these names from the list
        animatedSprite2D.Play(mobTypes[GD.Randi() % mobTypes.Length]); // randi() % n selects a random integer between 0 and n-1
    }

	public void OnVisibleOnScreenNotifier2DScreenExited()
	{
		QueueFree();
	}
}
