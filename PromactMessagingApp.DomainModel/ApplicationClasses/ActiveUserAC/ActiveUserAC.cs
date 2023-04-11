using System;
using System.Collections.Generic;
using System.Text;

namespace PromactMessagingApp.DomainModel.ApplicationClasses.ActiveUserAC
{
    public class ActiveUserAC
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public bool Status { get; set; }
    }
}
