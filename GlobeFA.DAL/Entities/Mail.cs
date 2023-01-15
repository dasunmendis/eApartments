using System;

namespace GlobeFa.DAL.Entities
{
    public class Mail
    {
        private string _to = string.Empty;
        private string _from = string.Empty;
        private string _body = string.Empty;
        private string _subject = string.Empty;
        private string _fromName = string.Empty;
        private string _toName = string.Empty;
        //Can Use Web Config
        private static string _userName = System.Configuration.ConfigurationManager.AppSettings["UserName"];
        private static string _password = System.Configuration.ConfigurationManager.AppSettings["Password"];
        private static string _smtpHost = System.Configuration.ConfigurationManager.AppSettings["smtpHost"];
        private static readonly int _smtpPort = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);

        public int SmtpPort
        {
            get { return _smtpPort; }
        }

        public string SmtpHost
        {
            get { return _smtpHost; }
        }

        public string Password
        {
            get { return _password; }
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string ToName
        {
            get { return _toName; }
            set { _toName = value; }
        }

        public string FromName
        {
            get { return _fromName; }
            set { _fromName = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
    }
}
