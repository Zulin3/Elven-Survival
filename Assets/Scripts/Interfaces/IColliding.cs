using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    internal interface IColliding
    {
        public void handleCollision(ITouching target);
    }
}
