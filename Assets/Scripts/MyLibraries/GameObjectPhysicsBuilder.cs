using UnityEngine;

namespace Assets.Scripts.MyLibraries
{
    public sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) {}

        public GameObjectPhysicsBuilder Rigidbody(float mass)
        {
            var component = _gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            return this;
        }

        public GameObjectPhysicsBuilder SetLayer(string layerName)
        {
            _gameObject.layer = LayerMask.NameToLayer(layerName);
            return this;
        }

        public GameObjectPhysicsBuilder SphereCollider(float radius, Vector3 position, bool isTrigger) {
            var component = _gameObject.GetOrAddComponent<SphereCollider>();
            component.radius = radius;
            component.center = position;
            component.isTrigger = isTrigger;
            return this;
        }

        public GameObjectPhysicsBuilder BoxCollider(Vector3 size, Vector3 position, bool isTrigger)
        {
            var component = _gameObject.GetOrAddComponent<BoxCollider>();
            component.size = size;
            component.center = position;
            component.isTrigger = isTrigger;
            return this;
        }
    }
}