namespace BaseballHistory.Domain.Wrappers;

public class Response<T>
{
    public Response()
    {
    }
    public Response(T data)
    {
        Succeeded = true;
        Message = string.Empty;
        Data = data;
    }
    public T Data { get; set; }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
}