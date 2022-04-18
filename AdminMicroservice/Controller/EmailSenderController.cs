using AdminMicroservice.Model;
using EmailSender.Interface;
using EmailSender.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.Controllers
{
    public class EmailSenderController : Controller
    {
        readonly IEmailSender _emailSender;
        public EmailSenderController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost, Route("SendEmail")]
        public async Task<IActionResult> SendEmailAsync(string recipientEmail)
        {
            try
            {
                 string messageStatus = await _emailSender.SendEmailAsync(recipientEmail);
                return Ok(messageStatus);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
