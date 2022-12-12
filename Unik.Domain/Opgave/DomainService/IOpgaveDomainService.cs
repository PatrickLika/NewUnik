using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Domain.Opgave.DomainService
{
    public interface IOpgaveDomainService
    {
        int BeregnOpgaveVarighed(int projektId);
    }
}
