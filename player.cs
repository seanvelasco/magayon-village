using Godot;
using System;





public partial class player : CharacterBody2D
{
	public AnimationPlayer animationPlayer;
	public const float Speed = 100.0f;
	public const float JumpVelocity = -400.0f;
	
	public override void _PhysicsProcess(double delta)
	{
		var ap = GetNode("AnimationPlayer") as AnimationPlayer;
		Vector2 velocity = Velocity;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		

		
		
		if (direction != Vector2.Zero)
		{

			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
			
			if (velocity.X < direction.X)
			{
				ap.Play("walkLeft");
			}
			
			if (velocity.X > direction.X)
			{
				ap.Play("walkRight");
			}
			
			if (velocity.Y < direction.Y)
			{
				ap.Play("walkUp");
			}
			
			if (velocity.Y > direction.Y)
			{
				ap.Play("walkDown");
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		
		if (velocity.Length() == 0)
		{
			ap.Stop();
		}
	
		
		


		Velocity = velocity;
		MoveAndSlide();
	}
}
