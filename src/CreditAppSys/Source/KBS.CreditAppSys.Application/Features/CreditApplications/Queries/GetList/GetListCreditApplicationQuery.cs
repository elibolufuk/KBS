using MediatR;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetList;

public class GetListCreditApplicationQuery : IRequest<GetListCreditApplicationQueryResponse>
{
    public class GetListCreditApplicationQueryHandler : IRequestHandler<GetListCreditApplicationQuery, GetListCreditApplicationQueryResponse>
    {
        public Task<GetListCreditApplicationQueryResponse> Handle(GetListCreditApplicationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
