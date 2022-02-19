using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mailer.Models
{
    public class Email
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public List<string> Recipients { get; set; }
        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string TimeStamp { get; set; }
        [Required]
        public string SendStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}