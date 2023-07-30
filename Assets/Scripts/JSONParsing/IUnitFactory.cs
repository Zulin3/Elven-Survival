using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.JSONParsing
{
    public interface IUnitFactory
    {
        public void CreateUnit(Vector3 position, Unit unit);
    }
}
