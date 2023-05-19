using Assets.Scripts.Interfaces;
using UnityEngine;

public class Player : Unit
{
    IControl _controlImplementation;

    public Player(Transform view, IMove moveImplementation, IControl controlImplementation, IDamageable damageable) : base(view, moveImplementation, damageable)
    {
        _controlImplementation = controlImplementation;
    }

    public void Move(float deltaTime)
    {
        Vector2 direction = _controlImplementation.GetDirection();
        base.Move(direction.x, direction.y, deltaTime);
    }
}