using Assets.Scripts.Interfaces;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class DamagingOneTime : IDamaging
    {
        private float _damage;

        public DamagingOneTime(float damage)
        {
            _damage = damage;
        }

        public void DealDamage(IDamageable target)
        {
            target.TakeDamage(_damage);
        }
    }
}
