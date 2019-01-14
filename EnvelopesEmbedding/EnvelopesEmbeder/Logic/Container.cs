using EnvelopesEmbeder.UserUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.Logic
{
    public delegate void EmbeddingEventHandler(object sender, EmbedEnvelopeEventArgs args); 

    public class Container
    {
        #region    Protected 
        protected Envelope _firstEnvelope = new Envelope();
        protected Envelope _secondEnvelope = new Envelope();
        protected EmbeddingResult _embedResult = EmbeddingResult.NoEmbeddings;

        protected EmbeddingEventHandler _embedToFirstEventHandler;
        protected EmbeddingEventHandler _embedToSecondEventHandler;
        protected EmbeddingEventHandler _equateEventHandler;
        protected EmbeddingEventHandler _notEmbedEventHandler;

        protected const string OUT_STRING_1 = "Container => <First Envelope>: ";
        protected const string OUT_STRING_2 = ">, <Second Envelope>: ";
        #endregion

        #region    Constructors
        public Container(Envelope first, Envelope second)
        {
            _firstEnvelope = first;
            _secondEnvelope = second;
        }

        public Container(Container container)
            :this(container._firstEnvelope, container._secondEnvelope)
        { }
        #endregion

        #region    Properties
        public Envelope FirstEnvelope
        { get => _firstEnvelope; private set => _firstEnvelope = value; }

        public Envelope SecondEnvelope
        { get => _secondEnvelope; private set => _secondEnvelope = value; }

        public EmbeddingResult EmbeddingResult { get => _embedResult; private set => _embedResult = value; }
        #endregion

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", OUT_STRING_1, _firstEnvelope.ToString(), OUT_STRING_2, _secondEnvelope.ToString());
        }

        #region   Events
        public event EmbeddingEventHandler FirstEnvelopeEmbedsToSecondEvent
        {
            add
            {
                _embedToSecondEventHandler += value;
            }
            remove
            {
                _embedToSecondEventHandler -= value;
            }
        }

        public event EmbeddingEventHandler SecondEnvelopeEmbedsToFirstEvent
        {
            add
            {
                _embedToFirstEventHandler += value;
            }
            remove
            {
                _embedToFirstEventHandler -= value;
            }
        }

        public event EmbeddingEventHandler EquateTwoEnvelopesEvent
        {
            add
            {
                _equateEventHandler += value;
            }
            remove
            {
                _equateEventHandler -= value;
            }
        }

        public event EmbeddingEventHandler NotEmbedAnyEnvelopeEvent
        {
            add
            {
                _notEmbedEventHandler += value;
            }
            remove
            {
                _notEmbedEventHandler -= value;
            }
        }
        #endregion

        //protected void Subscribe()      //Subscribing for EnvelopeEmbedder events in UI!!!
        //{
        //    FirstEnvelopeEmbedsToSecond += OutputEmbedResults.OutputNoAnyEmeddedEnvelopes;
        //    //SecondEnvelopeEmbedsToFirst += 
        //}

        public void EmbedEnvelopes()     //Generate events
        {
            _embedResult = _firstEnvelope.CompareToEnvelope(_secondEnvelope);
            
            switch(_embedResult)
            {
                case EmbeddingResult.Larger:
                    if(_embedToFirstEventHandler != null)
                    {
                        _embedToFirstEventHandler(this, new EmbedEnvelopeEventArgs(_firstEnvelope, _secondEnvelope));
                    }
                    break;
                case EmbeddingResult.Smaller:
                    if (_embedToSecondEventHandler != null)
                    {
                        _embedToSecondEventHandler(this, new EmbedEnvelopeEventArgs(_firstEnvelope, _secondEnvelope));
                    }
                    break;
                case EmbeddingResult.Equal:
                    if (_equateEventHandler != null)
                    {
                        _equateEventHandler(this, new EmbedEnvelopeEventArgs(_firstEnvelope, _secondEnvelope));
                    }
                    break;
                default:
                    if (_notEmbedEventHandler != null)
                    {
                        _notEmbedEventHandler(this, new EmbedEnvelopeEventArgs(_firstEnvelope, _secondEnvelope));
                    }
                    break;
            }
                        
        }

    }
}
