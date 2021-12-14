using System;

namespace Banks.Center.CoR
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual Bank BankHandle(Bank request)
        {
            if (_nextHandler != null)
            {
                return _nextHandler.BankHandle(request);
            }
            else
            {
                return null;
            }
        }
    }
}