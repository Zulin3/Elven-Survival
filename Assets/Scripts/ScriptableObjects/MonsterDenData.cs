using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MonsterDenData", menuName = "ScriptableObjects/MonsterDenData", order = 1)]
    public class MonsterDenData : ScriptableObject
    {
        public float health = 500f;
        public float colliderRadius = 1f;
    }
}
