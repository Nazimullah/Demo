using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nazim.Api.Automation.Models;
using Nazim.Api.Automation.Utilities;
using System.Linq;

namespace Nazim.Api.Automation.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        [DataRow("https://jsonplaceholder.typicode.com/todos")]
        // Use CustomDataSource or dynamic attribute inorder to read data from json file
        public void TC_Number_Validate_User_Details_Test(string apiUrl)
        {
            var apiResponse =
                CommonUtilities.GetResponseForAPIServices<User>(apiUrl);

            Assert.IsTrue(apiResponse.ToList().Where(x => x.title == "culpa eius et voluptatem et").Any(), 
                "No such user whose name is " + "culpa eius et voluptatem et");

            //Logging to text file also we can do
        }
    }
}
