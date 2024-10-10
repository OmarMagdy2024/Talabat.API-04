using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;

namespace Talabat.Core.Specification
{
    public class Specification<T> : ISpecification<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> Critria { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public Specification()
        {
            
        }
        public Specification(Expression<Func<T, bool>> Critriaexpression)
        {
            Critria= Critriaexpression;
        }
    }
}
