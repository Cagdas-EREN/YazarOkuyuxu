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
    public class ImageFileManager : IImageService
    {
        private IImageFileDal _ımageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }

        public List<ImageFile> GetAll()
        {
            return _ımageFileDal.GetAll();
        }
    }
}
