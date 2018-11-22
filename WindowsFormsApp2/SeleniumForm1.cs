using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace WindowsFormsApp2
{
    public partial class SeleniumForm1 : Form
    {
        String userProfile = "C:\\Users\\sandip.divate\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\";
        ChromeOptions objOptions = new ChromeOptions();
        ChromeDriver driver;


        public SeleniumForm1()
        {
            InitializeComponent();
        }

        public class ChromeOptionsWithPrefs : ChromeOptions
        {
            public Dictionary<string, object> prefs { get; set; }
        }

    //    public static void Initialize()
    //    {
    //        var options = new ChromeOptionsWithPrefs();
    //        options.prefs = new Dictionary<string, object>
    //{
    //    { "intl.accept_languages", "nl" }
    //};
    //        _driver = new ChromeDriver(@"C:\path\chromedriver", options);
    //    }

        private void Form1_Load(object sender, EventArgs e)
        {
            objOptions.AddArguments("user-data-dir=" + userProfile);
            objOptions.AddArguments("--start-maximized");

            //objOptions.AddArguments("–-lang = en");
           driver = new ChromeDriver(objOptions); //&lt;-Add your path
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChromeOptionsWithPrefs options = new ChromeOptionsWithPrefs();
            //options.prefs = new Dictionary<string, object>
            //    {
            //         { "intl.accept_languages", "en" }
            //    };
            //options.AddUserProfilePreference  ("intl.accept_languages", "en");

            
            driver.Navigate().GoToUrl(textBox1.Text);
            //driver.Mouse.FindElementById("bottom").SendKeys(OpenQA.Selenium.Keys.PageDown);
            //document.body.offsetHeight
            Double PreviousScrollPosition=0;
            Double CurrentScrollPosition=0;
            Actions actions = new Actions(driver);
            for (int i = 0; i < 1000; i++)
            {

                driver.Keyboard.SendKeys(OpenQA.Selenium.Keys.PageDown);
                System.Threading.Thread.Sleep(1000);

                try
                {
                    CurrentScrollPosition = (Double)driver.ExecuteScript("return window.pageYOffset;");
                    if (CurrentScrollPosition == PreviousScrollPosition)
                        break;
                    else
                        PreviousScrollPosition = CurrentScrollPosition;
                }
                catch
                {

                }
              
            }
            //driver

            //ChromeDriver driver1 = new ChromeDriver(objOptions); //&lt;-Add your path
            //driver.Navigate().GoToUrl(@"https://https://tweakers.net/reviews/6703/all/de-grootste-pricewatch-dalers-beste-koopjes-rondom-black-friday.html");
            ////driver.Mouse.FindElementById("bottom").SendKeys(OpenQA.Selenium.Keys.PageDown);

            //for (int i = 0; i < 3; i++)
            //{

            //    driver.Keyboard.SendKeys(OpenQA.Selenium.Keys.PageDown);
            //    System.Threading.Thread.Sleep(1000);
            //}
            driver.Keyboard.SendKeys(OpenQA.Selenium.Keys.Control + System.Windows.Forms.Keys.S);
        }
    }
}
