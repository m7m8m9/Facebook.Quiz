using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Facebook.Quiz.Webhook.Controllers
{   
    [RoutePrefix("gateway")]
    public class FacebookController : ApiController
    {
        [HttpGet]
        [Route("challenge")]
        public long HubChallenge([FromUri(Name = "hub.mode")]string mode, [FromUri(Name = "hub.challenge")]long challenge, [FromUri(Name = "hub.verify_token")]string token)
        {
            return challenge;
        }
    }
}
