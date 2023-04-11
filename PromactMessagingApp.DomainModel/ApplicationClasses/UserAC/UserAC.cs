using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PromactMessagingApp.DomainModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace PromactMessagingApp.DomainModel.ApplicationClasses.UserAC
{
    public class UserAC
    {


        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,100}$", ErrorMessage = "Characters are not allowed.")]

        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; }
    
        [Required]
        [StringLength(14, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,14})+$", ErrorMessage = "Password must be alphanumeric including at least 1 uppercase letter,1 lowercase letter and a special character with 8 to 14 characters")]

        [Display(Name = "New password")]
        public string Password { get; set; }

      
        public SubscriptionLevel SubscriptionLevel { get; set; }

        public bool Status { get; set; }


        [Column(TypeName = "date")]
        public DateTime Created { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public IFormFile ProfilePhoto { get; set; }


        [MaxLength(500)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,500}$", ErrorMessage = "Characters are not allowed.")]
        public string Notes { get; set; }
    }
}
