using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BirdEnemyData", menuName = "ScriptableObjects/BirdEnemyData", order = 1)]
    internal class BirdEnemyData : ScriptableObject
    {
        public float acceleration = 2f;
        public float damage = 10f;
        public float health = 30f;
        public float colliderRadius = 0.3f;
        public float renderLayer = -5;
        public int pointsReward = 1000;
    }
}
