using System;

namespace TestAppClient.Core.Domian
{
    public abstract class CardException : Exception
    {
        public string Code { get; }

        protected CardException()
        {
        }

        protected CardException(string code)
        {
            Code = code;
        }

        protected CardException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected CardException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected CardException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected CardException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
