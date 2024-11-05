using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSMTP
{

        public class Mail
        {

            public Mail()
            {

            }


            #region ENUMERATOR

            public enum Prioirity
            {
                Low = 0,
                Normal = 1,
                High = 2
            }


            /// <summary>
            ///Description	:	Enumerator for Mail Content 
            ///                     HTML     
            ///                     TEXT          
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Comments		:	
            /// </summary>

            public enum Format
            {
                Text = 1,
                Html = 2
            }

            #endregion

            #region Add Attatchments


            /// <summary>
            /// Add attachments
            /// 
            /// Class:  bosch.cicat.cicat_utility.Mail 
            /// Modified On:  17/07/2009   4:31 PM
            /// Modified By:  uap2kor
            /// </summary>
            /// <param name="rdStream">The rd stream.</param>
            public static void AddAttachments(System.IO.FileStream rdStream)
            {
            }

            #endregion

            #region "SEND MAIL METHODS"

            /// <summary>
            /// Description	:	This function is used send mail through SMTP Server;
            /// Author		:	Anand VG (RBEI)
            /// Date		    :	30 Dec 2008
            /// Input		:
            /// ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            /// FromAddress - From Address;
            /// Subject     - Subject of the mail;
            /// MailContent - Content to be sent;
            /// MailFormat  - Format of the content;
            /// BCCAddress  - List of BCC addresses. Mulitple addresses should be seperated by ";";
            /// CCAddress   - List of CC addresses. Mulitple addresses should be seperated by ";";
            /// vPriority   - Mail Priority;
            /// OutPut		:	NA;
            /// Comments		:	;
            /// Class:  bosch.cicat.cicat_validation.Mail
            /// Modified On:  17/07/2009   4:27 PM
            /// Modified By:  uap2kor
            /// </summary>
            /// <param name="ToAddress">To address.</param>
            /// <param name="FromAddress">From address.</param>
            /// <param name="Subject">The subject.</param>
            /// <param name="MailContent">Content of the mail.</param>
            /// <param name="MailFormat">The mail format.</param>
            /// <param name="BCCAddress">The BCC address.</param>
            /// <param name="CCAddress">The CC address.</param>
            /// <param name="vPriority">The v priority.</param>

            public static void SendMail(
                                            string ToAddress,
                                            string FromAddress,
                                            string Subject,
                                            string MailContent,
                                            Mail.Format MailFormat,
                                            string BCCAddress,
                                            string CCAddress,
                                            Mail.Prioirity vPriority
                                           )
            {

                System.Net.Mail.MailMessage oMailMessage = null;
                SmtpClient oSMTPClient = null;
                try
                {
                    // send mail through the SMTP server
                    oMailMessage = new System.Net.Mail.MailMessage();

                    oMailMessage.Subject = Subject;
                    oMailMessage.Body = MailContent;

                    if (MailFormat == Mail.Format.Text)
                        oMailMessage.IsBodyHtml = true;
                    else
                        oMailMessage.IsBodyHtml = false;

                    oMailMessage.From = new MailAddress(FromAddress);

                    if (vPriority == Prioirity.High)
                        oMailMessage.Priority = MailPriority.High;
                    else if (vPriority == Prioirity.Normal)
                        oMailMessage.Priority = MailPriority.Normal;
                    else if (vPriority == Prioirity.Low)
                        oMailMessage.Priority = MailPriority.Low;


                    // To Address
                    if (ToAddress != null)
                    {
                        string l_strToAddress = ToAddress.Trim();

                        string[] l_strToAddressArr = l_strToAddress.Split(';');
                        for (int i = 0; i < l_strToAddressArr.Length; i++)
                        {
                            if (l_strToAddressArr[i].ToString().Trim() != String.Empty)
                                oMailMessage.To.Add(new MailAddress(l_strToAddressArr[i].ToString()));
                        }
                    }

                    // BCC Address
                    if (BCCAddress != null)
                    {
                        string l_strBCCAddress = BCCAddress;
                        string[] l_strBCCAddressArr = l_strBCCAddress.Split(';');
                        for (int i = 0; i < l_strBCCAddressArr.Length; i++)
                        {
                            if (l_strBCCAddressArr[i].ToString().Trim() != String.Empty)
                                oMailMessage.Bcc.Add(new MailAddress(l_strBCCAddressArr[i].ToString()));
                        }
                    }

                    // CC Address
                    if (CCAddress != null)
                    {
                        string l_strCCAddress = CCAddress;
                        string[] l_strCCAddressArr = l_strCCAddress.Split(';');
                        for (int i = 0; i < l_strCCAddressArr.Length; i++)
                        {
                            if (l_strCCAddressArr[i].ToString().Trim() != String.Empty)
                                oMailMessage.To.Add(new MailAddress(l_strCCAddressArr[i].ToString()));
                        }
                    }

                    oSMTPClient = new SmtpClient();
                    oSMTPClient.Host = "rb-smtp-auth.rbesz01.com";
                oSMTPClient.UseDefaultCredentials = false;
                oSMTPClient.Credentials = new NetworkCredential("DE\\QQI1FE", "Roomcicicat@2017");
                oSMTPClient.EnableSsl = true;
                oSMTPClient.Send(oMailMessage);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oMailMessage = null;
                    oSMTPClient = null;
                }

            }


            /// <summary>
            ///Description	:	This function is used send mail through SMTP Server;
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Input		:	
            ///                 ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            ///                 FromAddress - From Address;
            ///                 Subject     - Subject of the mail;
            ///                 MailContent - Content to be sent;
            ///OutPut		:	NA;
            ///Comments		:	;
            /// </summary>
            public static void SendMail(
                                          string ToAddress,
                                          string FromAddress,
                                          string Subject,
                                          string MailContent
                                         )
            {
                SendMail(ToAddress, FromAddress, Subject, MailContent, Mail.Format.Text, null, null, Prioirity.Normal);
            }



            /// <summary>
            ///Description	:	This function is used send mail through SMTP Server;
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Input		:	
            ///                 ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            ///                 FromAddress - From Address;
            ///                 Subject     - Subject of the mail;
            ///                 MailContent - Content to be sent;
            ///                 MailFormat  - Format of the content;        
            ///OutPut		:	NA;
            ///Comments		:	;
            /// </summary>
            public static void SendMail(
                                                string ToAddress,
                                                string FromAddress,
                                                string Subject,
                                                string MailContent,
                                                Mail.Format MailFormat
                                               )
            {
                SendMail(ToAddress, FromAddress, Subject, MailContent, MailFormat, null, null, Prioirity.Normal);
            }



            /// <summary>
            ///Description	:	This function is used send mail through SMTP Server;
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Input		:	
            ///                 ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            ///                 FromAddress - From Address;
            ///                 Subject     - Subject of the mail;
            ///                 MailContent - Content to be sent;
            ///                 MailFormat  - Format of the content;
            ///                 BCCAddress  - List of BCC addresses. Mulitple addresses should be seperated by ";";
            ///                 CCAddress   - List of CC addresses. Mulitple addresses should be seperated by ";";       
            ///OutPut		:	NA;
            ///Comments		:	;
            /// </summary>
            public static void SendMail(
                                         string ToAddress,
                                         string FromAddress,
                                         string Subject,
                                         string MailContent,
                                         Mail.Format MailFormat,
                                         string BCCAddress,
                                         string CCAddress
                                        )
            {
                SendMail(ToAddress, FromAddress, Subject, MailContent, MailFormat, BCCAddress, CCAddress, Prioirity.Normal);
            }


            /// <summary>
            ///Description	:	This function is used send mail through SMTP Server;
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Input		:	
            ///                 ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            ///                 FromAddress - From Address;
            ///                 Subject     - Subject of the mail;
            ///                 MailContent - Content to be sent;
            ///                 MailFormat  - Format of the content;       
            ///                 vPriority   - Mail Priority;
            ///OutPut		:	NA;
            ///Comments		:	;
            /// </summary>
            public static void SendMail(
                                         string ToAddress,
                                         string FromAddress,
                                         string Subject,
                                         string MailContent,
                                         Mail.Format MailFormat,
                                         Mail.Prioirity vPriority
                                        )
            {
                SendMail(ToAddress, FromAddress, Subject, MailContent, MailFormat, null, null, vPriority);
            }



            /// <summary>
            ///Description	:	This function is used send mail through SMTP Server;
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Input		:	
            ///                 ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            ///                 FromAddress - From Address;
            ///                 Subject     - Subject of the mail;
            ///                 MailContent - Content to be sent;        
            ///                 BCCAddress  - List of BCC addresses. Mulitple addresses should be seperated by ";";
            ///                 CCAddress   - List of CC addresses. Mulitple addresses should be seperated by ";";
            ///                 vPriority   - Mail Priority;
            ///OutPut		:	NA;
            ///Comments		:	;
            /// </summary>
            public static void SendMail(
                                        string ToAddress,
                                        string FromAddress,
                                        string Subject,
                                        string MailContent,
                                        string BCCAddress,
                                        string CCAddress,
                                        Mail.Prioirity vPriority
                                       )
            {
                SendMail(ToAddress, FromAddress, Subject, MailContent, Mail.Format.Text, BCCAddress, CCAddress, vPriority);
            }


            /// <summary>
            ///Description	:	This function is used send mail through SMTP Server;
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Input		:	
            ///                 ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            ///                 FromAddress - From Address;
            ///                 Subject     - Subject of the mail;
            ///                 MailContent - Content to be sent;        
            ///                 BCCAddress  - List of BCC addresses. Mulitple addresses should be seperated by ";";
            ///                 CCAddress   - List of CC addresses. Mulitple addresses should be seperated by ";";        
            ///OutPut		:	NA;
            ///Comments		:	;
            /// </summary>
            public static void SendMail(
                                        string ToAddress,
                                        string FromAddress,
                                        string Subject,
                                        string MailContent,
                                        string BCCAddress,
                                        string CCAddress
                                       )
            {
                SendMail(ToAddress, FromAddress, Subject, MailContent, Mail.Format.Text, BCCAddress, CCAddress, Prioirity.Normal);
            }


            /// <summary>
            ///Description	:	This function is used send mail through SMTP Server;
            ///Author		:	Anand VG (RBEI)
            ///Date		    :	30 Dec 2008
            ///Input		:	
            ///                 ToAddress   - List of To addresses. Mulitple addresses should be seperated by ";";
            ///                 FromAddress - From Address;
            ///                 Subject     - Subject of the mail;
            ///                 MailContent - Content to be sent;       
            ///                 vPriority   - Mail Priority;
            ///OutPut		:	NA;
            ///Comments		:	;
            /// </summary>

            public static void SendMail(
                                       string ToAddress,
                                       string FromAddress,
                                       string Subject,
                                       string MailContent,
                                       Mail.Prioirity vPriority
                                      )
            {
                SendMail(ToAddress, FromAddress, Subject, MailContent, Mail.Format.Text, null, null, vPriority);
            }


        }

        #endregion
    }


