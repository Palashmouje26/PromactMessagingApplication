using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PromactMessagingApp.DomainModel.ApplicationClasses
{
    public class StatusAC
    {
        public StatusAC(int code = StatusCodes.Status400BadRequest) 
        {
            StatusCode = code;
        }

        [JsonIgnore]
        public int StatusCode { get; set; }

        [JsonIgnore]
        public string StatusMessage { get; set; }

    }
}
