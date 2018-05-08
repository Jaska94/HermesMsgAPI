using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Data
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {          
        }
        public DbSet<Message> Messages { get; set; }
    }
}
