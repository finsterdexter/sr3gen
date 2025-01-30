using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Database.Queries
{
    public interface IQuery<TResult>
    {
    }

    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, IDbConnection dbConnection, IDbTransaction dbTransaction);
    }
}
