using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.JSONParsing
{
    internal class UnitFactoryComposition : IUnitFactory
    {
        private Dictionary<string, IUnitFactory> _unitFactories;
        public void CreateUnit(Vector3 position, Unit unit)
        {
            string type = unit.unit.type;
            switch (type)
            {
                case "infantry":
                    var factory = _unitFactories["infantry"];
                    factory.CreateUnit(position, unit);
                    break;
                case "mag":
                    var factory2 = _unitFactories["mag"];
                    factory2.CreateUnit(position, unit);
                    break;
                default:
                    Console.WriteLine("Invalid unit type");
                    break;
            }
        }

        public void CreateUnits(Vector3 position, UnitList units)
        {
            foreach (Unit unit in units.list)
            {
                CreateUnit(position, unit);
            }

        }

        public UnitFactoryComposition()
        {
            _unitFactories = new Dictionary<string, IUnitFactory>();
            _unitFactories.Add("infantry", new InfantryFactory());
            _unitFactories.Add("mag", new MageFactory());
        }

        public void AddFactory(string key, Type type)
        {
            _unitFactories.Add(key, (IUnitFactory)Activator.CreateInstance(type));
        }

        public void RemoveFactory(string key)
        {
            _unitFactories.Remove(key);
        }

        public void RemoveAllFactories()
        {
            _unitFactories.Clear();
        }
    }
}
