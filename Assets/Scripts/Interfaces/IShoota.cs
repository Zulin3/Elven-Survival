using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    internal interface IShoota
    {
        void Shoot(float now);
        void SetAim(Vector2 aim);
        void SetWeaponStats(float damage, float speed, float reloadTime);
    }
}
