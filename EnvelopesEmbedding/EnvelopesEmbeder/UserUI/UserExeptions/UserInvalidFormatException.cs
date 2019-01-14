using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.UserUI.UserExeptions
{
    public class UserInvalidFormatException : UserException
    {
        public const string MESSAGE_ENTERED = "UserInvalidFormatException: entered value ";
        public const string MESSAGE_CAUSE = "is in invalid format.";
        public const string MESSAGE_PLEASE = "Please, enter another value.";


        protected string _inputValue = "";

        public UserInvalidFormatException()
            : base(string.Format(MESSAGE_ENTERED, MESSAGE_CAUSE, MESSAGE_PLEASE))
        {
        }

        public UserInvalidFormatException(string inputValue)
            : base(string.Format(MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, MESSAGE_PLEASE))
        {
            _inputValue = inputValue;
        }

        public UserInvalidFormatException(string inputValue, string message)
            : base(message)
        {
            _inputValue = inputValue;
        }

        public UserInvalidFormatException(string inputValue, Exception innerException)
            : base(string.Format(MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, MESSAGE_PLEASE), innerException)
        {
        }

        public UserInvalidFormatException(string inputValue, string message,  Exception innerException)
            : base(message, innerException) 
        {
            _inputValue = inputValue;
        }

        public override string ToString()
        {
            return string.Format(MESSAGE_ENTERED, MESSAGE_CAUSE, MESSAGE_PLEASE);
        }

        public string ToString(string inputValue)
        {
            return string.Format(MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, MESSAGE_PLEASE);
        }

        public string InputValue
        {
            get => _inputValue; set => _inputValue = value;   
        }
    }
}
