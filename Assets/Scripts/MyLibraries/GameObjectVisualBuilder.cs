using UnityEngine;

namespace Assets.Scripts.MyLibraries
{
    public class GameObjectVisualBuilder: GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder SetSize(float scale)
        {
            _gameObject.transform.localScale = new Vector3(scale, scale, scale);
            return this;
        }

        public GameObjectVisualBuilder Sprite(Sprite sprite)
        {
            _gameObject.GetOrAddComponent<SpriteRenderer>().sprite = sprite;
            return this;
        }
    }
}