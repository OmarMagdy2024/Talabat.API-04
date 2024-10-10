using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Specification;

namespace Talabat.Repository.Specification
{
    internal class SpecificationEvaluator<TEntity> where TEntity : BaseModel
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> Sequence, ISpecification<TEntity> specification)
        {
            var query = Sequence;
            if (specification.Critria != null)
            {
                query = Sequence.Where(specification.Critria);
            }
            query = specification.Includes.Aggregate(query, (Input, outbut) => Input.Include(outbut));
            return query;
        }
    }
}
