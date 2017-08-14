using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Facebook.Quiz.Webhook.Controllers
{
    public class FacebookController : ApiController
    {
        [HttpGet]
        public string HubChallenge([FromUri(Name = "hub.mode")]string mode, [FromUri(Name = "hub.challenge")]string challenge, [FromUri(Name = "hub.verify_token")]string token)
        {
            return challenge;
        }

    }
}
