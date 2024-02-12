using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

public class Program
{
    public static void Main(string[] args)
    {
        //Set specific chrome IP and connect to the already open session
        var options = new ChromeOptions();
        options.DebuggerAddress = "localhost:9999";
        IWebDriver driver = new ChromeDriver(options);

        //Locate the objet/class holding the email count 
        var mail_class = driver.FindElement(By.ClassName("Dj")).Text;

        /*Since emails are being shown per page, the object reads "1-50 from x"
        Thus, we need to isolate and print the x value which holds the total e-mail count*/
        string mail_count = mail_class.Substring(mail_class.LastIndexOf(' ') + 1);
        Console.WriteLine("You have " + mail_count + " emails.");

        //Call the function to retrieve the Sender and Subject of your x e-mail.
        EmailInfo(12, driver);
    }
    public static void EmailInfo(int object_number, IWebDriver func_driver)
    {
        /*This function takes as input the number of the e-mail from which you need to retrieve information.
        E.G. if you wish to retrieve information for your 6th e-mail, you should call the function as follows:
        EmailInfo(6,driver);*/
        string sender = func_driver.FindElement(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[2]/div/div/div/div[2]/div/div[1]/div/div/div[5]/div[1]/div/table/tbody/tr["+object_number+"]/td[4]/div[2]/span/span")).Text;
        string subject = func_driver.FindElement(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[2]/div/div/div/div[2]/div/div[1]/div/div/div[5]/div[1]/div/table/tbody/tr["+object_number+"]/td[5]/div/div/div/span/span")).Text;
        Console.WriteLine("Email number " +object_number+" was sent by '" + sender + "' and its subject is '" + subject +"'");
    }
}