using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{

    [CreateAssetMenu(fileName = "TrapData", menuName = "ScriptableObjects/TrapData", order = 1)]
    public class TrapData : ProjectileData
    {
        public Sprite sprite;
        public Vector3 colliderPosition;
        public string name;
        public float size = 1;
        public float colliderRadius = 1f;
        public float reloadTime = 1f;
        public float damage = 30f;
        public int collisions = 1;
    }
}
