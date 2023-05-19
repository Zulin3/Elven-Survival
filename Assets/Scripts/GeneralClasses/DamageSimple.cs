using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GeneralClasses
{
    class DamageSimple : IDamageable
    {
        private float _health;
        private float _maxHealth;
        private Transform _transform;
        private Slider _healthBar;
        public DamageSimple(float maxHealth, Transform transform)
        {
            _maxHealth = maxHealth;
            _health = maxHealth;
            _transform = transform;
            _healthBar = _transform.Find("Canvas").Find("HealthBar").GetComponent<Slider>();
            _healthBar.maxValue = maxHealth;
            _healthBar.value = maxHealth;
        }
        public void TakeDamage(float damage)
        {
            _health -= damage;
            _healthBar.value = _health;
            if (_health <= 0)
            {
                _health = 0;
                _healthBar.value = _health;
                Die();
            }
        }

        void Die()
        {
            UnityEngine.Object.Destroy(_transform.parent.gameObject);
        }
    }
}
