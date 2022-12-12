using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Applicaiton.Medarbejder.Query
{
    public interface IMedarbejderGetByUserId
    {
        MedarbejderGetByUserIdDto GetByUserId(string userId);
    }
}
