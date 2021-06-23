using System;
using System.Diagnostics.Contracts;
using biz.dfch.CS.Commons;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public abstract class ModelBase : IModelBase
    {
        public readonly ExecutionContext Ctx;
        public ModelRelationship DescendantsModelRelationship { get; } = new ModelRelationship();

        protected ModelBase(ExecutionContext ctx)
        {
            Contract.Assert(null != ctx);
            Ctx = ctx;
        }

        public abstract IModelAction Initialise { get; }
        public abstract IModelAction Decommission { get; }
    }
}