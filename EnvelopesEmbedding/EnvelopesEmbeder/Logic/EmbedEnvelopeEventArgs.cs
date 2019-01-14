using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.Logic
{
    public class EmbedEnvelopeEventArgs: EventArgs
    {
        public EmbedEnvelopeEventArgs(Envelope first, Envelope second)
        {
            _first = first;
            _second = second;
        }

        public Envelope FirstEnvelope { get => _first; private set => _first = value; }
        public Envelope SecondEnvelope { get => _second; private set => _second = value; }

        private Envelope _first;
        private Envelope _second;
    }
}
