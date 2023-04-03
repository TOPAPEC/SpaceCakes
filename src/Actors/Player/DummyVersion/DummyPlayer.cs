using Godot;
using System;

public partial class DummyPlayer : KinematicBody2D
{
    [Export] public int Speed { get; set; } = 800;
    public Node2D Gun = new DummyGun(Vector2.Up * 1600);
    private Vector2 _screenSize;
    private Vector2 _target;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _screenSize = GetViewportRect().Size;
        AddChild(Gun);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        base._Process(delta);
    }

    private bool checkWithinScreen(Vector2 position)
    {
        return position.x > 0 && position.y > 0 && position.x < this._screenSize.x && position.y < this._screenSize.y;
    }

    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        this._target = GetGlobalMousePosition();
        var velocity = Speed * Position.DirectionTo(_target);
        if (Position.DistanceTo(_target) > 10)
        {
            MoveAndSlide(velocity);
        }
    }


}