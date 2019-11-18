using System.Collections.Generic;

namespace Benergy.Core.Exceptions
{
    public class NTException : System.Exception
    {
        private string message;
        private List<NTError> errors;

        public NTException(string message)
        {
            this.message = message;
        }

        public NTException(string message, List<NTError> errors)
            : this(message)
        {
            this.errors = errors;
        }

        public override string Message
        {
            get
            {
                return this.message;
            }
        }

        public List<NTError> Errors
        {
            get
            {
                return this.errors;
            }
        }
    }
}