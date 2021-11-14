using BaseballHistory.Domain.Filters;

namespace BaseballHistory.Domain.Services;

public interface IUriService
{
    public Uri GetPageUri(PaginationFilter filter, string route);
}