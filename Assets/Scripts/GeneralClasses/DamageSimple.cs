using Assets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class DamageSimple : IDamageable
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

            foreach (Transform childTransform in transform)
            {
                if (childTransform.name == "Canvas")
                {
                    _healthBar = childTransform.GetChild(0).GetComponent<Slider>();
                    _healthBar.maxValue = maxHealth;
                    _healthBar.value = maxHealth;
                    continue;
                }
            }
        }

        public object Clone(Transform newView)
        {
            return new DamageSimple(_maxHealth, newView);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            Debug.Log(_health);
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
            UnityEngine.Object.Destroy(_transform.gameObject);
        }
    }
}
