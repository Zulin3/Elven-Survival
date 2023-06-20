using Assets.Scripts.Interfaces;
using Assets.Scripts.MyLibraries;
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
        public Arrow(Transform view, float speed, int collisions, float damage, Vector2 aim, ViewServices viewServices, List<Projectile> projectileList): base(view, viewServices, projectileList, new MoveLinear(view, speed), new DamagingOneTime(damage), collisions)
        {
            Rotate(aim);
        }

        public void Move(float deltaTime)
        {
            this.MoveImplementation.Move((float)Math.Cos(_angle), (float)Math.Sin(_angle), deltaTime);
        }

        public void Rotate(Vector2 direction)
        {
            _angle = (float)Math.Atan2(direction.y, direction.x);
            _view.rotation = Quaternion.Euler(0, 0, _angle * 180 / (float)Math.PI);
        }
    }
}
