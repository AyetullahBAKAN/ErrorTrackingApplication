using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Service.Service
{
    public class MailService : Service<Mail>
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public MailService(IGenericRepository<Mail> repository, 
                            IUnitOfWork unitOfWork,
                            IMapper mapper, 
                            IConfiguration configuration)
            : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMessageAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;

            foreach (var to in tos)
                mail.To.Add(to);

            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(_configuration["Mail:Username"]!, " Beycelik Gestamp ", System.Text.Encoding.UTF8);

            using (SmtpClient smtp = new())
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Host = _configuration["Mail:Host"]!;

                try
                {
                    await smtp.SendMailAsync(mail);
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine($"SMTP Hatası: {ex.Message}");
                }
            }
        }


        public async Task<List<MailDto>> GetMailListAsync()
        {
            try
            {
                var mailList = await GetListAsync(x => !x.IsDeleted);
                var mailListDto = _mapper.Map<List<MailDto>>(mailList.ToList());
                return mailListDto;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
