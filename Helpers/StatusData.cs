using System.Net;

namespace desafio.Helpers
{
    public class StatusData
    {
        public StatusData(HttpStatusCode httpStatusCode, object data)
         => (HttpStatusCode, Data) = (httpStatusCode, data);
        public StatusData(HttpStatusCode httpStatusCode)
         => (HttpStatusCode) = (httpStatusCode);

        public HttpStatusCode HttpStatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
    }
}