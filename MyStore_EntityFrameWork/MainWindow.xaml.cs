using MyStore_EntityFrameWork.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyStore_EntityFrameWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public MainWindow()
        {
            InitializeComponent();
            ChangeBackground();
        }
        private void ChangeBackground()
        {
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            brush.GradientStops.Add(new GradientStop(Colors.Purple, 1.0));
            brush.GradientStops.Add(new GradientStop(Colors.RosyBrown, 0.5));
            btnThoat.Background = brush;
            //Đổi màu nền nút đăng nhập
            RadialGradientBrush brush2 = new RadialGradientBrush();
            brush2.GradientStops.Add(new GradientStop(Colors.Green, 0.0));
            brush2.GradientStops.Add(new GradientStop(Colors.LightCyan, 1.0));
            brush2.GradientStops.Add(new GradientStop(Colors.LightCoral, 0.5));
            btnDangNhap.Background = brush2;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password.Trim();
            AccountMember account = context.AccountMembers.FirstOrDefault(a => a.EmailAddress == email && a.MemberPassword == password);
            if (account == null)
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                
                return;
            }
            else
            {
                if(account.MemberRole == 1)
                {
                    MessageBox.Show("Đăng nhập Admin Thành Công","Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                    return;
                }
                else if (account.MemberRole == 2)
                {
                    MessageBox.Show("Đăng nhập Staff Thành Công", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    StaffWindow staffWindow= new StaffWindow();
                    staffWindow.Show();
                    return;
                }
                else if (account.MemberRole == 3)
                {
                    MessageBox.Show("Đăng nhập Member Thành Công", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    MemberWindow memberWindow = new MemberWindow();
                    memberWindow.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
    }}
}