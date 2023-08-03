using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MyLibraries
{
    public static partial class GameObjectExtensions
    {
        public static GameObject Copy(this GameObject self)
        {
            var clonedObject = new GameObject(self.name);
            clonedObject.layer = self.layer;
            clonedObject.transform.position = self.transform.position;
            clonedObject.transform.rotation = self.transform.rotation;
            clonedObject.transform.localScale = self.transform.localScale;
            if (self.TryGetComponent<Rigidbody>(out var Rigidbody))
            {
                var clonedRigidbody = clonedObject.AddComponent<Rigidbody>();
                clonedRigidbody.mass = Rigidbody.mass;
                clonedRigidbody.drag = Rigidbody.drag;
                clonedRigidbody.angularDrag = Rigidbody.angularDrag;
                clonedRigidbody.useGravity = Rigidbody.useGravity;
                clonedRigidbody.isKinematic = Rigidbody.isKinematic;
                clonedRigidbody.constraints = Rigidbody.constraints;
                clonedRigidbody.freezeRotation = Rigidbody.freezeRotation;
            }
            if (self.TryGetComponent<Rigidbody2D>(out var Rigidbody2D))
            {
                var clonedRigidbody2D = clonedObject.AddComponent<Rigidbody2D>();
                clonedRigidbody2D.mass = Rigidbody2D.mass;
                clonedRigidbody2D.drag = Rigidbody2D.drag;
                clonedRigidbody2D.angularDrag = Rigidbody2D.angularDrag;
                clonedRigidbody2D.gravityScale = Rigidbody2D.gravityScale;
                clonedRigidbody2D.isKinematic = Rigidbody2D.isKinematic;
                clonedRigidbody2D.constraints = Rigidbody2D.constraints;
                clonedRigidbody2D.freezeRotation = Rigidbody2D.freezeRotation;
            }
            if (self.TryGetComponent<CircleCollider2D>(out var CircleCollider2D))
            {
                var clonedCircleCollider2D = clonedObject.AddComponent<CircleCollider2D>();
                clonedCircleCollider2D.radius = CircleCollider2D.radius;
                clonedCircleCollider2D.offset = CircleCollider2D.offset;
                clonedCircleCollider2D.isTrigger = CircleCollider2D.isTrigger;
                clonedCircleCollider2D.sharedMaterial = CircleCollider2D.sharedMaterial;
                clonedCircleCollider2D.enabled = CircleCollider2D.enabled;
            }
            if (self.TryGetComponent<SpriteRenderer>(out var SpriteRenderer))
            {
                var clonedSpriteRenderer = clonedObject.AddComponent<SpriteRenderer>();
                clonedSpriteRenderer.sprite = SpriteRenderer.sprite;
                clonedSpriteRenderer.drawMode = SpriteRenderer.drawMode;
                clonedSpriteRenderer.size = SpriteRenderer.size;
            }
            clonedObject.SetActive(true);
            return clonedObject;
        }
    }
}
