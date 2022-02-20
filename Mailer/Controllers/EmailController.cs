using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Mailer.Models;
using Mailer.Repository;
using Mailer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Controllers
{
    [ApiController]
    [Route("api/mails")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepo _repo;
        private readonly ISender _sender;

        public EmailController(IEmailRepo repo, ISender sender)
        {
            _repo = repo;
            _sender = sender;
        }
        
        /// <summary>
        /// Return all emails from db
        /// </summary>
        /// <returns>
        /// List of emails
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetAllEmails()
        {
            var emails = await _repo.GetAllEmailsAsync();
            return Ok(emails);
        }
        
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns>
        /// Return sent email
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<Email>> SendEmail(string recipients, string subject, string body)
        {
            var newEmail = await _sender.SendAsync(recipients, subject, body);
            await _repo.CreateEmailAsync(newEmail);
            _repo.SaveChangesAsync();
            return Ok(newEmail);
        }
    }
}