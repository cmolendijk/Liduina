using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Liduina.Backend.Data.Repositories
{
    internal static class EfUpdateProperties
    {
        public static TOrig UpdateProperties<TOrig, TDto>(this TOrig original, TDto dto)
        {
            var origProps = typeof(TOrig).GetProperties();
            var dtoProps = typeof(TDto).GetProperties();

            foreach (var dtoProp in dtoProps)
            {
                origProps
                    .Single(origProp => origProp.Name == dtoProp.Name)
                    .SetMethod.Invoke(original, new[] { dtoProp.GetMethod.Invoke(dto, null) });
            }
            return original;
        }
    }
}
