using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Applicaiton.Medarbejder.Commands
{
    public interface ICreateMedarbejderKompetenceCommand
    { void Create(MedarbejderKompetenceCreateDto requestDto);
    }
}
