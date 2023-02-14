using MediatR;

namespace GSoft.Extensions.MediatR;

internal sealed class StreamRequestValidationBehavior<TRequest, TResponse> : IStreamPipelineBehavior<TRequest, TResponse>
    where TRequest : IStreamRequest<TResponse>
{
    public IAsyncEnumerable<TResponse> Handle(TRequest request, StreamHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        DataAnnotationsValidationHelper.Validate(request);
        return next();
    }
}