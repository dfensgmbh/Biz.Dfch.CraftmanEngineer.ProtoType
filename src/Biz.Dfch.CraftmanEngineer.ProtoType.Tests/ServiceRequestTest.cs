using Microsoft.VisualStudio.TestTools.UnitTesting;
using Net.Appclusive.Public.Engine;

namespace Biz.Dfch.CraftmanEngineer.ProtoType.Tests
{
    [TestClass]
    public class ServiceRequestTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var sut = new ServiceRequest();
            var initialiseActionParameters = new MariaDb.Variant0.MariaDb_1_0_0.InitialiseActionParameters
            {
                Name = "arbitaryDbName",
                CpuCount = 32.ToString(),
            };
            var parameters = AttributeConverter.Convert(initialiseActionParameters);

            parameters.Add("ModelName", "Biz.Dfch.CraftmanEngineer.ProtoType.MariaDb+Variant0+MariaDb_1_0_0");
            parameters.Add("ModelAction", "InitialiseAction");
            var json = parameters.SerializeObject();

            // Act
            var result = sut.Invoke(json);

            // Assert
            Assert.IsTrue(result.Contains("MagicKey"), result);
        }
    }
}
