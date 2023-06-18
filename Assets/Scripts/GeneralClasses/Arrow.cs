using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class Arrow : Projectile, IRotation
    {
        private float _speed = 5;
        private float _angle = 0;
        public Arrow(float speed): base()
        {
            this.MoveImplementation = new MoveLinear(transform, speed);
        }

        public void Move(float deltaTime)
        {
            this.MoveImplementation.Move((float)Math.Cos(_angle), (float)Math.Sin(_angle), deltaTime);
        }

        public void Rotate(Vector2 direction)
        {
            _angle = (float)Math.Atan2(direction.y, direction.x);
            transform.rotation = Quaternion.Euler(0, 0, _angle * 180 / (float)Math.PI);
        }
    }
}
