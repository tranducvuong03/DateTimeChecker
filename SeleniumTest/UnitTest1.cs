using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    [TestFixture]
    public class Tests
    {
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            // Khởi tạo WebDriver
            _baseUrl = "http://seleniumdemo.somee.com"; // Thay đổi địa chỉ URL tương ứng
        }

        [Test]
        public void TestValidDate()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_baseUrl);
            _driver.Manage().Window.Maximize();

            // Input
            var yearInput = _driver.FindElement(By.Id("Year"));
            yearInput.SendKeys("2024");

            var monthInput = _driver.FindElement(By.Id("Month"));
            monthInput.SendKeys("6");

            var dayInput = _driver.FindElement(By.Id("Day"));
            dayInput.SendKeys("14");

            // Submit form
            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            // wait for result page load
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElement(By.Id("msg")));

            var resultMessage = _driver.FindElement(By.Id("msg"));
            Assert.AreEqual("The date is valid.", resultMessage.Text);

            //Close Browser
            _driver.Quit();
        }

        [Test]
        public void TestInvalidDate()
        {
            IWebDriver _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl(_baseUrl);
            _driver.Manage().Window.Maximize();

            // Input
            var yearInput = _driver.FindElement(By.Id("Year"));
            yearInput.SendKeys("2024");

            var monthInput = _driver.FindElement(By.Id("Month"));
            monthInput.SendKeys("13"); // month is over

            var dayInput = _driver.FindElement(By.Id("Day"));
            dayInput.SendKeys("32"); // Day is over 

            // Submit form
            var submitButton = _driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.Id("msg")));

            var resultMessage = _driver.FindElement(By.Id("msg"));
            //Check result is correct with expected result or not
            Assert.AreNotEqual("The date valid.", resultMessage.Text);

            //Close Browser
            _driver.Quit();
        }
    }
}
