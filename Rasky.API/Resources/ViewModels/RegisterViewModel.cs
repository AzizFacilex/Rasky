using System.Collections.Generic;

using System.Linq;
namespace Rasky.API.ViewModels {
    public class RegisterViewModel:BaseViewModel {
        public string email{get;set;}
        public Dictionary<string,string> emailGroup { get; set; }
        public string username { get; set;}
        public Dictionary<string,string> passwordGroup { get; set; }
        public Dictionary<string,string> nameGroup { get; set; }
        public string location { get; set; }
        public string phoneNumber{get;set;}
    }
}