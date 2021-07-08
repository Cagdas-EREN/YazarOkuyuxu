using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox(string p);
        List<Message> GetAllSendbox(string p);
        List<Message> ReadList();
        List<Message> UnReadList();        
        void Add(Message message);
        void AddDraft(Message message);
        List<Message> GetAllDraft();
        Message GetById(int id);
        void Delete(Message message);
        void Update(Message message);
        void ReadStatus(Message message);
    }
}
