using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.JSONParsing
{
    internal class CompositionRootJson: MonoBehaviour
    {
        private UnitFactoryComposition _unitFactories;

        public void Start()
        {
            string filePath = "units.txt";
            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            sr.Close();
            Debug.Log(json);

            var units = JsonUtility.FromJson<UnitList>(json);
            _unitFactories = new UnitFactoryComposition();
            _unitFactories.CreateUnits(new Vector3(0, 0, 0), units);

        }

        public void Update()
        {
            
        }
    }
}
