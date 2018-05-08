using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hermes.Data;
using Hermes.Entities;
using Hermes.Models;
using Hermes.Services;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace Hermes.Controllers
{
    [Route("api/messages")]
    public class MessagesController : Controller
    {
        private readonly IMessagesRepository _messagesRepository;

        public MessagesController(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }

        [HttpGet(Name = "GetMessage")]
        public IActionResult GetMessages()
        {
            var messagesFromRepository = _messagesRepository.RetrieveMessages();
            return Ok(messagesFromRepository.Result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(Guid id)
        {
            var messageFromRepository = _messagesRepository.RetrieveMessage(id);
            return Ok(messageFromRepository.Result);

        }
        
        [HttpPost(Name = "CreateMessage")]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            if (message == null) return BadRequest();

            message.Date = DateTime.Now;
            _messagesRepository.AddMessage(message);

            if (!_messagesRepository.Save())
            {
                throw new Exception("Failed to save changes");
            }
            

            return CreatedAtRoute("GetMessage", new {id = message.Id}, message);

        }
    }
}
