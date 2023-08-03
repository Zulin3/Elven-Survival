using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal abstract class BaseToucher: ITouching
    {
        protected LayerMask _layer;
        protected Transform _center;
        protected ColliderDictionary<IColliding> _colliderDictionary;
        public ITouching BaseObject { get; set; }


        public BaseToucher(Transform center, ColliderDictionary<IColliding> colliderDictionary, String layer)
        {
            _layer = LayerMask.GetMask(layer);
            _center = center;
            _colliderDictionary = colliderDictionary;
        }
        public abstract Collider[] GetColliders();

        public void HandleCollisions()
        {
            var colliders = GetColliders();
            //Debug.Log(colliders.Length);
            foreach (var collider in colliders)
            {
                var colliding = _colliderDictionary.GetValue(collider);
                if (colliding != null)
                {
                    colliding.handleCollision(BaseObject);
                }
            }
        }

        public object Clone(Transform newView)
        {
            var newToucher = (BaseToucher)MemberwiseClone();
            newToucher._center = newView;
            return newToucher;
            
        }
    }
}
