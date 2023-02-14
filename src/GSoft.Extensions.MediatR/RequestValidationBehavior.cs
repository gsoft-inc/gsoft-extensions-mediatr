using MediatR;

namespace GSoft.Extensions.MediatR;

internal sealed class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        DataAnnotationsValidationHelper.Validate(request);
        return next();
    }
}