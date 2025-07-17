using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BusinessObjects
{
    public static class EmailHelper
    {
        public static void SendEmailWithQrImage(string toEmail, string subject, string body, string imageUrl)
        {
            using (var message = new MailMessage())
            {
                message.From = new MailAddress("ducddmh187017@fpt.edu.vn", "Mentor Class");
                message.To.Add(toEmail);
                message.Subject = subject;
                message.IsBodyHtml = true;

                // Tạo nội dung HTML có chèn ảnh QR nếu có
                string htmlBody = $"<p>{body.Replace("\n", "<br>")}</p>";
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    htmlBody += $"<p><img src='{imageUrl}' alt='QR Code' style='width:200px; height:auto;'/></p>";
                }

                message.Body = htmlBody;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("ducddmhe187017@fpt.edu.vn", "sjdp rulx dihq ftbi"); // Mật khẩu ứng dụng
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi gửi email: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}
