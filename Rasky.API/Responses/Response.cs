using Newtonsoft.Json;

namespace Rasky.API.Responses
{
    public class ApiResponse<T>
    {
        public T Model{get;set;}
    }
}