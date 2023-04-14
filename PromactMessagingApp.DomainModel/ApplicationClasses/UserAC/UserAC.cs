using PromactMessagingApp.DomainModel.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace PromactMessagingApp.DomainModel.ApplicationClasses.UserAC
{
    public class UserAC
    {
        public string ? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public SubscriptionLevel SubscriptionLevel { get; set; }

        public bool Status { get; set; }

        public string CreatedAt { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
      

        public string? Notes { get; set; }
    }
}
