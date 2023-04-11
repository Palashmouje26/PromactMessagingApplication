using System;
using System.Collections.Generic;
using System.Text;

namespace PromactMessagingApp.DomainModel.ApplicationClasses.LoginAC
{
    public class LoginAC
    {
        public int LoginId { get; set; }

        public Guid Id { get; set; }

        public DateTime LoginHistory { get; set; }

        public bool IsValidate { get; set; }
    }
}
