using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.UserUI.UserExeptions
{
    public class UserRangeOverflowException: UserInvalidFormatException
    {
        protected double _maxValidValue = 0;
        protected double _minValidValue = 0;

        public const string MESSAGE_ENTERED = "UserRangeOverflowException: the entered value ";
        public const string MESSAGE_CAUSE = " is out of permissible range";
        public const string MESSAGE_PLEASE = ". Please, enter another value.";

        public UserRangeOverflowException()
            : base(MESSAGE_ENTERED)
        {
        }

        public UserRangeOverflowException(string inputValue)
            :base(inputValue, string.Format(MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, MESSAGE_PLEASE))
        {
        }

        public UserRangeOverflowException(string inputValue, string outputMessage)
            :base(inputValue, outputMessage)
        {
        }

        public UserRangeOverflowException(double minValidValue, double maxValidValue, string inputValue)
            : base(inputValue,
                  string.Format("{0}{1}{2} [{3},{4}]{5}", MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, minValidValue, maxValidValue, MESSAGE_PLEASE))
        {
            _minValidValue = minValidValue;
            _maxValidValue = maxValidValue;
        }

        public UserRangeOverflowException(string inputValue, string message, Exception innerException)
            : base(inputValue, message, innerException)
        {
        }

        public UserRangeOverflowException(double minValidValue, double maxValidValue, string inputValue, Exception innerException)
            : base(inputValue,
                 string.Format("{0}{1}{2} [{3},{4}]{5}", MESSAGE_ENTERED, inputValue, MESSAGE_CAUSE, minValidValue, maxValidValue, MESSAGE_PLEASE),
                 innerException)
        {
            _minValidValue = minValidValue;
            _maxValidValue = maxValidValue;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}",MESSAGE_ENTERED, MESSAGE_CAUSE, MESSAGE_PLEASE);
        }

        public new string ToString(string enteredStr)
        {
            return string.Format("{0}{1}{2}{3}", MESSAGE_ENTERED, enteredStr, MESSAGE_CAUSE, MESSAGE_PLEASE);
        }

        public string ToString(string enteredStr, string minValue, string maxValue)
        {
            return string.Format("{0}{1}{2} [{3},{4}]{5}", MESSAGE_ENTERED, enteredStr, MESSAGE_CAUSE, minValue, maxValue, MESSAGE_PLEASE);
        }

        public double MinValidValue
        {
            get => _minValidValue;
        }

        public double MaxValidValue
        {
            get => _maxValidValue;
        }
    }
}


