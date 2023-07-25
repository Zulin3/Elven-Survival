using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GeneralClasses
{
    internal class UnlockShoota
    {
        public bool isUnlock { get; set; }
        public UnlockShoota(bool isUnlock)
        {
            this.isUnlock = isUnlock;
        }
    }
}
