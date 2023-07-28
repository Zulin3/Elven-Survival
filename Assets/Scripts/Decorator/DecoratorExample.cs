using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    internal sealed class DecoratorExample: MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;
        [Header("Aim Gun")]
        [SerializeField] private float _force;
        [SerializeField] private GameObject _aim;
        [SerializeField] private Transform _aimPosition;
        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 999.0f,
            _audioSource, _audioClip);
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler,
            _barrelPosition, _muffler);
            ModificationWeapon modificationMuffler = new
            ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler);
            modificationMuffler.ApplyModification(weapon);
            _fire = modificationMuffler;
            modificationMuffler.RemoveModification();
            var aim = new Aim(_force, _aim);
            ModificationWeapon modificationAim = new ModificationAim(aim, _aimPosition);
            modificationAim.ApplyModification(weapon);
            _fire = modificationAim;

        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }

}
