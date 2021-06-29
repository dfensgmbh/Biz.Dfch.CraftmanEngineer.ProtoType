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

using System.Collections.Generic;
using System.Linq;
using biz.dfch.CS.Commons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Appclusive.Public.Engine;

namespace Biz.Dfch.CraftmanEngineer.ProtoType.Tests
{
    [TestClass]
    public class AttributeConverterTest
    {
        private readonly string MariaDbModelName = "Biz.Dfch.CraftmanEngineer.ProtoType.MariaDb+Variant0+MariaDb_1_0_0";
        private readonly string VirtualMachineModelName = "Biz.Dfch.CraftmanEngineer.ProtoType.VirtualMachine+Variant0+VirtualMachine_1_0_0";
        private readonly string dot = ".";

        [TestMethod]
        public void ConvertMariaDbInitialiseActionParametersToDictionaryParameterSucceeds()
        {
            // Arrange
            var arbitraryMariaDbInitialiseActionParameters =
                new MariaDb.Variant0.MariaDb_1_0_0.InitialiseActionParameters
                {
                    CpuCount = 8.ToString(),
                    DatabaseInGb = 256.ToString(),
                    LogInGb = 128.ToString(),
                    Name = "arbitraryName",
                    Description = "arbitraryDescription"
                };

            var dictionary = new Dictionary<string, object>
            {
                {MariaDbModelName+dot+nameof(arbitraryMariaDbInitialiseActionParameters.Name), arbitraryMariaDbInitialiseActionParameters.Name},
                {MariaDbModelName+dot+nameof(arbitraryMariaDbInitialiseActionParameters.Description), arbitraryMariaDbInitialiseActionParameters.Description},
                {MariaDbModelName+dot+nameof(arbitraryMariaDbInitialiseActionParameters.DatabaseInGb), arbitraryMariaDbInitialiseActionParameters.DatabaseInGb},
                {MariaDbModelName+dot+nameof(arbitraryMariaDbInitialiseActionParameters.LogInGb), arbitraryMariaDbInitialiseActionParameters.LogInGb},
                {VirtualMachineModelName+dot+nameof(arbitraryMariaDbInitialiseActionParameters.CpuCount), arbitraryMariaDbInitialiseActionParameters.CpuCount},
            };
            var expectedDictionaryParameters = new DictionaryParameters(dictionary);

            // Act
            var result = AttributeConverter.Convert(arbitraryMariaDbInitialiseActionParameters);
            
            // Assert
            Assert.AreEqual(expectedDictionaryParameters.Count, result.Count);

            for (int i = 0; i < expectedDictionaryParameters.Count; i++)
            {
                var expectedEntry = expectedDictionaryParameters.ElementAt(i);
                var entryToBeAsserted = result.ElementAt(i);

                Assert.AreEqual(expectedEntry.Key, entryToBeAsserted.Key);
                Assert.AreEqual(expectedEntry.Value, entryToBeAsserted.Value);
            }
        }
    }
}
