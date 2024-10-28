using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class MailSetting
    {
        public int MailSettingID { get; set; }
        public string SmtpMail { get; set; }
        public string Usermail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool EnableCred { get; set; }
    }
}
