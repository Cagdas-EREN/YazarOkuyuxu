using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        private IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }

        public void Add(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public void Delete(Heading heading)
        {
          _headingDal.Update(heading);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetAllByWriter()
        {
            return _headingDal.GetAll(x => x.WriterId == 1); 
        }
    }
}
