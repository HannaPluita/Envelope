using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.Logic
{
    public struct Envelope: IEmbeddable<Envelope>
    {
        #region    Private
        private double _height;
        private double _width;
        #endregion

        #region    Constructors
        public Envelope(double width, double height)
        {
            _height = height;
            _width = width;
        }

        public Envelope(double side)
            :this(side, side)
        {}


        public Envelope(Envelope envp)
            :this(envp._width, envp._height)
        {}
        #endregion

        #region    Properties

        public double Height
        { get => _height; private set => _height = value; }

        public double Width
        { get => _width; private set => _width = value; }
        #endregion


        public EmbeddingResult CompareToEnvelope(Envelope other)
        {
            EmbeddingResult result = EmbeddingResult.NoEmbeddings;

            if (this._width > other._width && this._height > other._height)
            {
                result = EmbeddingResult.Larger;
            }
            else if (this._width < other._width && this._height < other._height)
            {
                result = EmbeddingResult.Smaller; }
            else if (this._width == other._width && this._height == other._height)
            {
                result = EmbeddingResult.Equal;
            }
            else
            {
                result = EmbeddingResult.NoEmbeddings;
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("[ {0,3} X {1,3} ]",_width, _height);
        }

        public void TestMethod()
        { }
    }
}
