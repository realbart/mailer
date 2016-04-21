using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public class PromotionalLetter: Letter
    {
        protected override string Css => "body { margin: 1cm; width: 190mm; height: 277mm; padding: 1.5cm; font-family: comic sans ms; font-size: 14pt; border: 1pt solid blue; border-radius: 1cm; } svg { float: right; height: 5em; } address { font-style: normal; margin-bottom: 1cm; border: 1pt solid blue; border-radius: 5mm; padding: 3mm; }";
    }
}
