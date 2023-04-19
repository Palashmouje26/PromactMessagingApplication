using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PromactMessagingApp.DomainModel.Models.User;

namespace PromactMessagingApp.DomainModel.Models.Login
{
    public class UserLogin 
    {
        /// <summary>
        /// Id is used for user login.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// UserId is used for user login.
        /// </summary>
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual UserInformation UserInformation { get; set; }

        /// <summary>
        /// LoginDate is used for to maintain the user login history. 
        /// </summary>
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// IsValidate is used for user is active or not.
        /// </summary>
        public bool IsValidate { get; set; }
    }
}
