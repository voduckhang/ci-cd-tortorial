using bosch.cicat.cicat_utility;
using Com.Bosch.CICAT.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSMTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("qqi1fe@bosch.com");
            //mailMessage.To.Add("Khang.VoDucAn@vn.bosch.com");
            //mailMessage.Subject = "Subject";
            //mailMessage.Body = "This is test send notification to stakeholders";

            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = "rb-smtp-auth.rbesz01.com";
            ////smtpClient.Port = 587;
            //smtpClient.Credentials = new NetworkCredential("DE\\QQI1FE", "Roomcicicat@2017");

            //smtpClient.EnableSsl = true;
            //try
            //{
            //    smtpClient.Send(mailMessage);
            //    Console.WriteLine("Email sent successfully");
            //    Console.ReadKey();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.ReadKey();
            //}

            // Define a byte array.
            string credentialPhase;
            string bytes = "nCFWqju8davd81IEBMXT6OsR0Pr1SvaoacX/wfsfTLU=";
            Console.WriteLine("The byte array: ");
            Console.WriteLine("   {0}\n", bytes);
            Cryptography oCryptic = new Cryptography("w?dj^yrbosch!@*k0_^f21082007%p$#*****N*****$$$+&amp;");
            credentialPhase = oCryptic.Decrypt(bytes);
            // Convert the array to a base 64 string.
            string s = bytes;
            Console.WriteLine("The base 64 string:\n   {0}\n", s);

            // Restore the byte array.
            Console.WriteLine("The restored byte array: ");
            Console.WriteLine("   {0}\n", credentialPhase);
            Console.ReadKey();
        }

      

    }
}
