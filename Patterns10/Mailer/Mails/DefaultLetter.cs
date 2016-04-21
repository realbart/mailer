using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public class DefaultLetter: Letter
    {
        protected override string Css => "body{width:210mm;height:297mm;padding:1.5cm;font-family:tahoma;font-size:12pt}svg{float:right;height:4em}address{font-style:normal;margin-bottom:1cm;border-left:6mm solid gray; padding-left:3mm}";
    }
}
