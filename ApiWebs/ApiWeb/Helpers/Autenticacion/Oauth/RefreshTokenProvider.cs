using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Infrastructure;

namespace ApiWeb.Helpers.Autenticacion.Oauth
{

    public class RefreshTokenProvider : AuthenticationTokenProvider
    {
        public override void Create(AuthenticationTokenCreateContext context)
        {
            var value = KeysConfiguration.KeyRefreshTokenExpireHours;
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(value));
            context.SetToken(context.SerializeTicket());
        }

        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}