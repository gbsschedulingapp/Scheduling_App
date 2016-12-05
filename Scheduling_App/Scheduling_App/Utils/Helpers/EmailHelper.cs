using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

/// <summary>
/// Summary description for EmailHelper
/// </summary>
public class EmailHelper
{
    public EmailHelper()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    /// <summary>
    /// Send Email using SMTP client
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <param name="isBodyHtml"></param>
    /// <returns></returns>
    /// 


    public static bool SendEmail(string to, string subject, string body)
    {
        // get from database
        SMTP smtp = new SMTP();

        string smtpserver = smtp.fetch_SmtpServer();
        string smtpport = smtp.fetch_port();
        string smtpusername = smtp.fetch_UserName();
        string smtppassword = smtp.fetch_Password();
        string smtpfrom = smtp.fetch_EmailFrom();
        // smtpemailto = smtp.fetch_Emailto();
        string smtpBCC = smtp.fetch_BCCTo();
        bool isEnableSSL = smtp.fetch_EnableSSL();
        bool isUserAuth = smtp.fetch_UseAuthentication();
        string cc = "";
        bool IsBodyHtml = true;
        return SendEmail(smtpfrom, to, cc, smtpBCC, subject, body, IsBodyHtml, smtpserver, smtpport, isUserAuth, isEnableSSL, smtpusername, smtppassword);
    }

    public static bool SendEmail(string fromEmail, string to, string cc, string bcc, string subject, string body)
    {
        // get from database
        SMTP smtp = new SMTP();

        //string smtpserver = smtp.fetch_SmtpServer();
        //string smtpport = smtp.fetch_port();
        //string smtpusername = smtp.fetch_UserName();
        //string smtppassword = smtp.fetch_Password();
        ////string smtpfrom = smtp.fetch_EmailFrom();
        //// smtpemailto = smtp.fetch_Emailto();
        ////string smtpBCC = smtp.fetch_BCCTo();
        //bool isEnableSSL = smtp.fetch_EnableSSL();
        //bool isUserAuth = smtp.fetch_UseAuthentication();
        ////string cc = "";
        //bool IsBodyHtml = true;

        string smtpserver = "smtp.gmail.com";
        string smtpport = "587";
        string smtpusername = "mobeen@globalbridgesol.com";
        string smtppassword = "gloalbridgesol4me";
        //string smtpfrom = smtp.fetch_EmailFrom();
        // smtpemailto = smtp.fetch_Emailto();
        //string smtpBCC = smtp.fetch_BCCTo();
        bool isEnableSSL = true;
        bool isUserAuth =true;
        //string cc = "";
        bool IsBodyHtml = false;

        return SendEmail(fromEmail, to, cc, bcc, subject, body, IsBodyHtml, smtpserver, smtpport, isUserAuth, isEnableSSL, smtpusername, smtppassword);
    }


    /// <summary>
    /// Send Email using SMTP client
    /// </summary>
    /// <param name="fromEmail"></param>
    /// <param name="fromName"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="bcc"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <param name="isBodyHtml"></param>
    /// <returns></returns>

    public static bool SendEmail(string fromEmail, string to, string cc, string bcc, string subject, string body, bool isBodyHtml, string smtpserver, string smtpport, bool isUserAuth, bool isEnableSSL, string smtpusername, string smtppassword)
    {
        //Restrict user to send email if WebsiteMode is test or localhost. Emails will be sent only in case of WebsiteMode is live[AQDAS].

        if (String.IsNullOrEmpty(to))
            throw new Exception("Must provide to email address to send email.");

        MailMessage mailMessage = new MailMessage();
        mailMessage.IsBodyHtml = true;
        //SmtpClient smtpClient = new SmtpClient();
        SmtpClient smtpClient = new SmtpClient(smtpserver, Convert.ToInt32(smtpport));

        if (!string.IsNullOrEmpty(fromEmail))
            mailMessage.From = new MailAddress(fromEmail);

        if (to.Contains(","))
        {
            string[] tos = to.Split(',');
            foreach (string address in tos)
            {
                if (!string.IsNullOrEmpty(address))
                    mailMessage.To.Add(new MailAddress(address));
            }
        }
        else if (!string.IsNullOrEmpty(to))
            mailMessage.To.Add(new MailAddress(to));

        if (cc.Contains(","))
        {
            string[] ccs = cc.Split(',');
            foreach (string address in ccs)
            {
                if (!string.IsNullOrEmpty(address))
                    mailMessage.CC.Add(new MailAddress(address));
            }
        }
        else if (!string.IsNullOrEmpty(cc))
            mailMessage.CC.Add(new MailAddress(cc));

        if (bcc.Contains(","))
        {
            string[] bccs = bcc.Split(',');
            foreach (string address in bccs)
            {
                if (!string.IsNullOrEmpty(address))
                    mailMessage.Bcc.Add(new MailAddress(address));
            }
        }
        else if (!string.IsNullOrEmpty(bcc))
            mailMessage.Bcc.Add(new MailAddress(bcc));

        if (!string.IsNullOrEmpty(subject)) mailMessage.Subject = subject;
        if (!string.IsNullOrEmpty(body)) mailMessage.Body = body;
        mailMessage.IsBodyHtml = isBodyHtml;
        try
        {
            if (isUserAuth == true)
            {
                if (isEnableSSL == true)
                {
                    smtpClient.EnableSsl = true;
                }
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(smtpusername, smtppassword);
                smtpClient.Credentials = credentials;
            }
            smtpClient.Send(mailMessage);
        }
        catch (Exception exception)
        {
            throw exception;
        }
        finally
        {
            mailMessage.Dispose();
        }
        return true;
    }

}