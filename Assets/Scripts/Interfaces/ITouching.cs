using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    internal interface ITouching
    {
        public void HandleCollisions();
        public Collider[] GetColliders();
    }
}
