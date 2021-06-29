using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        void Add(Heading heading);
        Heading GetById(int id);
        void Delete(Heading heading);
        void Update(Heading heading);
    }
}
