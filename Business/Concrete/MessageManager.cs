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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void AddDraft(Message message)
        {
            message.MessageStatus = true;
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllDraft()
        {
            return _messageDal.GetAll(x => x.MessageStatus == true);
        }

        public List<Message> GetAllInbox()
        {
            return _messageDal.GetAll(x => x.ReceiverMail == "alican@gmail.com");
        }

        public List<Message> GetAllSendbox()
        {
            return _messageDal.GetAll(x => x.SenderMail == "alican@gmail.com");
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.Id == id);
        }

        public List<Message> ReadList()
        {
            return _messageDal.GetAll(x=>x.MessageRead == true);
        }

        public void ReadStatus(Message message)
        {
            if (message.MessageRead == false)
            {
                message.MessageRead = true;
            }

            _messageDal.Update(message);
        }

        public List<Message> UnReadList()
        {
            return _messageDal.GetAll(x => x.MessageRead == false);
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
