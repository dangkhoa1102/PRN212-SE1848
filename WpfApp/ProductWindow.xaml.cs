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
using BusinessObject;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService = new ProductService();
         bool isCompleted = false;
        public ProductWindow()
        {
            InitializeComponent();
            isCompleted = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
            isCompleted = true;
        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                Product p = new Product
                {
                    Id = int.Parse(txtMaSanPham.Text),
                    Name = txtTenSanPham.Text,
                    Quantity = int.Parse(txtSoLuong.Text),
                    Price = double.Parse(txtDonGia.Text)
                };
                bool result = productService.SaveProduct(p);
                if (result)
                {
                    lvProduct.ItemsSource = null; // Reset the ItemsSource to refresh the list
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lung tung rồi, chi tiết" + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvProduct.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                isCompleted = false;
                Product selectedProduct = (Product)lvProduct.SelectedItem;
                selectedProduct.Name = txtTenSanPham.Text;
                selectedProduct.Quantity = int.Parse(txtSoLuong.Text);
                selectedProduct.Price = double.Parse(txtDonGia.Text);
                bool result = productService.UpdateProduct(selectedProduct);
                if (result)
                {
                    lvProduct.ItemsSource = null; // Reset the ItemsSource to refresh the list
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lung tung rồi, chi tiết" + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
            {
                return;
            }
            if (e.AddedItems.Count > 0)
                {
                Product selectedProduct = (Product)e.AddedItems[0];
                txtMaSanPham.Text = selectedProduct.Id.ToString();
                txtTenSanPham.Text = selectedProduct.Name;
                txtSoLuong.Text = selectedProduct.Quantity.ToString();
                txtDonGia.Text = selectedProduct.Price.ToString("F2"); // Format price to 2 decimal places
            }
            else
            {
                // Clear the text fields if no item is selected
                txtMaSanPham.Clear();
                txtTenSanPham.Clear();
                txtSoLuong.Clear();
                txtDonGia.Clear();
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rs == MessageBoxResult.No)
                {
                    return; // User chose not to delete
                }

                if (lvProduct.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                isCompleted = false;
                Product selectedProduct = (Product)lvProduct.SelectedItem;
                bool result = productService.DeleteProduct(selectedProduct.Id);
                if (result)
                {
                    // Clear all text fields
                    txtMaSanPham.Clear();
                    txtTenSanPham.Clear();
                    txtSoLuong.Clear();
                    txtDonGia.Clear();

                    lvProduct.ItemsSource = null; // Reset the ItemsSource to refresh the list
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lung tung rồi, chi tiết" + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
