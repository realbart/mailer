using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Mails
{
    public class LetterFactory
    {
        public Func<TextWriter> TextWriterCreator { get; set; } = () => File.CreateText($"{Guid.NewGuid()}.html");

        public IMessage CreateMessage(string type)
        {
            var file = TextWriterCreator();
            var letter = new Letter(file);
            switch(type)
            {
                case "promotional": 
                    letter.Css = "body { margin: 1cm; width: 190mm; height: 277mm; padding: 1.5cm; font-family: comic sans ms; font-size: 14pt; border: 1pt solid blue; border-radius: 1cm; } svg { float: right; height: 5em; } address { font-style: normal; margin-bottom: 1cm; border: 1pt solid blue; border-radius: 5mm; padding: 3mm; }";
                    break;
                default:
                    letter.Css = "body{width:210mm;height:297mm;padding:1.5cm;font-family:tahoma;font-size:12pt}svg{float:right;height:4em}address{font-style:normal;margin-bottom:1cm;border-left:6mm solid gray; padding-left:3mm}";
                    break;
            }
            return letter;
        }
    }
}
