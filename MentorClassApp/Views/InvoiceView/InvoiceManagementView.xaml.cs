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
using DataAccessLayer;
using MentorClassApp.Views.ClassView;
using Repository;

namespace MentorClassApp.Views.InvoiceView
{
    /// <summary>
    /// Interaction logic for InvoiceManagementView.xaml
    /// </summary>
    public partial class InvoiceManagementView : UserControl
    {
        private readonly InvoiceRepository invoiceRepository;
        public InvoiceManagementView()
        {
            InitializeComponent();
            var context = new MentorClassManagementContext();
            invoiceRepository = new InvoiceRepository(context);
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            var incoices = invoiceRepository.GetAllInvoices();

            var data = incoices.Select((inv, index) => new InvoiceViewModel
            {
                InvoiceId = inv.InvoiceId,
                StudentName = inv.Enrollment?.Student?.FullName ?? "N/A",
                ClassName = inv.Enrollment?.Class?.ClassName ?? "N/A",
                InvoiceDate = inv.InvoiceDate,
                TotalAmount = inv.TotalAmount,
                PaidAmount = inv.Payments?.Sum(p => p.Amount) ?? 0,
                Status = inv.Status
            }).ToList();

            InvoiceDataGrid.ItemsSource = data;
        }

        private void InvoiceDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int invoiceId) {
                var detailView = new InvoiceDetailView(invoiceId);
                if (Window.GetWindow(this) is MainWindow mainWindow) {
                    mainWindow.LoadContent(detailView);
                }
            }
            else {
                MessageBox.Show("Không thể lấy được hóa đơn.");
            }
        }

      
    }
}
