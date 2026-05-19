using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PortalUpskill.App.Utils
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task EnviarEmailResetPassword(string destinatario, string novaPassword)
        {
            var host = _config["Email:Host"];
            var port = int.Parse(_config["Email:Port"]);
            var username = _config["Email:Username"];
            var password = _config["Email:Password"];
            var nomeRemetente = _config["Email:NomeRemetente"];

            var smtp = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            var mensagem = new MailMessage
            {
                From = new MailAddress(username, nomeRemetente),
                Subject = "Recuperação de Password — Portal Upskill",
                Body = $@"<p>Olá,</p>
                          <p>Recebemos um pedido de recuperação de password para a sua conta.</p>
                          <p>A sua nova password temporária é: <strong>{novaPassword}</strong></p>
                          <p>Por favor aceda ao portal e altere a sua password nas definições da conta.</p>
                          <br/>
                          <p>Portal Upskill — Meta Digital / ISCTE</p>",
                IsBodyHtml = true
            };

            mensagem.To.Add(destinatario);
            await smtp.SendMailAsync(mensagem);
        }
    }
}