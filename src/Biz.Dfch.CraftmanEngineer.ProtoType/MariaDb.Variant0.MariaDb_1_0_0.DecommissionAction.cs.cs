using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using biz.dfch.CS.Commons;
using biz.dfch.CS.Commons.Validation;
using Net.Appclusive.Public.Engine;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public partial class MariaDb
    {
        public partial class Variant0
        {
            // ReSharper disable once InconsistentNaming
            public partial class MariaDb_1_0_0
            {
                public class DecommissionAction : ModelActionBase
                {
                    public DecommissionAction(ModelBase modelBase) : base(modelBase) { }

                    public override DictionaryParameters Invoke(DictionaryParameters parameters)
                    {
                        Contract.Assert(null != parameters);
                        var input = AttributeConverter.Convert<DecommissionActionParameters>(parameters);
                        Contract.Assert(input.IsValid());

                        var ctx = new ExecutionParameters()
                        {
                            ModelName = "Biz.Dfch.CraftmanEngineer.ProtoType.VirtualMachine+Variant0+VirtualMachine_1_0_0",
                            ModelAction = "DecommissionAction"
                        };

                        return ModelBase.Ctx.Invoke(ctx, parameters);
                    }
                }

                public class DecommissionActionParameters : AttributeBaseDto
                {
                    [Required]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(MariaDb_1_0_0) + dot + nameof(Ci))]
                    public string Ci { get; set; }
                }
            }
        }
    }
}