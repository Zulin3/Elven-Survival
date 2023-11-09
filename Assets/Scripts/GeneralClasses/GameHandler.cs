using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GeneralClasses
{
    internal class GameHandler: IGameHandler
    {
        private IGameHandler _nextHandler;

        public IGameHandler SetNext(IGameHandler handler)
        {
            if (_nextHandler == null) 
            {
                _nextHandler = handler;
            }
            else
            {
                _nextHandler.SetNext(handler);
            }
            
            return handler;
        }

        public virtual void Handle()
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle();
            }
        }
    }
}
