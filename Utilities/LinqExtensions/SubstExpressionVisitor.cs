using System.Collections.Generic;
using System.Linq.Expressions;

namespace Utilities.LinqExtensions
{
    internal class SubstExpressionVisitor : ExpressionVisitor
    {
        public Dictionary<Expression, Expression> Subst = new Dictionary<Expression, Expression>();

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (Subst.TryGetValue(node, out Expression newValue))
            {
                return newValue;
            }
            return node;
        }
    }
}