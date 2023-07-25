﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    internal interface IControl
    {
        public Vector2 GetDirection();
        public Vector2 GetAim();

        public bool isFiring();
        public bool isSecondaryFiring();
        public bool isWeaponUnlock();
    }
}
