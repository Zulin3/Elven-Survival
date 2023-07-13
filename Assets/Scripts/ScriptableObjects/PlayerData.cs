using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public float speed = 5f;
        public float maxHealth = 100f;
    }
}