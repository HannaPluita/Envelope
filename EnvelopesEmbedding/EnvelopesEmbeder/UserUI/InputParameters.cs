using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvelopesEmbeder.UserUI.UserExeptions;

namespace EnvelopesEmbeder.UserUI
{
    public class InputParameters
    {
        #region    CONSTANTS
        public const string MESSAGE_TARGET_SITE = "Exception Target Site is ";
        public const string MESSAGE_SOURCE = "Exception Source is ";
        public const string MESSAGE_ERROR = "Error in data inputting.";

        public const string ABOUT = "This application helps you to determine if one envelope can be embedded in another one.";
        public const string CONTINUE = "Would you like to continue?";
        public const string WANT_TO_START = "Would you like to start?";
        public const string ASK_YES = "yes or y - YES, another - NO";
        public const string VALID_PARAMETERS = "All entered parameters are valid.";
        public const string USERS_DATA = "Entered data is:";

        public const string YES_LONG = "yes";
        public const string YES_SHORT = "y";

        public const string ENTER_FIRST_WIDTH = "Please, enter the first envelope's width.";
        public const string ENTER_FIRST_HEIGHT = "Please, enter the first envelope's height.";
        public const string ENTER_SECOND_WIDTH = "Please, enter the second envelope's width.";
        public const string ENTER_SECOND_HEIGHT = "Please, enter the second envelope's height.";
        public const string FIRST_ENVELOPE = "The first envelope\'s parameters: ";
        public const string SECOND_ENVELOPE = "The second envelope\'s parameters: ";

        public const string FINISH_APP = "The app is finished.";
        public const string LETS_EMBED = "Let\'s check envelops for embedding...";
        #endregion

        #region    Protected
        protected double _width1 = 0.0;
        protected double _width2 = 0.0;
        protected double _height1 = 0.0;
        protected double _height2 = 0.0;
        #endregion

        #region    Constructors
        public InputParameters()
        {
        }

        public InputParameters(InputParameters inpPar)
        {
            _width1 = inpPar._width1;
            _height1 = inpPar._height1;
            _width2 = inpPar._width2;
            _height2 = inpPar._height2;
        }
        #endregion

        #region    Properties
        public double FirstWidth
        {
            get => _width1;
        }

        public double SecondWidth
        {
            get => _width2;
        }

        public double FirstHeight
        {
            get => _height1;
        }

        public double SecondHeight
        {
            get => _height2;
        }
        #endregion

        public static void OutputMsg(string msg)    //Output text message to console.
        {
            Console.WriteLine(msg);
        }

        public static bool IfContinue(string input)   //Check if user wants to continue
        {
            bool ifCont = false;

            input = input.ToLower();

            if(input == YES_LONG || input == YES_SHORT)
            {
                ifCont = true;
            }

            return ifCont;
        }

        public static bool GetParameter(out double result, string inviteMessage = "")
        {
            bool ifGet = false;

            if(inviteMessage != "")
            {
                Console.WriteLine(inviteMessage);
            }

            result = 0.0;
            string enteredStr = "";

            try
            {
                enteredStr = Console.ReadLine();

                if(enteredStr == "")
                {
                    throw new UserNullInputValueException();
                }


                result = double.Parse(enteredStr);
                if (result == 0.0)
                {
                    throw new UserZeroInputValueException();
                }
                ifGet = true;
            }
            catch (UserZeroInputValueException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            catch (UserNullInputValueException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            catch (FormatException e)
            {
                throw new UserInvalidFormatException(enteredStr, e);
            }
            catch (OverflowException e)
            {
                throw new UserRangeOverflowException(double.MinValue, double.MaxValue, enteredStr, e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("{0}{1}", MESSAGE_TARGET_SITE, e.TargetSite);
                Console.WriteLine("{0}{1}", MESSAGE_SOURCE, e.Source);
            }

            return ifGet;
        }

        public static double GetParameter(string enteredStr)
        {
            double result = 0.0;

            try
            {
                if (enteredStr == "")
                {
                    throw new UserNullInputValueException();
                }


                result = double.Parse(enteredStr);

                if (result == 0.0)
                {
                    throw new UserZeroInputValueException();
                }
            }
            catch (UserZeroInputValueException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            catch (UserNullInputValueException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            catch (FormatException e)
            {
                throw new UserInvalidFormatException(enteredStr, e);
            }
            catch (OverflowException e)
            {
                throw new UserRangeOverflowException(double.MinValue, double.MaxValue, enteredStr, e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("{0}{1}", MESSAGE_TARGET_SITE, e.TargetSite);
                Console.WriteLine("{0}{1}", MESSAGE_SOURCE, e.Source);
            }

            return result;
        }

        /// <summary>
        /// The method for setting an envelop's parameters
        /// </summary>
        /// <param name="ifFirst">If true - set first envelope's parameters, false - set second envelope's.</param>
        /// <param name="ifOutputData">If true - output entered envelope's data, false - do not output.</param>
        /// <returns></returns>
        public bool SetEnvelopeParams(bool ifFirst, bool ifOutputData = true)  
        {
            bool ifSet = false;

            try
            {
                if (ifFirst)
                {
                    if (GetParameter(out _width1, ENTER_FIRST_WIDTH) && GetParameter(out _height1, ENTER_FIRST_HEIGHT))
                    {
                        if(ifOutputData)
                        {
                            OutputMsg(string.Format("{0}[{1} X {2}]", FIRST_ENVELOPE, _width1, _height1));
                        }
                        ifSet = true;
                    }
                }
                else
                {
                    if (GetParameter(out _width2, ENTER_SECOND_WIDTH) && GetParameter(out _height2, ENTER_SECOND_HEIGHT))
                    {
                        if(ifOutputData)
                        {
                            OutputMsg(string.Format("{0}[{1} X {2}]", SECOND_ENVELOPE, _width2, _height2));
                        }
                        ifSet = true;
                    }
                }
            }
            catch (UserRangeOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UserInvalidFormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("{0}{1}", MESSAGE_TARGET_SITE, e.TargetSite);
                Console.WriteLine("{0}{1}", MESSAGE_SOURCE, e.Source);
            }
           
            return ifSet;
        }

        public bool SetEnvelopeParams(bool ifFirst, string widthStr, string heightStr)
        {
            bool ifSet = false;

            try
            {
                if (ifFirst)
                {
                    _width1 = GetParameter(widthStr);
                    _height1 = GetParameter(heightStr);
                     ifSet = true;
                }
                else
                {
                    _width2 = GetParameter(widthStr);
                    _height2 = GetParameter(heightStr);
                    ifSet = true;
                }
            }
            catch (UserRangeOverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UserInvalidFormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("{0}{1}", MESSAGE_TARGET_SITE, e.TargetSite);
                Console.WriteLine("{0}{1}", MESSAGE_SOURCE, e.Source);
            }

            return ifSet;
        }
    }
}
