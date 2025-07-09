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
using Services;

namespace MentorClassApp.Views.Class
{
    /// <summary>
    /// Interaction logic for AddEditClassWindow.xaml
    /// </summary>
    public partial class AddEditClassWindow : Window
    {
        public MentorClass ClassInfo { get; private set; }
        public bool IsEditMode { get; }
        public AddEditClassWindow()
        {
            InitializeComponent();
            ClassInfo = new MentorClass();
            IsEditMode = false;
        }

        public AddEditClassWindow(MentorClass classToEdit) {
            InitializeComponent();
            ClassInfo = new MentorClass
            {
                ClassId = classToEdit.ClassId,
                ClassName = classToEdit.ClassName,
                Description = classToEdit.Description,
                StartDate = classToEdit.StartDate,
                EndDate = classToEdit.EndDate,
                TuitionFee = classToEdit.TuitionFee
            };

            txtClassName.Text = ClassInfo.ClassName;
            txtDescription.Text = ClassInfo.Description;
            dpStartDate.SelectedDate = ClassInfo.StartDate.ToDateTime(TimeOnly.MinValue);
            dpEndDate.SelectedDate = ClassInfo.EndDate.ToDateTime(TimeOnly.MinValue);
            txtTuitionFee.Text = ClassInfo.TuitionFee.ToString();
            IsEditMode = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // ... validate như trước
            if (string.IsNullOrWhiteSpace(txtClassName.Text)) {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // ...
            if (!decimal.TryParse(txtTuitionFee.Text, out decimal tuitionFee) || tuitionFee < 0) {
                MessageBox.Show("Học phí không hợp lệ!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateOnly? startDate = dpStartDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpStartDate.SelectedDate.Value) : null;
            DateOnly? endDate = dpEndDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpEndDate.SelectedDate.Value) : null;

            if (startDate.HasValue && endDate.HasValue && startDate > endDate) {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

          

            // Khởi tạo service/repository bình thường
            var context = new MentorClassManagementContext();
            var repo = new ClassRepository(context);
            var service = new ClassService(repo);

            if (!IsEditMode)
            {
                // Kiểm tra trùng tên nếu cần
                // Tạo mới  
                ClassInfo.ClassName = txtClassName.Text.Trim();
                ClassInfo.Description = txtDescription.Text.Trim();
                ClassInfo.StartDate = startDate.Value;
                ClassInfo.EndDate = endDate.Value;
                ClassInfo.TuitionFee = tuitionFee;

                // Optionally kiểm tra trùng tên lớp  
                var exist = service.GetAllClasses().FirstOrDefault(c => c.ClassName.ToLower() == ClassInfo.ClassName.ToLower());
                if (exist != null)
                {
                    MessageBox.Show("Tên lớp đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    service.AddClass(ClassInfo);
                    MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm lớp: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Kiểm tra trùng tên nếu cần
                // Tạo mới  
                ClassInfo.ClassName = txtClassName.Text.Trim();
                ClassInfo.Description = txtDescription.Text.Trim();
                ClassInfo.StartDate = startDate.Value;
                ClassInfo.EndDate = endDate.Value;
                ClassInfo.TuitionFee = tuitionFee;

                // Optionally kiểm tra trùng tên lớp  
                var exist = service.GetAllClasses().FirstOrDefault(c => c.ClassName.ToLower() == ClassInfo.ClassName.ToLower());
                if (exist != null)
                {
                    MessageBox.Show("Tên lớp đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    service.UpdateClass(ClassInfo);
                    MessageBox.Show("Cập nhật lớp thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật lớp: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
