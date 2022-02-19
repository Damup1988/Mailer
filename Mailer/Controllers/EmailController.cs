using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Models;
using Mailer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Controllers
{
    [ApiController]
    [Route("api/mails")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepo _repo;

        public EmailController(IEmailRepo repo)
        {
            _repo = repo;
        }
        
        /// <summary>
        /// Return all emails from db
        /// </summary>
        /// <returns>List of emails</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetAllEmails()
        {
            var emails = await _repo.GetAllEmailsAsync();
            return Ok(emails);
        }
    }
}