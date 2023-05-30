using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using JobReady.Models;

namespace JobReady.Controllers
{
    
    public class ChatController : Controller
    {
        
        private List<Message> _messages = new List<Message>();

        public readonly JobReadyContext _context;
        public ChatController(JobReadyContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllMessages()
        {
            return PartialView("_MessageListPartial", _messages); // Return a partial view with messages
        }

        
        [HttpPost]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if the model is not valid
            }

            message.Id = GenerateNewId();
            message.CreatedOn = DateTime.Now;

            _messages.Add(message);

            return PartialView("_MessagePartial", message); // Return a partial view with the newly created message
        }

        

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(long id)
        {
            var existingMessage = GetMessageFromDataSource(id);

            if (existingMessage == null)
            {
                return NotFound(); // Return 404 Not Found if the message doesn't exist
            }

            _messages.Remove(existingMessage);

            return NoContent(); // Return 204 No Content to indicate successful deletion
        }

        private List<Message>  GetAllMessageFromDataSource(long senderId,long receiverId)
        {
            
            return _context.Messages.Where(m => m.SenderID == senderId && m.ReceiverID == receiverId)
                            .ToList();
        }

        private long GenerateNewId()
        {
            return _messages.Count > 0 ? _messages.Max(m => m.Id) + 1 : 1;
        }
    }
}

