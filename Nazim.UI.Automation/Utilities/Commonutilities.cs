using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nazim.Automation.Utilities
{
    public class Commonutilities
    {
        public static string environment = string.Empty;
        public static void SetConfigValues(TestContext testContext)
        {
            environment = testContext.Properties["Environment"].ToString();
        }
    }
}
