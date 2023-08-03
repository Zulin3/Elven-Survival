using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    internal interface ITouching: ICloneableMVC
    {
        public void HandleCollisions();
        public Collider[] GetColliders();
    }
}
