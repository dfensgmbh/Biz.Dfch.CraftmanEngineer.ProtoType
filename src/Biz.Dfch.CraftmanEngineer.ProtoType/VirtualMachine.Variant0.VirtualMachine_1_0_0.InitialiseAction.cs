using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Reflection;
using biz.dfch.CS.Commons;
using biz.dfch.CS.Commons.Validation;
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
                public class InitialiseAction : ModelActionBase
                {
                    public InitialiseAction(ModelBase modelBase) : base(modelBase) { }

                    public override DictionaryParameters Invoke(DictionaryParameters parameters)
                    {
                        Contract.Assert(null != parameters);
                        Contract.Ensures(null != Contract.Result<DictionaryParameters>());

                        var param = AttributeConverter.Convert<InitialiseActionParameters>(parameters);
                        Contract.Assert(param.IsValid(), string.Join("; ", param.GetErrorMessages()));

                        // do something meaningful with these parameters ...

                        var initialiseActionResult = AttributeConverter.Convert<InitialiseActionResult>(parameters);
                        initialiseActionResult.Guid = Guid.NewGuid().ToString("B");
                        initialiseActionResult.MagicKey = "This text has been created at " + DateTimeOffset.Now.ToString("u");

                        var result = AttributeConverter.Convert(initialiseActionResult);
                        return result;
                    }
                }

                public class InitialiseActionParameters : AttributeBaseDto
                {
                    [Required]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(Name))]
                    [StringLength(32)]
                    public string Name { get; set; }

                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(Description))]
                    [StringLength(1024)]
                    public string Description { get; set; }

                    [ValidateSetIfNotDefault("4", "8", "32")]
                    [DefaultValue("8")]
                    [Unit("CPU")]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(CpuCount))]
                    public string CpuCount { get; set; }

                    [ValidateSetIfNotDefault("16", "32", "128")]
                    [Unit("GB")]
                    [DefaultValue("32")]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(MemoryInGb))]
                    public string MemoryInGb { get; set; }

                    [Range(128, 2048)]
                    [Unit("GB")]
                    [DefaultValue("128")]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(DiskInGb))]
                    public string DiskInGb { get; set; }
                }

                public class InitialiseActionResult : InitialiseActionParameters
                {
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(MagicKey))]
                    [StringLength(1024)]
                    public string MagicKey { get; set; }

                    [Required]
                    [AttributeName(prefix + plus + nameof(Variant0) + plus + nameof(VirtualMachine_1_0_0) + dot + nameof(Guid))]
                    [StringLength(1024)]
                    public string Guid { get; set; }
                }
            }
        }
    }
}
