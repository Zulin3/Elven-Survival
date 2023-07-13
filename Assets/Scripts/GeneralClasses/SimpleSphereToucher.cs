using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class SimpleSphereToucher : BaseToucher
    {
        private float _radius;
        
        public SimpleSphereToucher(Transform center, float radius, string layer, ColliderDictionary<IColliding> colliderDictionary) : base(center, colliderDictionary, layer)
        {
            _radius = radius;
        }

        public override Collider[] GetColliders()
        {
            Collider[] colliders = Physics.OverlapSphere(_center.position, _radius, _layer);
            return colliders;
        }
    }
}
