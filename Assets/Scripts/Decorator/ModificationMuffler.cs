using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    internal sealed class ModificationMuffler: ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private Transform _mufflerView;
        private readonly Transform _mufflerPosition;

        private AudioClip _originalClip;
        private Transform _originalBarrelPosition;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler,
        Transform mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }
        protected override Weapon AddModification(Weapon weapon)
        {
            var muffler = Object.Instantiate(_muffler.MufflerInstance,
            _mufflerPosition);
            _mufflerView = muffler.transform;
            _audioSource.volume = _muffler.VolumeFireOnMuffler;

            _originalClip = weapon.GetAudioClip();
            weapon.SetAudioClip(_muffler.AudioClipMuffler);

            _originalBarrelPosition = weapon.GetBarrelPosition();
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(_mufflerView.gameObject);
            _audioSource.volume = 1;
            Debug.Log(_originalClip);
            weapon.SetAudioClip(_originalClip);
            weapon.SetBarrelPosition(_originalBarrelPosition);
            return weapon;

        }
    }

}
