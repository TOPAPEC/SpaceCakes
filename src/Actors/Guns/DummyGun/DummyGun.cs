using Godot;
using System;

public class DummyGun : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private Vector2 _projectileVelocity;
    private Timer _gunCooldown;
    private float _timeSinceLastShot = 0.0f;
    private Random _randomGen;

    private PackedScene _bulletScene =
        (PackedScene)ResourceLoader.Load("res://src/Entities/Projectiles/DummyBullet/DummyBullet.tscn");

    public DummyGun(Vector2 projectileVelocity)
    {
        _randomGen = new Random();
        _projectileVelocity = projectileVelocity;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }


    public override void _PhysicsProcess(float delta)
    {
        base._PhysicsProcess(delta);
        _timeSinceLastShot += delta;
        if (_timeSinceLastShot > 0.2)
        {
            var gunPosition = GetParent().GetNode<Position2D>("GunPosition").GlobalPosition;
            _timeSinceLastShot = 0.0f;
            Shoot(gunPosition);
            GD.Print("Shot!");
        } 
    }

    public void Shoot(Vector2 gunPosition)
    {
        var bullet = (DummyBullet)_bulletScene.Instance();
        bullet.GlobalPosition = gunPosition + new Vector2((float)_randomGen.NextDouble(), 0f) * _randomGen.Next(-50, 50);
        bullet.Speed = 1600;
        GetTree().Root.AddChild(bullet);
        bullet.Visible = true;
    }


    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}