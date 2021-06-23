using System;
using System.Text;
using System.Collections.Generic;
using biz.dfch.CS.Appclusive.Public;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Appclusive.Public.Engine;
using biz.dfch.CS.Commons;
using Newtonsoft.Json;
using DictionaryParameters = biz.dfch.CS.Commons.DictionaryParameters;

namespace Biz.Dfch.CraftmanEngineer.ProtoType.Tests
{
    [TestClass]
    public class InitialiseActionTest
    {
        public string JSON = @"{""Com.Example.VirtualMachine.Variant0.VirtualMachine_1_0_0.Name"":""arbitraryName"",""Com.Example.VirtualMachine.Variant0.VirtualMachine_1_0_0.Description"":null,""Com.Example.VirtualMachine.Variant0.VirtualMachine_1_0_0.CpuCount"":""8"",""Com.Example.VirtualMachine.Variant0.VirtualMachine_1_0_0.MemoryInGb"":""32"",""Com.Example.VirtualMachine.Variant0.VirtualMachine_1_0_0.DiskInGb"":""128""}";

        [TestMethod]
        public void ValidatingNameSucceeds()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
                Name = "arbitraryName",
            };

            // Act
            var result = sut.IsValid();

            // Assert
            Assert.IsTrue(result, string.Join("; ", sut.GetErrorMessages()));
        }

        [TestMethod]
        public void ValidatingNonExistingRequiredNameFails()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
            };

            // Act
            var result = sut.IsValid();

            // Assert
            Assert.IsFalse(result, string.Join("; ", sut.GetErrorMessages()));
        }


        [TestMethod]
        public void ValidatingTooLongNameFails()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
                Name = "thisNameIsFarTooLongthisNameIsFarTooLongthisNameIsFarTooLongthisNameIsFarTooLongthisNameIsFarTooLong",
            };

            // Act
            var result = sut.IsValid();

            // Assert
            Assert.IsFalse(result, string.Join("; ", sut.GetErrorMessages()));
        }

        [TestMethod]
        public void ValidatingCpuCountThirtyTwoSucceeds()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
                Name = "arbitraryName",
                CpuCount = 32.ToString(),
            };

            // Act
            var result = sut.IsValid();

            // Assert
            Assert.IsTrue(result, string.Join("; ", sut.GetErrorMessages()));
        }

        [TestMethod]
        public void ValidatingCpuCountFiveFails()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
                Name = "arbitraryName",
                CpuCount = 5.ToString()
            };

            // Act
            var result = sut.IsValid();

            // Assert
            Assert.IsFalse(result, string.Join("; ", sut.GetErrorMessages()));
        }

        [TestMethod]
        public void ValidatingDiskInGbSucceeds()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
                Name = "arbitraryName",
                DiskInGb = 128.ToString()
            };

            // Act
            var result = sut.IsValid();

            // Assert
            Assert.IsTrue(result, string.Join("; ", sut.GetErrorMessages()));
        }

        [TestMethod]
        public void ConvertingToJsonAndDeserialisingJsonSucceeds()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
                Name = "arbitraryName",
            };

            // Act
            var json = sut.SerializeObject();
            var result = JsonConvert
                .DeserializeObject<VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters>(json);

            // Assert
            Assert.IsNotNull(result, json);
        }

        [TestMethod]
        public void ConvertingBackAndForthBetweenObjectAndJsonSucceeds()
        {
            // Arrange
            var sut = new VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters
            {
                Name = "arbitraryName",
            };

            // Act
            var json = AttributeConverter.Convert(sut).SerializeObject();
            var dic = new DictionaryParameters(json);
            var result = new AttributeConverter()
                .Convert<VirtualMachine.Variant0.VirtualMachine_1_0_0.InitialiseActionParameters, AttributeNameAttribute>(dic);

            // Assert
            Assert.AreEqual(sut.Name, result.Name, json);
            Assert.AreEqual(sut.Description, result.Description, json);
            Assert.AreEqual(sut.CpuCount, result.CpuCount, json);
            Assert.AreEqual(sut.MemoryInGb, result.MemoryInGb, json);
            Assert.AreEqual(sut.DiskInGb, result.DiskInGb, json);
        }
    }
}
