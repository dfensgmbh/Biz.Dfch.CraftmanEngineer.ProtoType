using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using biz.dfch.CS.Commons;
using Net.Appclusive.Public.Engine;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public partial class VirtualMachine
    {
        public partial class Variant0
        {
            // ReSharper disable once InconsistentNaming
            public partial class VirtualMachine_1_0_0
            {
                public class DecommissionAction : ModelActionBase
                {
                    public DecommissionAction(ModelBase modelBase) : base(modelBase) { }

                    public override DictionaryParameters Invoke(DictionaryParameters parameters)
                    {
                        Contract.Assert(null != parameters);
                        var input = AttributeConverter.Convert<DecommissionActionParameters>(parameters);
                        Contract.Assert(input.IsValid());

                        parameters.Add("arbitraryName", 42);
                        return parameters;
                    }
                }

                public class DecommissionActionParameters : AttributeBaseDto
                {
                    [Required]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(Ci))]
                    public string Ci { get; set; }
                }
            }
        }
    }
}
