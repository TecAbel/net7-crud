
namespace WebAPICRUD.Responses;

public class BaseResponse<T>
{
    public String Message { get; set; }
    public T Data { get; set; }
}
