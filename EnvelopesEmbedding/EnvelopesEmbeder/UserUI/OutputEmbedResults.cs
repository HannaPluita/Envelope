using EnvelopesEmbeder.Embedder;
using EnvelopesEmbeder.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.UserUI
{
    public static class OutputEmbedResults
    {
        #region    Protected
        public const string  OutputFirstEmbedsToSecond_part1 = "Results: the first envelope ";
        public const string OutputFirstEmbedsToSecond_part2 = " can be embedded in the second envelope ";

        public const string OutputSecondEmbedsToFirst_part1 = "Results: the second envelope ";
        public const string OutputSecondEmbedsToFirst_part2 = " can be embedded in the first envelope ";

        public const string OutputTwoEqual_part1 = "Results: there are two equal envelopes - ";
        public const string OutputAndWord = " and ";
        #endregion

        
        public static void FirstEnvelopeEmbedsToSecondEventHandler(object sender, EmbedEnvelopeEventArgs args)
        {
            Console.WriteLine("{0}{1}{2}{3}.", OutputFirstEmbedsToSecond_part1, args.FirstEnvelope, OutputFirstEmbedsToSecond_part2, args.SecondEnvelope);
        }

        public static void SecondEnvelopeEmbedsToFirstEventHandler(object sender, EmbedEnvelopeEventArgs args)
        {
            Console.WriteLine("{0}{1}{2}{3}.", OutputSecondEmbedsToFirst_part1, args.SecondEnvelope, OutputSecondEmbedsToFirst_part2, args.FirstEnvelope);
        }

        public static void EqualEnvelopesEventHandler(object sender, EmbedEnvelopeEventArgs args)
        {
            Console.WriteLine("{0}{1}{2}{3}.", OutputTwoEqual_part1, args.FirstEnvelope, OutputAndWord, args.SecondEnvelope);
        }

        public static void NoAnyEmeddedEnvelopesEventHandler(object sender, EmbedEnvelopeEventArgs args)
        {
            Console.WriteLine("{0}{1}{2}{3}.", OutputFirstEmbedsToSecond_part1, args.FirstEnvelope, OutputFirstEmbedsToSecond_part2, args.SecondEnvelope);
        }
    }
}
