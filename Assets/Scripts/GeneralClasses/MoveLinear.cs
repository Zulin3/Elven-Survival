using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    class MoveLinear : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;
        private float _speed;

        public MoveLinear(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(float x, float y, float deltaTime)
        {
            _move = new Vector3(x, y, 0f);
            _move = _speed * deltaTime * _move.normalized;
            _transform.localPosition += _move;
        }
    }
}
