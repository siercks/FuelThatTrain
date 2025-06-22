using Godot;
using System;
using GodotPlugins;

public partial class Fuel : Area2D
{
	[Export] float _speed = 120.0f;
	[Signal] public delegate void OnFueledEventHandler();
	//[Export] float _hold;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Rect2 vpr = GetViewportRect();
		Position += new Vector2(0, _speed * (float)delta);
		if(Position.Y < vpr.End.Y)
		{
			//GD.Print("Out of bounds.");
		}
		
	}
	private void OnAreaEntered(Area2D area)
	{
		GD.Print("Fueled!");
		EmitSignal(SignalName.OnFueled);
		QueueFree();
	}
	
}
