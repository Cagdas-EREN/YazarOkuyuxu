using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll(string search);
        List<Content> GetAllByWriter(int id);
        List<Content> GetListByHeadingId(int id);
        void Add(Content content);
        Content GetById(int id);
        void Delete(Content content);
        void Update(Content content);
    }
}
