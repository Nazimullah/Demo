using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Globalization;

namespace Custom.Utilities
{
    public class CustomXmlDataSourceAttribute : Attribute, ITestDataSource
    {
        private string dataNonde = "Data";
        public CustomXmlDataSourceAttribute(string InputFileName)
        {
            var inputNames = InputFileName.Split("\\");
            this.InputFileName = inputNames[0];
            if (inputNames.Length == 2)
            {
                dataNonde = inputNames[1];
            }
        }
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            //CommonMethods.testMethodName = methodInfo.Name;
            //var testData = CommonMethods.ReadXmlData(Directory.GetCurrentDirectory() +
            //    $"\\Data\\{CommonMethods.GetEnvironmentDataFolderName()}\\{InputFileName}.xml", dataNonde);
            //foreach (var dataRow in testData.Rows)
            //{
                yield return new object[] { null };
            //}
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            return null;
        }

        //
        // Summary:
        //     Gets the InputFileName of a test.
        public string InputFileName { get; }

    }

    public class CustomJsonDataSourceAttribute : Attribute, ITestDataSource
    {
        private string dataNonde = "Data";
        public CustomJsonDataSourceAttribute(string InputFileName)
        {
            var inputNames = InputFileName.Split("\\");
            //this.InputFileName = inputNames[0];
            //if(inputNames.Length ==2)
            //{
            //    dataNonde = inputNames[1];
            //}
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            //CommonMethods.testMethodName = methodInfo.Name;
            //var testData = (JObject)CommonMethods.ReadJsonFile(Directory.GetCurrentDirectory() + $"\\Data\\{CommonMethods.GetEnvironmentDataFolderName()}\\{InputFileName}.json");
            //foreach (var jToken in testData[dataNonde])           
            //{
               yield return new object[] { null };
            //}
        }

        //public string GetDisplayName(MethodInfo methodInfo, object[] data)
        //{
        //    return null;
        //}

        public string GetDisplayName(MethodInfo methodInfo, object[] data) 
        {
            if (data != null) 
                return string.Format(CultureInfo.CurrentCulture, "Custom - {0} ({1})", methodInfo.Name, string.Join(",", data));
            return null; 
        }

        //
        // Summary:
        //     Gets the InputFileName of a test.
        public string InputFileName { get; }
    }
       
}