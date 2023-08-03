using UnityEngine;
using Assets.Scripts.GeneralClasses;

namespace Assets.Scripts.Interfaces
{
    internal interface IEnemyFactory
    {
        Enemy Create(Vector3 position);
    }

}