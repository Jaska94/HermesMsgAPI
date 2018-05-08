using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Entities;
using Hermes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Services
{
    public interface IMessagesRepository
    {
        Task AddMessage(Message message);
        Task<List<Message>> RetrieveMessages();
        Task<Message> RetrieveMessage(Guid id);
        bool Save();
    }
}
