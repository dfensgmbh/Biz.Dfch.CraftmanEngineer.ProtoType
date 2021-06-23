using biz.dfch.CS.Commons;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public partial class MariaDb
    {
        public partial class Variant0
        {
            // ReSharper disable once InconsistentNaming
            public partial class MariaDb_1_0_0
            {
                public MariaDb_1_0_0(ExecutionContext ctx) : base(ctx)
                {
                    Initialise = new InitialiseAction(this);
                    Decommission = new DecommissionAction(this);

                    DescendantsModelRelationship.Add(new DictionaryParameters()
                    {
                        {"VirtualMachine", "Biz.Dfch.CraftmanEngineer.ProtoType.VirtualMachine+Variant0+VirtualMachine_1_0_0"}
                    }, true);
                }

                public override IModelAction Initialise { get; }
                public override IModelAction Decommission { get; }

            }
        }
    }
}
