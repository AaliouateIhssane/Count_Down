using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TP2_ASP.NET_Final_
{
    public class Confirm
    {
        public void Confirmation(string destination, string body, string subj)
        {
            try
            {
                SmtpClient cli = new SmtpClient("smtp.gmail.com", 587);
                cli.EnableSsl = true;
                cli.DeliveryMethod = SmtpDeliveryMethod.Network;
                cli.UseDefaultCredentials = false;
                cli.Credentials = new NetworkCredential("orchestradavi50@gmail.com", "David@123987");
                MailMessage msg = new MailMessage();
                msg.To.Add(destination);
                msg.From = new MailAddress("orchestradavi50@gmail.com");
                msg.Subject = subj;
                msg.Body = body;
                cli.Send(msg);
                //return ("Message de confirmation envoyé a votre adresse");

            }
            catch (Exception ex)
            {


            }
        }
    }
}