using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GeneralClasses
{
    static public class Constants
    {
        public const string HORIZONTAL_AXIS = "Horizontal";
        public const string VERTICAL_AXIS = "Vertical";

        public const float PLAYER_SPEED = 5f;
        public const float PLAYER_MAX_HEALTH = 100f;

        public const float ENEMY_FOX_SPEED = 3f;
        public const float ENEMY_FOX_DAMAGE = 10f;
        public const float ENEMY_FOX_HEALTH = 50f;

        public const float ARROW_SPEED = 10f;
        public const float ARROW_DAMAGE = 10f;
        public const int ARROW_COLLISIONS = 1;
    }
}
