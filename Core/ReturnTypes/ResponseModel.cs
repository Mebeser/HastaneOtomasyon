using System.Net;

namespace HastaneOtomasyon.Core.ReturnTypes;

public class ResponseModel
{
    
    public string? Message { get; set; }
    public bool Success { get; set; }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    
    public class ResponseDataModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}