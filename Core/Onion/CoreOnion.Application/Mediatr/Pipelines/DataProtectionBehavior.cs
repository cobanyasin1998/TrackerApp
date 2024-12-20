using CoreBase.Interfaces.DataProtectInterfaces;
using CoreBase.RequestResponse.Response.Concretes;
using MediatR;
using System.Reflection;

namespace CoreOnion.Application.Mediatr.Pipelines;

public class DataProtectionBehavior<TRequest, TResponse>(IDataProtect _dataProtectService)
   : IPipelineBehavior<TRequest, TResponse>
   where TRequest : IBaseRequest
   where TResponse : class
{
    private const string Id = "Id";
    private const string EncId = "EncId";

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        PropertyInfo[] properties = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            if (property.Name.Equals(EncId, StringComparison.OrdinalIgnoreCase) && property.PropertyType == typeof(string))
            {
                string? currentValue = property.GetValue(request) as string;
                if (!string.IsNullOrEmpty(currentValue))
                {
                    long decryptedValue = _dataProtectService.Decrypt(currentValue);

                    PropertyInfo? decryptedIdProperty = request.GetType().GetProperty(Id);

                    if (decryptedIdProperty is not null && decryptedIdProperty.PropertyType == typeof(long))
                        decryptedIdProperty.SetValue(request, decryptedValue);
                }
            }
        }
        TResponse response = await next();

        dynamic dynamicResponse = response;

        //if (dynamicResponse?.Data is BaseResponse baseResponse)
        //    baseResponse.EncId = _dataProtectService.Encrypt(baseResponse.Id);
        return response;
    }

}
