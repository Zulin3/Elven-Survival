using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class MoveAccelerated: IMove, ICloneableMVC
    {
        private readonly Rigidbody2D _rigidbody;
        private Vector3 _move;
        private float _acceleration;

        public MoveAccelerated(Transform transform, float acceleration)
        {
            _rigidbody = transform.GetComponent<Rigidbody2D>();
            _acceleration = acceleration;
        }

        public object Clone(Transform newTransform)
        {
            return new MoveLinear(newTransform, _acceleration);
        }

        public void Move(float x, float y, float deltaTime)
        {
            _move = new Vector3(x, y, 0f);
            _move = _acceleration * deltaTime * _move.normalized;
            _rigidbody.AddForce(_move);
        }
    }
}
