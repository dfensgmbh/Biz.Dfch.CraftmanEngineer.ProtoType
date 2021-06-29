/**
 * Copyright 2021 d-fens GmbH
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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Appclusive.Public.Engine;

namespace Biz.Dfch.CraftmanEngineer.ProtoType.Tests
{
    [TestClass]
    public class ExecutionContextTest
    {
        private readonly MariaDb.Variant0.MariaDb_1_0_0.InitialiseActionParameters testMariaDbInitialiseActionParameters = new MariaDb.Variant0.MariaDb_1_0_0.InitialiseActionParameters
        {
            Name = "arbitaryDbName",
            Description = "arbitraryDescription",
            LogInGb = 256.ToString(),
            DatabaseInGb = 256.ToString(),
            CpuCount = 32.ToString(),
        };

        private readonly VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters testVirtualMachineInitialiseActionParameters = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
        {
            Name = "arbitaryDbName",
            Description = "arbitraryDescription",
            DiskInGb = 256.ToString(),
            MemoryInGb = 128.ToString(),
            CpuCount = 32.ToString(),
        };

        private readonly string magicKey = "MagicKey";

        [TestMethod]
        public void InvokeMariaDbViaSimplifiedMethodParametersSucceeds()
        {
            // Arrange
            var sut = new ExecutionContext();
            var arbitraryModelName = "Biz.Dfch.CraftmanEngineer.ProtoType.MariaDb+Variant0+MariaDb_1_0_0";
            var arbitraryModelAction = "InitialiseAction";

            var arbitraryParameters = AttributeConverter.Convert(testMariaDbInitialiseActionParameters).SerializeObject();

            // Act
            var result = sut.Invoke(arbitraryModelName, arbitraryModelAction, arbitraryParameters);

            // Assert
            Assert.IsTrue(result.Contains(magicKey), result);
        }

        [TestMethod]
        public void InvokeVirtualMachineViaSimplifiedMethodParametersSucceeds()
        {
            // Arrange
            var sut = new ExecutionContext();
            var arbitraryModelName = "Biz.Dfch.CraftmanEngineer.ProtoType.VirtualMachine+Variant0+VirtualMachine_1_0_0";
            var arbitraryModelAction = "InitialiseAction";

            var arbitraryParameters = AttributeConverter.Convert(testVirtualMachineInitialiseActionParameters).SerializeObject();

            // Act
            var result = sut.Invoke(arbitraryModelName, arbitraryModelAction, arbitraryParameters);

            // Assert
            Assert.IsTrue(result.Contains(magicKey), result);
        }

        [TestMethod]
        public void InvokeVirtualMachineSucceeds()
        {
            // Arrange
            var sut = new ExecutionContext();
            var arbitraryModelName = "Biz.Dfch.CraftmanEngineer.ProtoType.VirtualMachine+Variant0+VirtualMachine_1_0_0";
            var arbitraryModelAction = "InitialiseAction";

            var arbitraryExecutionParameters = new ExecutionParameters()
            {
                ModelName = arbitraryModelName,
                ModelAction = arbitraryModelAction
            };

            var arbitraryParameters = AttributeConverter.Convert(testVirtualMachineInitialiseActionParameters);

            // Act
            var dictionaryParametersResult = sut.Invoke(arbitraryExecutionParameters, arbitraryParameters);

            // Assert
            var result = dictionaryParametersResult.Any(p => p.Key.Contains(magicKey));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvokeMariaDbSucceeds()
        {
            // Arrange
            var sut = new ExecutionContext();
            var arbitraryModelName = "Biz.Dfch.CraftmanEngineer.ProtoType.MariaDb+Variant0+MariaDb_1_0_0";
            var arbitraryModelAction = "InitialiseAction";

            var arbitraryExecutionParameters = new ExecutionParameters()
            {
                ModelName = arbitraryModelName,
                ModelAction = arbitraryModelAction
            };

            var arbitraryParameters = AttributeConverter.Convert(testMariaDbInitialiseActionParameters);

            // Act
            var dictionaryParametersResult = sut.Invoke(arbitraryExecutionParameters, arbitraryParameters);

            // Assert
            var result = dictionaryParametersResult.Any(p => p.Key.Contains(magicKey));
            Assert.IsTrue(result);
        }

        //[DataTestMethod]
        //[DataRow("")]
        //[DataRow(" ")]
        //[DataRow(null)]
        //public void InvokeMariaDbViaSimplifiedMethodParametersWithInvalidModelNameThrowsContractAssertion(string invalidModelName)
        //{
        //    // Arrange
        //    var sut = new ExecutionContext();
        //    var arbitraryModelAction = "InitialiseAction";
        //
        //    var arbitraryParameters = AttributeConverter.Convert(testMariaDbInitialiseActionParameters).SerializeObject();
        //
        //    // Act
        //    var result = sut.Invoke(invalidModelName, arbitraryModelAction, arbitraryParameters);
        //
        //    // Assert
        //}

        //[DataTestMethod]
        //[DataRow("")]
        //[DataRow(" ")]
        //[DataRow(null)]
        //public void InvokeMariaDbViaSimplifiedMethodParametersWithInvalidModelNameThrowsContractAssertion(string invalidModelName)
        //{
        //    // Arrange
        //    var sut = new ExecutionContext();
        //    var arbitraryModelAction = "InitialiseAction";
        //
        //    var arbitraryParameters = AttributeConverter.Convert(testMariaDbInitialiseActionParameters).SerializeObject();
        //
        //    // Act
        //    var result = sut.Invoke(invalidModelName, arbitraryModelAction, arbitraryParameters);
        //
        //    // Assert
        //}
    }
}
