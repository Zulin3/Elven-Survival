using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.JSONParsing
{
    internal class MageFactory : IUnitFactory
    {
        public void CreateUnit(Vector3 position, Unit unit)
        {
            var unitObject = new GameObject();
            unitObject.transform.position = position;
            unitObject.transform.rotation = Quaternion.identity;
            unitObject.name = unit.unit.type + " " + unit.unit.health;
            unit.unitView = unitObject.transform;
        }
    }
}
