using MediatR;

namespace FullstackAfiliados.Application.UseCases.Base.Handlers;

public interface IBaseHandler<in TReq, TResp> : IRequestHandler<TReq, TResp> where TReq : IRequest<TResp>
{
    Task<TResp> Handle(TReq request, CancellationToken cancellationToken);
}