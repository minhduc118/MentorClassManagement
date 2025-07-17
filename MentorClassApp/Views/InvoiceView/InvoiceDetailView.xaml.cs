using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;
using Repository;
using System.Net;
using System.Net.Mail;

namespace MentorClassApp.Views.InvoiceView
{
    /// <summary>
    /// Interaction logic for InvoiceDetailView.xaml
    /// </summary>
    public partial class InvoiceDetailView : UserControl
    {
        private int invoiceId;
        private InvoiceRepository _invoiceRepo;
        private Invoice _invoice;

        public Invoice Invoice => _invoice;
        public BitmapImage VietQrImage { get; set; }


        public InvoiceDetailView(int invoiceId)
        {
            InitializeComponent();
            this.invoiceId = invoiceId;

            var context = new MentorClassManagementContext();
            _invoiceRepo = new InvoiceRepository(context);
            LoadInvoice();
        }

        private void LoadInvoice()
        {
            // Lấy hóa đơn từ repository (bao gồm Enrollment, Student, Class, Payments)
            _invoice = _invoiceRepo.GetInvoiceByIdWithDetails(invoiceId);

            if (_invoice == null)
            {
                System.Windows.MessageBox.Show("Không tìm thấy hóa đơn.");
                return;
            }

            // Nếu hóa đơn không có danh sách thanh toán, khởi tạo rỗng
            if (_invoice.Payments == null)
            {
                _invoice.Payments = new List<Payment>();
            }

            // Tạo mã QR VietQR dựa trên số tiền và ID hóa đơn
            // => Đây là ảnh giả lập VietQR từ vietqr.io (dùng khi demo/offline)
            string qrUrl = $"https://img.vietqr.io/image/970422-123456789-qr_only.png?amount={_invoice.TotalAmount}&addInfo=Thanh+toan+hoa+don+{_invoice.Enrollment.Class.ClassName}";

            try
            {
                VietQrImage = new BitmapImage();
                VietQrImage.BeginInit();
                VietQrImage.UriSource = new Uri(qrUrl, UriKind.Absolute);
                VietQrImage.CacheOption = BitmapCacheOption.OnLoad;
                VietQrImage.EndInit();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi tải mã QR: " + ex.Message);
            }

            // Gắn lại DataContext để UI Binding cập nhật dữ liệu mới
            this.DataContext = null;
            this.DataContext = this;
        }
        private void SendEmail_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_invoice == null) return;

            try
            {
                // Lấy thông tin email người học
                string toEmail = _invoice.Enrollment.Student.Email;
                string studentName = _invoice.Enrollment.Student.FullName;
                string className = _invoice.Enrollment.Class.ClassName;

                string subject = $"[Hóa đơn #{_invoice.InvoiceId}] Thanh toán khóa học {className}";
                string body = $"Xin chào {studentName},\n\n"
                            + $"Bạn đã đăng ký lớp: {className}\n"
                            + $"Tổng tiền: {_invoice.TotalAmount:N0} đ\n"
                            + $"Vui lòng thanh toán theo thông tin dưới đây và phản hồi email sau khi hoàn tất.\n\n"
                            + $"Thông tin chuyển khoản QR đã đính kèm trong email này.\n\n"
                            + $"Trân trọng,\nTrung tâm Mentor Class";
                string qrUrl = $"https://img.vietqr.io/image/970422-123456789-qr_only.png?amount={_invoice.TotalAmount}&addInfo=Thanh+toan+hoa+don+{_invoice.Enrollment.Class.ClassName}";
                // Gửi email (giả định có phương thức SendEmailWithQrImage)
                EmailHelper.SendEmailWithQrImage(toEmail, subject, body, qrUrl);

                MessageBox.Show("Đã gửi email thanh toán cho học viên.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }
        private void ConfirmPaid_Click(object sender, RoutedEventArgs e)
        {
            if (_invoice == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn.");
                return;
            }

            try
            {
                _invoiceRepo.ConfirmPayment(_invoice);
                MessageBox.Show("Đã xác nhận thanh toán.");
                LoadInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận: " + ex.Message);
            }
        }
    }
}
