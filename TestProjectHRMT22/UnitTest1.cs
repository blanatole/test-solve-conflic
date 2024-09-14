using HRMT22;
using HRMT22.CommonTypes;
using NUnit.Framework.Interfaces;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectHRMT22
{
    [TestFixture]
    public class MyTests
    {
        public class TestCaseAddE
        {
            public HRMT22.Models.Employee Employee { get; set; }
            public string ExpectedError { get; set; }
            public bool ExpectedResult { get; set; }
        }

        public static TestCaseAddE[] CreateTestCase()
        {
            return new TestCaseAddE[] { new TestCaseAddE{  Employee = new HRMT22.Models.Employee{ Name = "Nguyen A1",
            Address = "12 Ql22, HM, HCM", Phone = "8477777777", WorkType = WorkType.Normal, PositionType = PositionType.GiamDoc,
            SalaryType = SalaryType.FullTime, Salary = 100_000_000},
             ExpectedError = "", ExpectedResult = true},
             new TestCaseAddE{  Employee = new HRMT22.Models.Employee{ Name = null,
            Address = "12 Ql22, HM, HCM", Phone = "8477777777", WorkType = WorkType.Normal, PositionType = PositionType.GiamDoc,
            SalaryType = SalaryType.FullTime, Salary = 100_000_000},
             ExpectedError = "Employee name is required.", ExpectedResult = false}};
        }

        [Test]
        [TestCaseSource(nameof(CreateTestCase)),]
        public void TestAddEmployee(TestCaseAddE input)
        {
            HRMT22.Lib.Employee employee = new HRMT22.Lib.Employee();
            string error = null;
            var result = employee.Add(input.Employee, out error);
            Assert.AreEqual(input.ExpectedResult, result);
            Assert.AreEqual(input.ExpectedError, error);
        }

        [Test]
        [TestCase(HRMT22.CommonTypes.WorkType.Normal, HRMT22.CommonTypes.PositionType.GiamDoc, 7_000_000)]
        [TestCase(HRMT22.CommonTypes.WorkType.Hard, HRMT22.CommonTypes.PositionType.GiamDoc | PositionType.TruongPhong, 10_000_000)]
        public void TestAllowance(HRMT22.CommonTypes.WorkType workType, HRMT22.CommonTypes.PositionType positionType, decimal expectedResult)
        {
            HRMT22.Lib.Employee employee = new HRMT22.Lib.Employee();
            var result = employee.Allowance(workType, positionType);
            Assert.AreEqual(expectedResult, result);
        }
    }

    [TestFixture]
    public class TestDriver
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        [TestCase("https://www.google.com")]
        public void Test1OpenWeb(string url)
        {
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            Assert.IsNotNull(driver);

        }

        [Test]
        [TestCase("selenium for web driver")]
        public void Test2TextBox(string content)
        {
            IWebElement textBox = driver.FindElement(By.Name("q"));
            if (textBox != null)
            {
                textBox.SendKeys(content);
                Thread.Sleep(1000);
            }
            Assert.IsNotNull(textBox);
        }

        [Test]
        public void Test3Botton()
        {
            IWebElement botton = driver.FindElement(By.Name("btnK"));
            if (botton != null)
            {
                botton.Click();
                Thread.Sleep(3000);
            }
            Assert.IsNotNull(botton);
        }

        [Test]
        public void Test4CloseWeb()
        {
            driver.Quit();
            Assert.IsNotNull(driver);

        }
    }
}