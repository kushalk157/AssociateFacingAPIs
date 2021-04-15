using System.Threading.Tasks;
using System.Collections.Generic;


namespace Associate_FacingAPIs.Interfaces
{
    public interface IContactsDAL
    {
        Task<Dictionary<string,string>> GetContacts(string source, string phoneNumber);
    }
}