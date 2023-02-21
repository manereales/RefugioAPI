using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using AppRefugio.Entidades;

namespace AppRefugio.Controllers
{
    [ApiController]
    [Route("api/sendEmail")]
    public class SendEmailsController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SendEmailsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult SendEmail(string especie, string nombre, int edad, string raza, string genero)
        {
            var adoptante = context.Adoptantes.ToList();
            var emails = from a in adoptante
                         select a.Correo;
            StringBuilder sb = new StringBuilder();
            foreach (var email in emails)
            {
                sb.Append(email + ";");
            }
            string addresses = sb.ToString().TrimEnd(';');

            //var addresses = "2510812016@mail.utec.edu.sv;edwinpalaciosm95@gmail.com";
            //email.From = new MailAddress("edwinpalaciosm95@gmail.com");
            //email.To.Add(new MailAddress("2510812016@mail.utec.edu.sv"));
            var fromAddress = new MailAddress("edwinpalaciosm95@gmail.com");

            using var smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            NetworkCredential nc = new NetworkCredential("edwinpalaciosm95@gmail.com", "zxbejsigavtpsbwv");
            smtp.EnableSsl = true;
            smtp.Credentials = nc;

            foreach (var address in addresses.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var email = new MailMessage(fromAddress.ToString(), address);
                AlternateView aw = AlternateView.CreateAlternateViewFromString("Espero tengan un buen día, les queremos hacer saber acerca de un nuevo animalito ingresado ahora a nuestro refugio en el cual podría estar interesado" + "\nEspecie: "+especie + "\nNombre: " + nombre + "\nEdad: "+ edad + "\nRaza: " + raza + "\nGenero: "+genero + "<br/><img src=cid:imgpath height=500 width=500/>", null, "text/html");
                LinkedResource lr = new LinkedResource("src/img/kv.jpg");

                lr.ContentId = "imgpath";
                aw.LinkedResources.Add(lr);
                email.AlternateViews.Add(aw);

                email.Subject = "Test Email Subject";
                email.Body = lr.ContentId;
                email.IsBodyHtml = false;

                smtp.Send(email);

            }
            return Ok();
        }
    }
}
