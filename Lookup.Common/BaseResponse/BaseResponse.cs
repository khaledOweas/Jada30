namespace Lookup.Common.BaseResponse;
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
    // For Success
    public BaseResponse(string message, T responseData = default)
    {
        Message = message;
        ResponseData = responseData;

        Errors = null;
        IsSuccess = true;
        Version = 1.0;
    }
    // for error
    public BaseResponse(string message, List<Errors> errors)
    {
        Errors = errors;
        Message = message;

        ResponseData = default;
        IsSuccess = false;
        Version = 1.0;
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
    public SuccessResponse(string message, T responseData) : base(message, responseData)
    {

    }
}


public class FailedResponse<T> : BaseResponse<T>
{
    public FailedResponse(string message, List<Errors> errors) : base(message, errors)
    {

    }
    public FailedResponse(string message) : base(message, null)
    {

    }
}