using Godot;
using System;

public class DummyBullet : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] public float Speed { get; set; }
    [Export] public float StartSpeed { get; set; } = 500f;
    private float _currentSpeed;
    private VisibilityNotifier2D _visibility;
    private DummyBullet _bulletScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        base._Ready();
        _visibility = GetNode<VisibilityNotifier2D>("VisibilityNotifier2D");
        _currentSpeed = StartSpeed;
        _bulletScene = GetNode<DummyBullet>(".");
        
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        _currentSpeed = Mathf.Lerp(_currentSpeed, Speed, 4f * delta);
        Position += _currentSpeed * Vector2.Up * delta;
        if (!_visibility.IsOnScreen())
        {
            QueueFree();
        }       
    }

    // public DummyBullet(Vector2 velocity, Vector2 globalPosition)
    // {
    //     _velocity = velocity;
    //     GlobalPosition = globalPosition;
    // }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
