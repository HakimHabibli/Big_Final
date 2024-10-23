using NotificationService.Models;
using System.Net.Mail;
using System.Net;

namespace NotificationService.Services;

public class EmailNotificationService : INotificationService
{
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _senderEmail = "77uptvc@code.edu.az"; 
    private readonly string _senderPassword = "roge ymad uakv bvel"; 

    public async Task SendNotificationAsync(Notification notification)
    {
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(_senderEmail);
        mailMessage.To.Add(notification.Recipient);
        mailMessage.Subject = "Notification";
        mailMessage.Body = notification.Message;

        using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
        {
            smtpClient.Credentials = new NetworkCredential(_senderEmail, _senderPassword);
            smtpClient.EnableSsl = true;

            await smtpClient.SendMailAsync(mailMessage);
        }

        Console.WriteLine($"Email sent to {notification.Recipient}: {notification.Message}");
    }
}
