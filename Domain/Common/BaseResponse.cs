using System;

namespace TrainPlanApi.Domain.Common;

public class BaseResponse<T> where T : class
{
    public int StatusCode { get; set; }
    public string StatusText { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
