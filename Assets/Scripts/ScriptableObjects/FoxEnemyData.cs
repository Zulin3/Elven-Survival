using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "FoxEnemyData", menuName = "ScriptableObjects/FoxEnemyData", order = 1)]
    public class FoxEnemyData: ScriptableObject
    {
        public float speed = 3f;
        public float damage = 10f;
        public float health = 50f;
    }
}