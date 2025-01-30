using AutoMapper;

namespace BillingSystem.Application.Handlers.Base;

public abstract class QueryHandler<TInputCommand, TResponse>
{
    protected readonly IMapper _mapper;

    public QueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public abstract Task<TResponse> Handle(TInputCommand request, CancellationToken cancellationToken);
}
