using System.Net;
using System.Net.Mail;
using Azure;
using Azure.Communication.Email;
using MangaApi.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MangaApi.Services;

public class EmailService : IEmailSender
{
    private readonly ILogger<EmailService> _logger;
    private readonly EmailOptions _emailOptions;

    public EmailService(ILogger<EmailService> logger, EmailOptions emailOptions)
    {
        _logger = logger;
        _emailOptions = emailOptions;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        try
        {
            EmailClient emailClient = new EmailClient(_emailOptions.ConnectionString);

            // Create the email content
            EmailContent emailContent = new EmailContent(subject)
            {
                Html = body
            };

            // Create the EmailMessage
            EmailMessage emailMessage = new EmailMessage
            (
                senderAddress: _emailOptions.SenderAddress, // The email address of the domain registered with the Communication Services resource
                recipientAddress: to,
                content: emailContent
            );

            EmailSendOperation emailSendOperation = await emailClient.SendAsync
            (
                wait: WaitUntil.Completed,
                message: emailMessage
            );
                
            _logger.LogInformation($"Email Sent. Status = {emailSendOperation.Value.Status}");
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
        }
    }
}