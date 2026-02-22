using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProjectManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Projects
{
    public sealed class BoardId : ValueObject
    {
        private BoardId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; init; }

        public static BoardId Create(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("The id can not be empty.", nameof(id));
            }

            return new BoardId(id);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
