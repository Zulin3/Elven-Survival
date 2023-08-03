using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

namespace Assets.Scripts.MyLibraries
{
    public class GameObjectBuilder
    {
        protected GameObject _gameObject;

        public GameObjectBuilder()
        {
            _gameObject = new GameObject();
        }

        protected GameObjectBuilder(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public GameObjectVisualBuilder Visual()
        {
            return new GameObjectVisualBuilder(_gameObject);
        }

        public GameObjectPhysicsBuilder Physics()
        {
            return new GameObjectPhysicsBuilder(_gameObject);
        }

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }
    }
}
