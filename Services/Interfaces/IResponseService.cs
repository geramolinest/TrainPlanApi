using TrainPlanApi.Domain.Common;

namespace TrainPlanApi.Services.Interfaces;

public interface IResponseService<T> where T :  class
{
    BaseResponse<T> OkResponse(string message = "", T data = null);
    BaseResponse<T> CreatedResponse(string message = "", T data = null);
    BaseResponse<T> BadRequestResponse(string message = "", T data = null);
    BaseResponse<T> NotFoundResponse(string message = "", T data = null);
    BaseResponse<T> UnauthorizedResponse(string message = "", T data = null);
    BaseResponse<T> ForbbidenResponse(string message = "", T data = null);
    BaseResponse<T> InternalServerErrorResponse(string message = "", T data = null);
}
