namespace Rasky.API.ViewModels.Helpers{
    public class Message{
        public Message(string Identifier){
            this.Identifier=Identifier;
        }
        public Message(string Identifier,string Description)
        {
            this.Description=Description;
            this.Identifier=Identifier;
        }
        public string Identifier{get;set;}
        public string Description{get;set;}
    }
}