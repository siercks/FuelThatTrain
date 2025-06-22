using Godot;
using System;

public partial class Game : Node2D
{
    //[Export] private Fuel _fuel;
	[Export] private PackedScene _fuelScene;
	[Export] private Timer _spawnTimer;
	[Export] private Label _scoreLabel;
	[Export] private Label _missedFuelLabel;
	[Export] private Label _gameOverLabel;
	float _margin = 172.0f;
	public int missedFuel = 0;
	private int _score = 0;
	//[Export] private NodePath _fuelPath; // Just doing this to future-proof code.
    //private Fuel _fuel;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Fuel fuel = GetNode<Fuel>("Fuel");
		//_fuel = GetNode<Fuel>(_fuelPath);
		//_fuel.OnFueled += OnFueled;
		_spawnTimer.Timeout += CreateFuel;
        CreateFuel();

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		
	}
	private void CreateFuel()
	{
		Rect2 vpr = GetViewportRect();
		float randomX = (float)GD.RandRange((_margin + vpr.Position.X), (vpr.End.X - _margin));
		Fuel fuel = (Fuel)_fuelScene.Instantiate();
		AddChild(fuel);
		fuel.Position = new Vector2(randomX, -100);
		fuel.OnFueled += OnFueled;
		fuel.FuelOffScreen += FuelOffScreen;
		//fuel.FuelOffScreen += GameOver();
	}

	private void OnFueled()
	{
		_score += 1;
		_scoreLabel.Text = $"{_score:0000}";
	}
	private void FuelOffScreen()
	{
		missedFuel += 1;
		_missedFuelLabel.Text = $"{missedFuel}";
		if(missedFuel == 3) // Three strikes and you're out.
		{
			GameOver();
		}
	}
	private void GameOver()
	{
		foreach(Node node in GetChildren())
		{
			node.SetProcess(false);
			//node.QueueFree();
		}
		_spawnTimer.Stop();
		_gameOverLabel.Text = "Game Over\r\n:(";
	}

}
