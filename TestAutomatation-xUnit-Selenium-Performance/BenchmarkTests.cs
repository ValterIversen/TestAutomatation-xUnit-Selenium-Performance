using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class BenchmarkTests
{
    [Benchmark]
    public void GoogleSearchBenchmark()
    {
        using (IWebDriver driver = new ChromeDriver())
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("BenchmarkDotNet");
            searchBox.SendKeys(Keys.Enter);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchmarkTests>();
    }
}
