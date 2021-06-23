/**
 * Copyright 2017 d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using biz.dfch.CS.Commons;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public class TypeResolver : ITypeResolver
    {
        private const string APPLICATION_NAMESPACE = "Biz.Dfch.CraftmanEngineer.ProtoType.";

        private static readonly Func<TypeInfo, bool> _isInNamespace = e => e.FullName.StartsWith(APPLICATION_NAMESPACE);

        private static readonly Lazy<IQueryable<Type>> _types = new Lazy<IQueryable<Type>>(() =>
        {
            var types = Assembly.GetExecutingAssembly().DefinedTypes.Where(_isInNamespace).ToList();
            types.AddRange(Assembly.GetCallingAssembly().DefinedTypes.Where(_isInNamespace));

            var entryAssembly = Assembly.GetEntryAssembly();
            if (null != entryAssembly)
            {
                types.AddRange(entryAssembly.DefinedTypes.Where(_isInNamespace));
            }

            types.AddRange(typeof(BaseDto).Assembly.DefinedTypes.Where(e => e.IsPublic));
            types.AddRange(typeof(TypeResolver).Assembly.DefinedTypes.Where(_isInNamespace));

            var frames = new StackTrace().GetFrames();
            if (null != frames)
            {
                foreach (var stackFrame in frames)
                {
                    var assembly = stackFrame.GetMethod().Module.Assembly;
                    types.AddRange(assembly.DefinedTypes.Where(_isInNamespace));
                }
            }

            return types.Distinct().ToList().AsQueryable();
        });

        public virtual IQueryable<Type> Types => _types.Value;

        public virtual IQueryable<Type> Where()
        {
            return Types;
        }

        public virtual IQueryable<Type> Where(Expression<Func<Type, bool>> predicate)
        {
            return Types.Where(predicate);
        }

        public virtual Type FirstOrDefault()
        {
            return Types.FirstOrDefault();
        }

        public virtual Type FirstOrDefault(Expression<Func<Type, bool>> predicate)
        {
            return Types.FirstOrDefault(predicate);
        }
    }
}
