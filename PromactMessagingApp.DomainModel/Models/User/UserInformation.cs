using PromactMessagingApp.DomainModel.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromactMessagingApp.DomainModel.Models.User
{
    public class UserInformation
    {
        /// <summary>
        /// Id of the User.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        ///For User FirstName.
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        /// <summary>
        ///LastName is used for User LastName.
        /// </summary>
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Characters are not allowed.")]
        public string LastName { get; set; }

        /// <summary>
        ///Email is  used for User Email.
        /// </summary>
        [Required]
        [StringLength(200)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Password is  used for User Password.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        /// <summary>
        /// SubscriptionLevel is  used for usre Subscription level.
        /// </summary>
        public SubscriptionLevel SubscriptionLevel { get; set; }

        /// <summary>
        /// Status is  used for usre status, It is active or not.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// CreatedAt is used for when user is registerd.
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// ProfilePhoto is used for user Image.
        /// </summary>
        public string ProfilePhoto { get; set; }

        /// <summary>
        /// Notes Is used for taking some notes when registerd.
        /// </summary>
        [MaxLength(500)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,500}$", ErrorMessage = "Characters are not allowed.")]
        public string Notes { get; set; }
    }
}
