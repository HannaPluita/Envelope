using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.UserUI.UserExeptions
{
    public class UserNullInputValueException : UserException
    {
        public const string MESSAGE = "UserNullInputValueException: a null input value is inadmissible.\nPlease, enter a meaningful value.";

        public UserNullInputValueException()
            : base(MESSAGE)
        {
        }

        public UserNullInputValueException(string message)
            : base(message)
        {
        }

        public UserNullInputValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UserNullInputValueException(Exception innerException)
            : base(MESSAGE, innerException)
        {
        }

        public override string ToString()
        {
            return MESSAGE;
        }
    }
}
