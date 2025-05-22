using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.ApplicationCore.Services
{
    public class ServiceInfirmier : Service<Infirmier>, IServiceInfirmier
    {
        public ServiceInfirmier(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Infirmier> GetAllWithLaboratoire()
        {
            return GetMany().Where(i => i.Laboratoire != null); 
        }

    }
}
