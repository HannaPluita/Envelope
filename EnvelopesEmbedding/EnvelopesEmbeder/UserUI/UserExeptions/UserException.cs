using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.UserUI.UserExeptions
{
    public class UserException : Exception
    {
        private const string MESSAGE = "Error: UserException.";

        public UserException()
            : base(MESSAGE)
        {
        }
        public UserException(string message)
            : base(message)
        {
        }
        public UserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", MESSAGE, base.Message);
        }
    }
}
