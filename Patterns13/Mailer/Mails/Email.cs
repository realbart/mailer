using Mailer.Parties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Mailer.Mails
{
    public class Email : IMessage
    {
        private const string Logo = @"<svg xmlns = ""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""113px"" height=""75px"" viewBox=""0 0 3 2"" preserveAspectRatio=""xMidYMid meet"" zoomAndPan=""disable""  ><defs id = ""svgEditorDefs"" >< path id=""svgEditorClosePathDefs"" fill=""url(&quot;#hatch-black-120&quot;)"" style=""stroke-width: 1px; vector-effect: non-scaling-stroke; stroke: none;""/><pattern height = ""10"" id=""hatch-black-120"" patternTransform=""rotate(120) scale(0.4)"" patternUnits=""userSpaceOnUse"" viewBox=""0 0 10 10"" width=""10"" x=""0"" y=""0""><line style = ""stroke:black;stroke-width:1px;"" x1=""0"" x2=""10"" y1=""5"" y2=""5""/></pattern><pattern height = ""10"" id=""hatch-blue-120"" patternTransform=""rotate(120) scale(0.4)"" patternUnits=""userSpaceOnUse"" viewBox=""0 0 10 10"" width=""10"" x=""0"" y=""0""><line style = ""stroke:blue;stroke-width:1px;"" x1=""0"" x2=""10"" y1=""5"" y2=""5""/></pattern><pattern height = ""10"" id=""hatch-blue-dash-120"" patternTransform=""rotate(120) scale(0.4)"" patternUnits=""userSpaceOnUse"" viewBox=""0 0 24 10"" width=""24"" x=""0"" y=""0""><line style = ""stroke:blue;stroke-width:1px;stroke-dasharray:4,4;"" x1=""0"" x2=""24"" y1=""5"" y2=""5""/></pattern><pattern height = ""10"" id=""hatch-black-dash-120"" patternTransform=""rotate(120) scale(0.4)"" patternUnits=""userSpaceOnUse"" viewBox=""0 0 24 10"" width=""24"" x=""0"" y=""0""><line style = ""stroke:black;stroke-width:1px;stroke-dasharray:4,4;"" x1=""0"" x2=""24"" y1=""5"" y2=""5""/></pattern></defs><rect id = ""svgEditorBackground"" x=""0"" y=""0"" width=""3"" height=""2"" style=""stroke: none; fill: none;""/><circle id = ""e3_circle"" cx=""125.417"" cy=""8.49207"" stroke=""black"" style=""stroke-width: 1px; vector-effect: non-scaling-stroke;"" r=""8.98435"" fill=""red"" transform=""matrix(0.021181 0 0 0.021181 -2.41112 1.40663)""/><path d = ""M132.66670988084863,14.241938178368649a32.399585,32.399585,0,0,0,29.499999999999943,-10"" stroke=""black"" id=""e4_circleArc"" style=""fill: none; stroke-width: 1px; vector-effect: non-scaling-stroke;"" transform=""matrix(0.021181 0 0 0.021181 -2.41112 1.40663)""/><line id = ""e5_line"" x1=""151.417"" y1=""12.2421"" x2=""174.917"" y2=""11.9921"" stroke=""black"" style=""stroke-width: 1px; vector-effect: non-scaling-stroke; fill: none;"" transform=""matrix(0.021181 0 0 0.021181 -2.41112 1.40663)""/><path d = ""M130.91670988084857,1.491938178368649a92.940771,92.940771,0,0,0,36.25000000000006,-29.25"" stroke=""black"" id=""e6_circleArc"" style=""fill: none; stroke-width: 1px; vector-effect: non-scaling-stroke;"" transform=""matrix(0.021181 0 0 0.021181 -2.41112 1.40663)""/><ellipse id = ""e7_ellipse"" cx=""165.167"" cy=""-17.5079"" style=""stroke-width: 1px; vector-effect: non-scaling-stroke; stroke: none;"" rx=""2.75"" ry=""5"" fill=""blue"" transform=""matrix(0.021181 0 0 0.021181 -2.41112 1.40663)""/><ellipse id = ""e8_ellipse"" cx=""154.417"" cy=""-19.7579"" style=""stroke-width: 1px; vector-effect: non-scaling-stroke; stroke: none;"" rx=""2.25"" ry=""5"" fill=""blue"" transform=""matrix(0.021181 0 0 0.021181 -2.41112 1.40663)""/><path d = ""M166.24615933137844,-28.758061821631365c13.271319401189317,15.919103687897412,15.751503373133119,31.75544464362708,10.170550549470079,41.00000000000001s62.72790066668051,10.731546725720136,70.25,-12.5s-8.486294921880472,-50.46272388726578,-27.25,-53.75s-47.49170817804833,12.182427678925535,-53.17055054947008,25.249999999999993Z"" id=""e13_areaS3"" fill=""url(&quot;#hatch-black-dash-120&quot;)"" style=""stroke-width: 1px; vector-effect: non-scaling-stroke; stroke: none;"" transform=""matrix(0.021181 0 0 0.021181 -2.41112 1.40663)""/></svg>";

        public Email(IEmailSender mailer)
        {
            Mailer = mailer;
        }
        public Party Sender { get; set; }
        public Party Recipient { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public string Subject { get; set; }
        public IEnumerable<string> Body { get; set; }
        protected IEmailSender Mailer { get; }

        public void Send()
        {
            var writer = new StringWriter();
            using (var html = new HtmlTextWriter(writer))
            {
                html.Write("<!DOCTYPE html>\n");
                html.RenderBeginTag(HtmlTextWriterTag.Html);
                html.RenderBeginTag(HtmlTextWriterTag.Head);
                html.RenderBeginTag(HtmlTextWriterTag.Style);
                html.RenderEndTag();
                html.RenderEndTag();
                html.RenderBeginTag(HtmlTextWriterTag.Body);
                html.RenderBeginTag("Header");
                html.Write(Logo);
                html.AddAttribute(HtmlTextWriterAttribute.Class, "from");
                html.RenderBeginTag(HtmlTextWriterTag.Address);
                foreach (var line in (Sender?.Address?.Format()).EmptyIfNull())
                {
                    html.WriteEncodedText(line);
                    html.Write("<br/>");
                }
                html.RenderEndTag();
                html.AddAttribute(HtmlTextWriterAttribute.Class, "to");
                html.RenderBeginTag(HtmlTextWriterTag.Address);
                foreach (var line in (Recipient?.Address?.Format()).EmptyIfNull())
                {
                    html.WriteEncodedText(line);
                    html.Write("<br/>");
                }
                html.RenderEndTag();
                html.RenderBeginTag(HtmlTextWriterTag.P);
                html.WriteEncodedText($"{Sender.Address?.City?.ToUpper()} {DateTime.Today:dd MMM yyyy}");
                html.RenderEndTag();
                html.RenderBeginTag(HtmlTextWriterTag.P);
                html.WriteEncodedText($"Betreft: {Subject}");
                html.RenderEndTag();
                html.RenderEndTag();
                html.RenderBeginTag("Main");
                html.RenderBeginTag(HtmlTextWriterTag.P);
                html.WriteEncodedText(((ReceivingParty)Recipient)?.Salutation ?? "Geachte heer, mevrouw,");
                html.RenderEndTag();
                foreach (var p in Body)
                {
                    html.RenderBeginTag(HtmlTextWriterTag.P);
                    html.WriteEncodedText(p);
                    html.RenderEndTag();
                }
                html.AddAttribute("Class", "closing");
                html.RenderBeginTag("section");
                foreach (var line in ((SendingParty)Sender)?.Closing ?? new[] { "Met vriendelijke groet", Sender.Name })
                {
                    html.RenderBeginTag(HtmlTextWriterTag.P);
                    html.WriteEncodedText(line ?? "");
                    html.RenderEndTag();
                }
                html.RenderEndTag();
                html.RenderEndTag();
                html.RenderEndTag();
                html.RenderEndTag();
            }
            var message = new MailMessage();
            message.Sender = new MailAddressAdapter(Sender);
            message.To.Add(new MailAddressAdapter(Recipient));
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body=writer.GetStringBuilder().ToString();

            Mailer.Send(message);
        }

        public void Dispose()
        {
            Mailer.Dispose();
        }
    }
}
