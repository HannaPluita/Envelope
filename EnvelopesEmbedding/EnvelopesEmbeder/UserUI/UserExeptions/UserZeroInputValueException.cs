using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.UserUI.UserExeptions
{
    public class UserZeroInputValueException: UserException
    {
        private const string MESSAGE = "UserZeroInputValuException: a zero input value is inadmissible. Please, enter another value.";

        public UserZeroInputValueException()
            : base(MESSAGE)
        {
        }

        public UserZeroInputValueException(string message)
            : base(message)
        {
        }

        public UserZeroInputValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UserZeroInputValueException(Exception innerException)
            : base(MESSAGE, innerException)
        {
        }

        public override string ToString()
        {
            return MESSAGE;
        }
    }
}
