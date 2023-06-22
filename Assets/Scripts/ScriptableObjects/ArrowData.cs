using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ArrowData", menuName = "ScriptableObjects/ArrowData", order = 1)]
    public class ArrowData : ScriptableObject
    {
        public float speed = 10f;
        public float damage = 10f;
        public int collisions = 1;
    }
}