using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class ShootaProxy : IShoota
    {
        private readonly IShoota _shoota;
        private readonly UnlockShoota _unlockShoota;
        public ShootaProxy(IShoota shoota, UnlockShoota unlockShoota)
        {
            _shoota = shoota;
            _unlockShoota = unlockShoota;
        }

        public void SetAim(Vector2 aim)
        {
            _shoota.SetAim(aim);
        }

        public void SetWeaponStats(float damage, float speed, float reloadTime)
        {
            _shoota.SetWeaponStats(damage, speed, reloadTime);
        }

        public void Shoot(float now)
        {
            if (_unlockShoota.isUnlock)
            {
                _shoota.Shoot(now);
            }
        }
    }
}
