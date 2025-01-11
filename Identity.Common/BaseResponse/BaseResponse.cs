namespace Identity.Common.BaseResponse;
public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public double Version { get; set; }
    public string Message { get; set; }
    public T ResponseData { get; set; }
    public List<Errors> Errors { get; set; }
    public int StatusCode { get; set; }

    public BaseResponse()
    {

    }
    public BaseResponse(List<Errors> errors, string message, T responseData = default)
    {
        Errors = errors;
        IsSuccess = false;
        Message = message;
        ResponseData = responseData;
        Version = 1.0;
    }
    public BaseResponse(string message, List<Errors> errors, T responseData = default)
    {
        Errors = errors;
        IsSuccess = false;
        Message = message;
        ResponseData = responseData;
        Version = 1.0;
    }
    public BaseResponse(bool isSuccess, T responseData, double version, List<Errors> errors, string message)
    {
        IsSuccess = isSuccess;
        ResponseData = responseData;
        Version = version;
        Errors = errors;
        Message = message;
    }

    public BaseResponse(T Data, string message, T responseData, List<Errors> errors)
    {
        ResponseData = Data;
        Message = message;
        Version = 1.0;
        IsSuccess = true;
        Errors = new List<Errors>();
    }

}
public class GetMessage
{
    public string Message { get; set; }
    public GetMessage(string message)
    {
        Message = message;
    }
}
public class Errors
{
    public int Key { get; set; }
    public string Value { get; set; }
}

public class SuccessResponse<T> : BaseResponse<T>
{
    public SuccessResponse(string message, T responseData) : base(null, message, responseData)
    {

    }
}


public class FailedResponse<T> : BaseResponse<T>
{
    public FailedResponse(string message, List<Errors> errors) : base(errors, message)
    {

    }
    public FailedResponse(string message) : base(null, message)
    {

    }
}