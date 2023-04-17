using System;
using System.Collections.Generic;
using System.Text;

namespace PromactMessagingApp.DomainModel.ApplicationClasses.LoginAC
{
    public class LoginAC
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string LoginDate  { get; set; }

        public bool IsValidate { get; set; }
    }
}
