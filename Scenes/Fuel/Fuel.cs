using Godot;
using System;
using GodotPlugins;

public partial class Fuel : Area2D
{
	[Export] float _speed = 120.0f;
	[Signal] public delegate void OnFueledEventHandler();
	[Signal] public delegate void FuelOffScreenEventHandler();
	float _bottomMargin = 100.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Position += new Vector2(0, _speed * (float)delta);
        CheckMissedFuel();

    }
    public void CheckMissedFuel()
	{
		if(Position.Y > (GetViewportRect().End.Y - _bottomMargin))
		{
            //QueueFree();
			EmitSignal(SignalName.FuelOffScreen);
			//SetProcess(false); // Using this instead of QueueFree keeps the missed ones on the screen. 
			QueueFree();
        }
    }
	private void OnAreaEntered(Area2D area)
	{
		GD.Print("Fueled!");
		EmitSignal(SignalName.OnFueled);
		QueueFree();
	}
	
}
