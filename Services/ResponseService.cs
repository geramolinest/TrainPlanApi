using System;
using TrainPlanApi.Domain.Common;
using TrainPlanApi.Services.Interfaces;

namespace TrainPlanApi.Services;

public class ResponseService<T> : IResponseService<T> where T : class
{
    public BaseResponse<T> BadRequestResponse(string message = "", T data = null)
    {
        return new BaseResponse<T>()
        {
            StatusCode = 400,
            StatusText = "BAD_REQUEST",
            Message = string.IsNullOrEmpty(message) ? "Bad request, check your data" : message,
            Data = data
        };
    }

    public BaseResponse<T> CreatedResponse(string message = "", T data = null)
    {
        return new BaseResponse<T>()
        {
            StatusCode = 201,
            StatusText = "CREATED",
            Message = string.IsNullOrEmpty(message) ? "Resource created successfully" : message,
            Data = data
        };
    }

    public BaseResponse<T> ForbbidenResponse(string message = "", T data = null)
    {
        return new BaseResponse<T>()
        {
            StatusCode = 403,
            StatusText = "FORBBIDEN",
            Message = string.IsNullOrEmpty(message) ? "You do not have enough access, contact an administrator" : message,
            Data = data
        };
    }

    public BaseResponse<T> InternalServerErrorResponse(string message = "", T data = null)
    {
        return new BaseResponse<T>()
        {
            StatusCode = 500,
            StatusText = "INTERNAL_SERVER_ERROR",
            Message = string.IsNullOrEmpty(message) ? "Internal server error, contact an administrator" : message,
            Data = data
        };
    }

    public BaseResponse<T> NotFoundResponse(string message = "", T data = null)
    {
        return new BaseResponse<T>()
        {
            StatusCode = 404,
            StatusText = "NOT_FOUND",
            Message = string.IsNullOrEmpty(message) ? "Resource does not exists" : message,
            Data = data
        };
    }

    public BaseResponse<T> OkResponse(string message = "", T data = null)
    {
        return new BaseResponse<T>()
        {
            StatusCode = 200,
            StatusText = "OK_STATUS",
            Message = string.IsNullOrEmpty(message) ? "Action performed successfully" : message,
            Data = data
        };
    }

    public BaseResponse<T> UnauthorizedResponse(string message = "", T data = null)
    {
        return new BaseResponse<T>()
        {
            StatusCode = 401,
            StatusText = "UNAUTHORIZED",
            Message = string.IsNullOrEmpty(message) ? "You are not authorized to perform this action" : message,
            Data = data
        };
    }
}
