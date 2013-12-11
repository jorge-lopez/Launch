using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        [TestMethod]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
    
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
