using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContentManager : IContentService
    {
        private IContentDal _contentDal;

        public ContentManager(IContentDal contentyDal)
        {
            _contentDal = contentyDal;
        }
        public void Add(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetAll(string search)
        {
            return _contentDal.GetAll(x=>x.ContentValue.Contains(search));
        }

        public List<Content> GetAllByWriter(int id)
        {
            return _contentDal.GetAll(x => x.WriterId == id);
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.GetAll(x => x.HeadingId == id);
        }

        public void Update(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
