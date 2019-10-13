namespace _1.Logger.Models.Layouts
{
    using _1.Logger.Models.Contracts;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Format => this.GetFormat();

        private string GetFormat()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>")
            .AppendLine("\t<date>{0}</date>")
            .AppendLine("\t<level>{1}</level>")
            .AppendLine("\t<message>{2}</message>")
            .AppendLine("</log>");

            return sb.ToString().TrimEnd();
        }
    }
}
