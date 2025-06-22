using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Fuel _fuel;
	//[Signal] public delegate void OnFueledEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Fuel fuel = GetNode<Fuel>("Fuel");
		_fuel.OnFueled += OnFueled;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnFueled()
	{
		GD.Print("OnFueled Received");
	}
}
