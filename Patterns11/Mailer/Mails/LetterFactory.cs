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
            switch (type)
            {
                case "promotional":
                    return new PromotionalLetter { Writer = file };
                default:
                    return new DefaultLetter { Writer = file };
            }
        }
    }
}
