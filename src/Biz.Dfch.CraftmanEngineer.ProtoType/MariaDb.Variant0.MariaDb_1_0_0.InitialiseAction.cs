using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.ComTypes;
using biz.dfch.CS.Commons;
using biz.dfch.CS.Commons.Collections;
using biz.dfch.CS.Commons.Linq;
using biz.dfch.CS.Commons.Validation;
using Net.Appclusive.Public.Engine;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public partial class MariaDb
    {
        public partial class Variant0
        {
            // ReSharper disable once InconsistentNaming
            public partial class MariaDb_1_0_0 : ModelBase
            {

                public class InitialiseAction : ModelActionBase
                {
                    public InitialiseAction(ModelBase modelBase) : base(modelBase) { }

                    public override DictionaryParameters Invoke(DictionaryParameters parameters)
                    {
                        Contract.Assert(null != parameters);
                        Contract.Ensures(null != Contract.Result<DictionaryParameters>());

                        var param = AttributeConverter.Convert<InitialiseActionParameters>(parameters);
                        Contract.Assert(param.IsValid(), string.Join("; ", param.GetErrorMessages()));

                        var ctx = new ExecutionParameters()
                        {
                            ModelName = ModelBase.DescendantsModelRelationship["VirtualMachine"].ToString(),
                            ModelAction = nameof(InitialiseAction),
                        };
                        parameters.Add
                        (
                            "Biz.Dfch.CraftmanEngineer.ProtoType.VirtualMachine+Variant0+VirtualMachine_1_0_0.Name",
                            "arbitraryVirtualMachineName"
                        );
                        var resultFromVirtualMachine = ModelBase.Ctx.Invoke(ctx, parameters);

                        var merged = resultFromVirtualMachine.Merge(parameters, MergeOptions.OverwriteRight);
                        var result = new DictionaryParameters();
                        merged.ForEach(pair =>
                        {
                            result.Add(pair.Key, pair.Value);
                        });
                        return result;
                    }
                }

                public class InitialiseActionParameters : AttributeBaseDto
                {
                    [Required]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(MariaDb_1_0_0) + dot + nameof(Name))]
                    [StringLength(32)]
                    public string Name { get; set; }

                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(MariaDb_1_0_0) + dot + nameof(Description))]
                    [StringLength(1024)]
                    public string Description { get; set; }

                    [Range(128, 2048)]
                    [Unit("GB")]
                    [DefaultValue("256")]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(MariaDb_1_0_0) + dot + nameof(DatabaseInGb))]
                    public string DatabaseInGb { get; set; }

                    [Range(128, 2048)]
                    [Unit("GB")]
                    [DefaultValue("128")]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(MariaDb_1_0_0) + dot + nameof(LogInGb))]
                    public string LogInGb { get; set; }

                    [ValidateSetIfNotDefault("4", "8", "32")]
                    [DefaultValue("8")]
                    [Unit("CPU")]
                    [AttributeName("Biz.Dfch.CraftmanEngineer.ProtoType.VirtualMachine+Variant0+VirtualMachine_1_0_0.CpuCount")]
                    public string CpuCount { get; set; }
                }
            }
        }
    }
}