using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PromactMessagingApp.DomainModel.Models.User;

namespace PromactMessagingApp.DomainModel.Models.Login
{
    public class UserLoginHistory 
    {
        [Key]
        public int LoginId { get; set; }

        public Guid Id { get; set; }

        [ForeignKey("Id")]
        public virtual UserInformation UserInformation { get; set; }

        public DateTime LoginHistory { get; set; }

        public bool IsValidate { get; set; }
    }
}
