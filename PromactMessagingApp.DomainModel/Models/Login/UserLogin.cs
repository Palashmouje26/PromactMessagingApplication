using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PromactMessagingApp.DomainModel.Models.User;

namespace PromactMessagingApp.DomainModel.Models.Login
{
    public class UserLogin 
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserInformation UserInformation { get; set; }

        public DateTime LoginDate { get; set; }

        public bool IsValidate { get; set; }
    }
}
