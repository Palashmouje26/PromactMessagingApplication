using System;
using System.Collections.Generic;
using System.Text;

namespace PromactMessagingApp.DomainModel.ApplicationClasses.LoginAC
{
    public class LoginAC
    {
        public int LoginId { get; set; }

        public string Id { get; set; }

        public string LoginHistory { get; set; }

        public bool IsValidate { get; set; }
    }
}
