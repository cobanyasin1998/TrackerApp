﻿using AutoMapper;
using CoreBase.Consts.General;
using CoreBase.Dto.Core.CoreResponse;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Constants;
using MediatR;

namespace Identity.Application.Features.User.Queries.GetById;

public class GetByIdUserQueryHandler(IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<GetByIdUserQueryRequest, Result<GetByIdUserQueryResponse>>
{
    public async Task<Result<GetByIdUserQueryResponse>> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        // Veriyi veritabanından al
        var user = await _unitOfWork.UserReadRepository.FirstOrDefaultAsync(
            predicate: u => u.Id == request.Id,
            cancellationToken: cancellationToken);

        // Kullanıcı bulunamazsa not found döndür
        if (user is null)
            return Result<GetByIdUserQueryResponse>.NotFoundRecord(UserConstants.NotFound);

        // User -> Response Mapping
        var response = _mapper.Map<GetByIdUserQueryResponse>(user);

        return Result<GetByIdUserQueryResponse>.Success(response, GeneralOperationConsts.OperationSuccessfull);
    }
}
