using Newtonsoft.Json.Linq;
using System;

namespace IdentityManager.Services
{
    internal class MailjetRequest
    {
        public object Resource { get; internal set; }

        internal MailjetRequest Property(object messages, JArray jArray)
        {
            throw new NotImplementedException();
        }

        //internal MailjetRequest Property(object messages, JArray jArray)
        //{
        //    throw new NotImplementedException();
        //}
    }
}