using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nazim.UI.Automation.BaseClass;
using Nazim.Automation.Utilities;
using Nazim.Automation.Workflow;

namespace Nazim.Automation.Tests
{
    [TestClass]
    public class GoogleTest : TestBaseClass
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Commonutilities.SetConfigValues(testContext);
            _testContext = testContext;
        }

        public GoogleWorkflow _googleWorkflow
        {
            get { return new GoogleWorkflow(_webDriver); }

        }

        [TestMethod]
        [DataRow("Indian", "https://www.google.com/")] //CustomAttribute
        public void TC_No_UI_Test(string nationality, string appUrl)
        {
            var (isVisible, output) = _googleWorkflow.ValidateGooglePage(nationality, appUrl);
            Assert.IsTrue(isVisible == true && output == "Testing", "Something went wrong. ");
        }

    }
}
