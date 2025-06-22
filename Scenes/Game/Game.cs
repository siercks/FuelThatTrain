using Godot;
using System;

public partial class Game : Node2D
{
    [Export] private Fuel _fuel;
	[Export] private PackedScene _fuelScene;
	//[Export] private NodePath _fuelPath; // Just doing this to future-proof code.
    //private Fuel _fuel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Fuel fuel = GetNode<Fuel>("Fuel");
		//_fuel = GetNode<Fuel>(_fuelPath);
		_fuel.OnFueled += OnFueled;
        CreateFuel();

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}

	private void CreateFuel()
	{
		Fuel fuel = (Fuel)_fuelScene.Instantiate();
		AddChild(fuel);
		fuel.Position = new Vector2(400, -100);
	}

	private void OnFueled()
	{
		GD.Print("OnFueled Received");
	}
}
