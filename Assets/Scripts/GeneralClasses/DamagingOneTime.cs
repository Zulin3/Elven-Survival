namespace Assets.Scripts.Interfaces
{
    public class DamagingOneTime : IDamaging
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
