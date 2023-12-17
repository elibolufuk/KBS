using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Extensions;
using KBS.CreditAppSys.Application.Services.Repositories;
using KBS.CreditAppSys.Domain.Entities;
using KBS.CreditAppSys.Domain.Types;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetList;
public class GetListCreditApplicationQuery : IRequest<ListResponseResult<GetListCreditApplicationQueryResponse>>
{
    public decimal? MinAmount { get; set; }
    public decimal? MaxAmount { get; set; }
    public byte? MinLoanTerm { get; set; }
    public byte? MaxLoanTerm { get; set; }
    public DateTime? MinApplicationDate { get; set; }
    public DateTime? MaxApplicationDate { get; set; }
    public Guid? CustomerId { get; set; }
    public ApplicationResultType? ApplicationResultType { get; set; }

    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;

    public class GetListCreditApplicationQueryHandler(ICreditApplicationRepository creditApplicationRepository, IMapper mapper)
        : IRequestHandler<GetListCreditApplicationQuery, ListResponseResult<GetListCreditApplicationQueryResponse>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository = creditApplicationRepository;
        public async Task<ListResponseResult<GetListCreditApplicationQueryResponse>> Handle(GetListCreditApplicationQuery request, CancellationToken cancellationToken)
        {
            var predicateQuery = GetExpressionByRequest(request);
            static IIncludableQueryable<CreditApplication, object> include(IQueryable<CreditApplication> x)
                => x.Include(y => y.Customer);

            var creditApplication = await _creditApplicationRepository
                .GetListAsync(predicateQuery,
                include: include,
                index: request.PageIndex,
                size: request.PageSize,
                cancellationToken: cancellationToken);

            var response = _mapper.Map<IList<GetListCreditApplicationQueryResponse>>(creditApplication.Items);
            return new()
            {
                Succeeded = true,
                Data = response,
                Paginate = creditApplication
            };
        }
        private static Expression<Func<CreditApplication, bool>> GetExpressionByRequest(GetListCreditApplicationQuery request)
        {
            Expression<Func<CreditApplication, bool>> predicateQuery =
                x => x.EntityStatusType == EntityStatusType.Active;

            #region Amount

            if (request.MinAmount > 0)
                predicateQuery = predicateQuery.And(x => x.Amount >= request.MinAmount);

            if (request.MaxAmount > 0)
                predicateQuery = predicateQuery.And(x => x.Amount <= request.MaxAmount);

            #endregion

            #region LoanTerm

            if (request.MinLoanTerm > 0)
                predicateQuery = predicateQuery.And(x => x.LoanTerm >= request.MinLoanTerm);

            if (request.MaxLoanTerm > 0)
                predicateQuery = predicateQuery.And(x => x.LoanTerm <= request.MaxLoanTerm);

            #endregion

            #region ApplicationDate

            if (request.MinApplicationDate.HasValue)
                predicateQuery = predicateQuery.And(x => x.ApplicationDate >= request.MinApplicationDate);

            if (request.MaxApplicationDate.HasValue)
                predicateQuery = predicateQuery.And(x => x.ApplicationDate <= request.MaxApplicationDate);

            #endregion

            if (request.CustomerId.HasValue)
                predicateQuery = predicateQuery.And(x => x.CustomerId == request.CustomerId);

            if (request.ApplicationResultType.HasValue)
                predicateQuery = predicateQuery.And(x => x.ApplicationResultType == request.ApplicationResultType);

            return predicateQuery;
        }
    }
}
