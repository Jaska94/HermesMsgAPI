using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Data;
using Hermes.Entities;
using Hermes.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Hermes.Services
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly MessageContext _context;

        public MessagesRepository(MessageContext context)
        {
            _context = context;
        }

        public async Task AddMessage(Message message)
        {          
                await _context.AddAsync(message);           
        }

        public async Task<List<Message>> RetrieveMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> RetrieveMessage(Guid id)
        {
            return await _context.Messages.FirstOrDefaultAsync(s => s.Id == id);
        }

        public bool Save()
        {
            return (_context.SaveChangesAsync().Result >= 0);
        }
    }
}
