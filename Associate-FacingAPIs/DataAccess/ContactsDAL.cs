using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using Associate_FacingAPIs.Interfaces;
using Associate_FacingAPIs.BusinessObjects;
using System.IO;
using Newtonsoft.Json;

namespace Associate_FacingAPIs.DAL
{
    public class ContactsDAL : IContactsDAL
    {
        Dictionary<string, string> _WhiteList = new Dictionary<string, string>();
        Dictionary<string, string> _InternalList = new Dictionary<string, string>();
        Dictionary<string, string> _NationalList = new Dictionary<string, string>();
        public ContactsDAL()
        {
            LoadJson();
        }
        public void LoadJson()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"Datastore\\"}");
            using (StreamReader r = new StreamReader(folderDetails + "WhiteList.json"))
            {
                string json = r.ReadToEnd();
                JsonConvert.DeserializeObject<List<WhiteList>>(json).ForEach(c =>
                {
                    if (!_WhiteList.ContainsKey(c.PhoneNo))
                    {
                        _WhiteList.Add(c.PhoneNo, Helpers.HelperFunctions.GetAttribute<DisplayAttribute>(Helpers.HelperFunctions.contacttype.Active).ToString());
                    }
                });
            }
            using (StreamReader r = new StreamReader(folderDetails + "NationalList.json"))
            {
                string json = r.ReadToEnd();
                JsonConvert.DeserializeObject<List<NationalList>>(json).ForEach(c =>
                {
                    if (!_NationalList.ContainsKey(c.PhoneNo))
                    {
                        _NationalList.Add(c.PhoneNo, Helpers.HelperFunctions.contacttype.National.ToString());
                    }
                });
            }
            using (StreamReader r = new StreamReader(folderDetails + "InternalList.json"))
            {
                string json = r.ReadToEnd();
                JsonConvert.DeserializeObject<List<InternalList>>(json).ForEach(c =>
                {
                    if (!_InternalList.ContainsKey(c.PhoneNo))
                    {
                        _InternalList.Add(c.PhoneNo, Helpers.HelperFunctions.contacttype.Internal.ToString());
                    }
                });
            }
        }
        public async Task<Dictionary<string, string>> GetContacts(string source, string phoneNumber)
        {
            return await Task.FromResult(_WhiteList.Concat(_NationalList).Concat(_InternalList)
                .Where(c => c.Key.Contains(phoneNumber) && c.Value.ToLower().Contains(source.ToLower()))
                .ToDictionary(d => d.Key, d => d.Value));
        }
    }
}