using Associate_FacingAPIs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Associate_FacingAPIs.BusinessLogic
{
    public class ContactsBL : IContactsBL
    {
        private readonly IContactsDAL _cDal;

        public ContactsBL(IContactsDAL contactsDAL)
        {
            _cDal = contactsDAL;
        }

        public async Task<Dictionary<string, string>> GetContacts(string source, string phoneNumber)
        {           
            if (source == null)
                source = string.Empty;
            if (phoneNumber == null)
                phoneNumber = string.Empty;
            if(!Regex.IsMatch("^[0-9]", phoneNumber))
                throw new InvalidOperationException("Not a valid phone number!");
            return await _cDal.GetContacts(source, phoneNumber);
        }
    }
}
