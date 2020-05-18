using System.Collections.Generic;
using Rasky.API.ViewModels.Helpers;
namespace Rasky.API.ViewModels {
    public class BaseViewModel {
        public List<Message> Messages = new List<Message> ();
        public List<Message> Errors = new List<Message> ();
        public void AddErrors (List<Message> errors) {
            Errors.AddRange (errors);
        }
        public void AddMessages (List<Message> messages) {
            Messages.AddRange (messages);

        }
    }
}