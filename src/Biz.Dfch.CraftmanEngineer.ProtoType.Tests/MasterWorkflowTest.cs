using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biz.Dfch.CraftmanEngineer.ProtoType.Tests
{
    [TestClass]
    public class MasterWorkflowTest
    {
        [TestMethod]
        public void InvokeMasterWorkflowSucceeds()
        {
            // Arrange
            var sut = new MasterWorkflow();

            // Act
            var result = sut.Invoke();

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
