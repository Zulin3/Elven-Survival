using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    class ControlPC : IControl
    {
        public ControlPC()
        {

        }

        public Vector2 GetAim()
        {
            Vector2 aim = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            return aim.normalized;
        }

        public Vector2 GetDirection()
        {
            return new Vector2(Input.GetAxis(Constants.HORIZONTAL_AXIS), Input.GetAxis(Constants.VERTICAL_AXIS));
        }

        public bool isFiring()
        {
            return Input.GetButton("Fire1");
        }
    }
}
