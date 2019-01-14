using EnvelopesEmbeder.Embedder;
using EnvelopesEmbeder.Logic;
using EnvelopesEmbeder.UserUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnvelopesEmbeder
{
    public class Application
    {
        public const byte MAX_ARGS_LENGTH = 4;

        #region    Protected
        protected readonly EnvelopeEmbedder _embedder;
        protected List<Container> _containers = new List<Container>();
        #endregion

        protected void Subscribe(Container cont)      
        {
            cont.FirstEnvelopeEmbedsToSecondEvent += OutputEmbedResults.FirstEnvelopeEmbedsToSecondEventHandler;
            cont.SecondEnvelopeEmbedsToFirstEvent += OutputEmbedResults.SecondEnvelopeEmbedsToFirstEventHandler;
            cont.EquateTwoEnvelopesEvent += OutputEmbedResults.EqualEnvelopesEventHandler;
            cont.NotEmbedAnyEnvelopeEvent += OutputEmbedResults.NoAnyEmeddedEnvelopesEventHandler;
        }

        //public void CheckAllContainersForEmbedding()
        //{
        //    foreach (Container item in _containers)
        //    {
        //        item.EmbedEnvelopes();
        //    }
        //}

        public bool SetInputParameters(InputParameters input)
        {
            if (input == null)
            {
                return false;
            }
            _containers.Add(new Container(new Envelope(input.FirstWidth, input.FirstHeight), new Envelope(input.SecondWidth, input.SecondHeight)));
            return true;
        }

        public bool SetOneContainer(InputParameters inpPar)
        {
            bool ifSet = false;
            bool ifFirstSet = false;
            bool ifSecondSet = false;

            ifFirstSet = inpPar.SetEnvelopeParams(true);
            ifSecondSet = inpPar.SetEnvelopeParams(false);

            if (ifFirstSet && ifSecondSet)
            {
                _containers.Add(new Container(new Envelope(inpPar.FirstWidth, inpPar.FirstHeight), new Envelope(inpPar.SecondWidth, inpPar.SecondHeight)));
                
                ifSet = true;
            }
            return ifSet;
        }

        public bool SetOneContainer(string width1, string height1, string width2, string height2, InputParameters inpPar)
        {
            bool ifSet = false;
            bool ifFirstSet = false;
            bool ifSecondSet = false;

            ifFirstSet = inpPar.SetEnvelopeParams(true, width1, height1);
            ifSecondSet = inpPar.SetEnvelopeParams(false, width2, height2);

            if (ifFirstSet && ifSecondSet)
            {
                _containers.Add(new Container(new Envelope(inpPar.FirstWidth, inpPar.FirstHeight), new Envelope(inpPar.SecondWidth, inpPar.SecondHeight)));

                ifSet = true;
            }
            return ifSet;
        }

        public void CheckOneContainerForEmbedding()
        {
            _containers.Last().EmbedEnvelopes();
        }

        public void CheckOneContainerForEmbedding(Container container)
        {
            container.EmbedEnvelopes();
        }

        //Interraction with logic and UI
        public void Run(bool ifInvite = true)    
        {
            InputParameters inpPara = new InputParameters();

            if(ifInvite)
            {
                InputParameters.OutputMsg(InputParameters.ABOUT);
                InputParameters.OutputMsg(InputParameters.WANT_TO_START);
            }

            bool contin = InputParameters.IfContinue(Console.ReadLine());

            while (contin)
            {
                SetOneContainer(inpPara);

                InputParameters.OutputMsg(string.Format("{0}  {1}", InputParameters.USERS_DATA, _containers.Last().ToString()));
                InputParameters.OutputMsg(InputParameters.LETS_EMBED);

                Subscribe(_containers.Last());
                CheckOneContainerForEmbedding();

                InputParameters.OutputMsg(InputParameters.CONTINUE);
                contin = InputParameters.IfContinue(Console.ReadLine());
            }
           
            Console.WriteLine(InputParameters.FINISH_APP);
        }

        public void Run(string[] args)
        {
            if(args == null || args.Length == 0 || args.Length < 4 )
            {
                Run();
            }

            InputParameters inpPara = new InputParameters();
            SetOneContainer(args[0], args[1], args[2], args[3], inpPara);
            InputParameters.OutputMsg(string.Format("{0}  {1}", InputParameters.USERS_DATA, _containers.Last().ToString()));
            InputParameters.OutputMsg(InputParameters.LETS_EMBED);

            Subscribe(_containers.Last());
            CheckOneContainerForEmbedding();

            InputParameters.OutputMsg(InputParameters.CONTINUE);
            if(InputParameters.IfContinue(Console.ReadLine()))
            {
                Run(false);
            }

            Console.WriteLine(InputParameters.FINISH_APP);
        }

    }
}
