using biz.dfch.CS.Commons;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public partial class VirtualMachine
    {
        public partial class Variant0
        {
            // ReSharper disable once InconsistentNaming
            public partial class VirtualMachine_1_0_0 : ModelBase
            {
                public VirtualMachine_1_0_0(ExecutionContext ctx) : base(ctx)
                {
                    Initialise = new InitialiseAction(this);
                    Decommission = new DecommissionAction(this);
                }

                public override IModelAction Initialise { get; }
                public override IModelAction Decommission { get; }
            }
        }
    }
}
