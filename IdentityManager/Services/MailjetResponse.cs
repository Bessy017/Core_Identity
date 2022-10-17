using System;

namespace IdentityManager.Services
{
    internal class MailjetResponse
    {
        internal readonly string StatusCode;
        internal bool IsSuccessStatusCode;

        internal bool GetData()
        {
            throw new NotImplementedException();
        }

        internal string GetTotal()
        {
            throw new NotImplementedException();
        }

        internal string GetErrorInfo()
        {
            throw new NotImplementedException();
        }

        internal string GetErrorMessage()
        {
            throw new NotImplementedException();
        }

        internal object GetCount()
        {
            throw new NotImplementedException();
        }
    }
}