using Assets.Scripts.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Exceptions
{
    public class InvalidProjectileTypeException : Exception
    {
        public InvalidProjectileTypeException()
            : base($"Попытка создать снаряд с неизвестным типом")
        {
        }
    }
}
