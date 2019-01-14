using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopesEmbeder.Logic
{
    public interface IEmbeddable<T>
    {
        EmbeddingResult CompareToEnvelope(T other);
    }
}
