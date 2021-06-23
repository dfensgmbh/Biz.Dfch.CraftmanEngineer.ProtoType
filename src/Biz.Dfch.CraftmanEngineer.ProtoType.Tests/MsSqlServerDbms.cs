//using System;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Runtime.Serialization;
//using biz.dfch.CS.Commons;
//using Net.Appclusive.Public.Engine;
//// ReSharper disable InconsistentNaming
//// ReSharper disable CheckNamespace

//namespace Com.Example.Its
//{
//    public class MsSqlServerDbms : BaseModel
//    {
//        public class MsSqlServerDbms_1_0_0 : MsSqlServerDbms
//        {
//            public DictionaryParameters InitialiseAttributes { get; set; } = new DictionaryParameters
//            {
//                { "Com.Example.Its.MsSqlServerDb.MsSqlServerDbms.Name", default },
//                { "Com.Example.Its.VirtualMachine.VirtualMachine.CpuCount", default },
//                { "Com.Example.Its.VirtualMachine.VirtualMachine.DiskSizeInGb", 256 },
//            };

//            [AttributeName("Com.Example.Its.MsSqlServerDbms.MsSqlServerDbms.Name")]
//            [Range(1, 1024)]
//            [Required]
//            public string Name { get; set; }

//            [AttributeName("Com.Example.Its.MsSqlServerDbms.MsSqlServerDbms.Description")]
//            [Range(0, 1024)]
//            public string Description { get; set; }

//            [AttributeName("Com.Example.Its.MsSqlServerDbms.MsSqlServerDbms.IsClustered")]
//            [DefaultValue(false)]
//            public string IsClustered { get; set; }
//        }
//    }

//    public class MsSqlServerDb : BaseModel
//    {
//        public class MsSqlServerDb_1_0_0 : MsSqlServerDb
//        {
//            public DictionaryParameters InitialiseAttributes { get; set; } = new DictionaryParameters
//            {
//                { "Com.Example.Its.MsSqlServerDb.MsSqlServerDb.Name", default },
//                { "Com.Example.Its.MsSqlServerDb.MsSqlServerDb.DbSizeInGb", 128 },
//                { "Com.Example.Its.MsSqlServerDb.MsSqlServerDb.LogSizeInGb", default },
//                { "Com.Example.Its.MsSqlServerDb.MsSqlServerDbms.Name", default },
//                { "Com.Example.Its.MsSqlServerDbms.MsSqlServerDbms.IsClustered", false },
//            };

//            [AttributeName("Com.Example.Its.MsSqlServerDb.MsSqlServerDb.Name")]
//            [Range(1, 1024)]
//            [Required]
//            public string Name { get; set; }

//            [AttributeName("Com.Example.Its.MsSqlServerDb.MsSqlServerDb.CpuCount")]
//            [DefaultValue(4)]
//            public int CpuCount { get; set; }

//            [AttributeName("Com.Example.Its.MsSqlServerDb.MsSqlServerDb.DiskSizeGb")]
//            [DefaultValue(128)]
//            public int DiskSizeGb { get; set; }
//        }
//    }

//    public class VirtualMachine : BaseModel
//    {
//        public class VirtualMachine_1_0_0 : VirtualMachine
//        {
//            [AttributeName("Com.Example.Its.VirtualMachine.VirtualMachine.Name")]
//            [Range(1, 1024)]
//            [Required]
//            public string Name { get; set; }

//            [AttributeName("Com.Example.Its.VirtualMachine.VirtualMachine.CpuCount")]
//            [DefaultValue(4)]
//            public int CpuCount { get; set; }

//            [AttributeName("Com.Example.Its.VirtualMachine.VirtualMachine.DiskSizeGb")]
//            [DefaultValue(128)]
//            public int DiskSizeGb { get; set; }

//            #region BoilerPlate
//            private static readonly Lazy<StateMachine> _stateMachine = new Lazy<StateMachine>(() =>
//                StateMachineBuilder
//                    .For<VirtualMachineBehaviourDefinition>()
//                    .InsertAction(() => BaseModelStates.InitialState, typeof(VirtualMachineBehaviourDefinition.SetBaseValue), () => BaseModelStates.DecommissionedState)
//                    .GetStateMachine()
//            );
//            #endregion
//        }
//    }

//    [BehaviourDefinition(typeof(VirtualMachineBehaviourDefinition))]
//    public interface VirtualMachineBehaviour : BaseBehaviour
//    {
//        #region BoilerPlate
//        // intentionally left blank
//        #endregion
//    }

//    [Serializable]
//    [BehaviourDefinitionFor(typeof(VirtualMachineBehaviour))]
//    public class VirtualMachineBehaviourDefinition : BaseModel, VirtualMachineBehaviour
//    {
//        [Range(1, 1024)]
//        [Required]
//        public virtual string Name { get; set; }

//        public class Product3EAction1 : BaseModelAction
//        {
//            [AttributeName("Com.Example.Its.VirtualMachine.VirtualMachine_1_0_0.Name")]
//            [Range(1, 1024)]
//            [Required]
//            public string Name { get; set; }

//            [AttributeName("Com.Example.Its.VirtualMachine.VirtualMachine_1_0_0.CpuCount")]
//            [DefaultValue(4)]
//            public int CpuCount { get; set; }

//            [AttributeName("Com.Example.Its.VirtualMachine.VirtualMachine_1_0_0.DiskSizeGb")]
//            [DefaultValue(128)]
//            public int DiskSizeGb { get; set; }
//        }

//        #region BoilerPlate
//        public VirtualMachineBehaviourDefinition()
//        {
//            // N/A
//        }

//        protected VirtualMachineBehaviourDefinition(SerializationInfo info, StreamingContext context)
//            : base(info, context)
//        {
//            // N/A
//        }

//        public class SetBaseValue : BaseModelAction
//        {
//            [AttributeName("Com.Example.Its.VirtualMachine.BaseValue")]
//            [UseValidationFromModel(typeof(VirtualMachineBehaviourDefinition))]
//            public virtual int BaseValue { get; set; }
//        }
//        #endregion
//    }
//}
