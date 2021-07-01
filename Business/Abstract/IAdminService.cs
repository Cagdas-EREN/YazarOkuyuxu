using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        List<Admin> GetListByHeadingId(int id);
        void Add(Admin admin);
        Admin GetById(int id);
        void Delete(Admin admin);
        void Update(Admin admin);
    }
}
