using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    internal class ModificationAim: ModificationWeapon
    {
        private readonly IAim _aim;
        private readonly Transform _aimPosition;
        private Transform _aimView;

        private float _originalForce;
        public ModificationAim(IAim aim, Transform aimPosition)
        {
            _aim = aim;
            _aimPosition = aimPosition;
        }
        protected override Weapon AddModification(Weapon weapon)
        {
            var aim = Object.Instantiate(_aim.AimInstance, _aimPosition);
            _aimView = aim.transform;
            _originalForce = weapon.GetForce();
            weapon.SetForce(_aim.Force);
            return weapon;
        }
        protected override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(_aimView.gameObject);
            weapon.SetForce(_originalForce);
            return weapon;
        }
    }
}
