using System;

namespace Assets.Scripts.Interfaces
{
    internal interface IDamageable: ICloneableMVC
    {
        public void TakeDamage(float damage);
        public event EventHandler OnDeath;
    }
}
