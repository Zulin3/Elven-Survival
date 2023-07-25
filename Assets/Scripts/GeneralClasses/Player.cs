using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class Player : Unit
    {
        private IControl _controlImplementation;
        private IShoota _shoota;
        private IShoota _secondaryWeapon;

        public Player(Transform view, IMove moveImplementation, IControl controlImplementation, IDamageable damageable, ITouching touch, IShoota shoota, IShoota secondaryWeapon) : base(view, moveImplementation, damageable, touch)
        {
            _controlImplementation = controlImplementation;
            _shoota = shoota;
            _secondaryWeapon = secondaryWeapon;
        }

        private void Move(float deltaTime)
        {
            Vector2 direction = _controlImplementation.GetDirection();
            base.Move(direction.x, direction.y, deltaTime);
        }

        private void Aim()
        {
            Vector2 aim = _controlImplementation.GetAim();
            _shoota.SetAim(aim);
        }

        public void HandleControls(float deltaTime)
        {
            Move(deltaTime);
            Aim();
            if (_controlImplementation.isFiring())
            {
                _shoota.Shoot(Time.time);
            }
            if (_controlImplementation.isSecondaryFiring())
            {
                _secondaryWeapon.Shoot(Time.time);
            }
        }
    }
}