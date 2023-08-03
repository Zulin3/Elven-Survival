using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Decorator
{
    internal abstract class ModificationWeapon: IFire
    {
        private Weapon _weapon;
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon RemoveModification(Weapon weapon);
        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void RemoveModification()
        {
            _weapon = RemoveModification(_weapon);
        }
        public void Fire()
        {
            _weapon.Fire();
        }

    }
}
