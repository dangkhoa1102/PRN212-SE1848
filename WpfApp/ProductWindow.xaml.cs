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
        public ProductWindow()
        {
            InitializeComponent();
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = productService.GetProducts();
        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product
            {
                Id = int.Parse(txtMaSanPham.Text),
                Name = txtTenSanPham.Text,
                Quantity = int.Parse(txtSoLuong.Text),
                Price = double.Parse(txtDonGia.Text)
            };
            bool result = productService.SaveProduct(p);
            if(result)
            {
                lvProduct.ItemsSource = null; // Reset the ItemsSource to refresh the list
                lvProduct.ItemsSource = productService.GetProducts();
            }
        }
    }
}
