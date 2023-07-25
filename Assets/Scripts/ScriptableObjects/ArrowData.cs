using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ArrowData", menuName = "ScriptableObjects/ArrowData", order = 1)]
    public class ArrowData : ProjectileData
    {
        public Sprite sprite;
        public Vector3 colliderPosition;
        public string name;
        public float size = 1;
        public float colliderRadius = 0.15f;
        public float reloadTime = 0.1f;
        public float speed = 10f;
        public float damage = 10f;
        public int collisions = 1;
    }
}