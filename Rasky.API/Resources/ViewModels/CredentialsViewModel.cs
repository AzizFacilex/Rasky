using System.Collections.Generic;
using Newtonsoft.Json;
using Rasky.API.ViewModels.Helpers;
using Rasky.API.ViewModels.Validations;
namespace Rasky.API.ViewModels {

    public class CredentialsViewModel : BaseViewModel{
        public string UserName { get; set; }
        public string Password { get; set; }
        public dynamic Jwt{get;set;}
       
    }
}