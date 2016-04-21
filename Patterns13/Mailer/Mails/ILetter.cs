namespace Mailer.Mails
{
    public interface ILetter
    {
        void Print(string path, string subject, string[] address, string[] body);
    }
}