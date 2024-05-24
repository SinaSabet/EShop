using Newtonsoft.Json;

namespace EShop.Api.Model
{
    public class Response
    {
        public Response()
        {
        }

        public Response(string message)
        {
            Succeeded = false;
            Message = message;

        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Response<T> : Response
    {
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public T Data { get; set; }

    }
}
