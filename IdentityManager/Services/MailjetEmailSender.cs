using MailJet.Client;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IdentityManager.Services
{

    //public class MailjetEmailSender : IEmailSender
    //{
    //    private readonly IConfiguration _configuracion;

    //    public MailjetOption mailJetOptions;
    //    public MailjetEmailSender(IConfiguration configuration)
    //    {
    //        _configuracion = configuration;
    //    }
    //    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        mailJetOptions = _configuracion.GetSection("Mailjet").Get<MailjetOption>();

    //        MailJetClient client = new MailJetClient(mailJetOptions.Apikey, mailJetOptions.SecretKey)
    //        {
    //            //Version = ApiVersion.V3_1,
    //        };
    //        Property(Send.Messages, new JArray {
    // new JObject {
    //  {
    //   "From",
    //   new JObject {
    //    {"Email", "bessysu@proton.me"},
    //    {"Name", "Carol"}
    //   }
    //  }, {
    //   "To",
    //   new JArray {
    //    new JObject {
    //     {
    //      "Email",
    //      "bessysu@proton.me"
    //     }, {
    //      "Name",
    //      "Carol"
    //     }
    //    }
    //   }
    //  }, {
    //   "Subject",
    //    subject
    //  },  {
    //   "HTMLPart",
    //   "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
    //  }, {
    //   "CustomID",
    //   "AppGettingStartedTest"
    //  }
    // }
    //         });
    //        MailjetRequest request = new()
    //        {
    //            Resource = Send.Resource,
    //        };

    //        //await client.PostAsync(request);
    //        //if (response.IsSuccessStatusCode)
    //        //{
    //        //    Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
    //        //    Console.WriteLine(response.GetData());
    //        //}
    //        //else
    //        //{
    //        //    Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
    //        //    Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
    //        //    Console.WriteLine(response.GetData());
    //        //    Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
    //        //}
    //    }

    //    private void Property(object messages, JArray jArray)
    //    {
    //        throw new NotImplementedException();
    //    }
    }

//    internal class Send
//    {
//        internal static object Messages;
//        internal static object Resource;
//    }
//}
    

    

