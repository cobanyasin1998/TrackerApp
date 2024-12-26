using CoreBase.Dto.Core.EncryptedDto;
using CoreBase.Interfaces.DataProtectInterfaces;
using MediatR;
using System.Reflection;

namespace CoreOnion.Application.Mediatr.Pipelines;

public class DataProtectionBehavior<TRequest, TResponse>(IDataProtect _dataProtectService)
   : IPipelineBehavior<TRequest, TResponse>
   where TRequest : IBaseRequest
   where TResponse : class
{
    private const String Id = "Id";
    private const String EncId = "EncId";

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        PropertyInfo[] properties = request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo property in properties)
        {
            if (property.Name.Equals(EncId, StringComparison.OrdinalIgnoreCase) && property.PropertyType == typeof(String))
            {
                String? currentValue = property.GetValue(request) as String;
                if (!String.IsNullOrEmpty(currentValue))
                {
                    Int64 decryptedValue = _dataProtectService.Decrypt(currentValue);

                    PropertyInfo? decryptedIdProperty = request.GetType().GetProperty(Id);

                    if (decryptedIdProperty is not null && decryptedIdProperty.PropertyType == typeof(Int64))
                        decryptedIdProperty.SetValue(request, decryptedValue);
                }
            }
        }
        TResponse response = await next();

        dynamic dynamicResponse = response;

        if (dynamicResponse?.Data is EncryptedResponseDto encryptedResponseDto)
            encryptedResponseDto.EncId = _dataProtectService.Encrypt(encryptedResponseDto.Id);
        return response;
    }

}
