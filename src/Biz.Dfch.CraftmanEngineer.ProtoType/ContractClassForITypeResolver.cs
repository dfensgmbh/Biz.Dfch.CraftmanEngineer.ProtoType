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
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    [ContractClassFor(typeof(ITypeResolver))]
    public abstract class ContractClassForITypeResolver : ITypeResolver
    {
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public IQueryable<Type> Types { get; }

        public IQueryable<Type> Where(Expression<Func<Type, bool>> predicate)
        {
            Contract.Requires(null != predicate);
            Contract.Ensures(null != Contract.Result<IQueryable<Type>>());

            return default(IQueryable<Type>);
        }

        public Type FirstOrDefault()
        {
            return default(Type);
        }

        public Type FirstOrDefault(Expression<Func<Type, bool>> predicate)
        {
            Contract.Requires(null != predicate);

            return default(Type);
        }
    }
}