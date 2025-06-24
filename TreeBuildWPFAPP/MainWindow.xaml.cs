using System.ComponentModel.DataAnnotations;
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
using TreeBuildWPFAPP.models;

namespace TreeBuildWPFAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<int, Category> categories = SampleDataSet.GenerateDataset();
        public MainWindow()
        {
            InitializeComponent();
            DisplayDataIntoTreeView();
        }
        private void DisplayDataIntoTreeView()
        {
            //Xóa dữ liệu cũ đi
            tvCategory.Items.Clear();
            //Tạo nút gốc
            TreeViewItem rootItem = new TreeViewItem() { Header = "Kho Hàng Biên Hòa" };
            tvCategory.Items.Add(rootItem);
            foreach (KeyValuePair<int, Category> item in categories)
            {
                Category cate = item.Value;
                TreeViewItem cate_node = new TreeViewItem() { Header = cate };
                rootItem.Items.Add(cate_node);
                foreach (KeyValuePair<int, Product> product in cate.Products)
                {
                    Product p = product.Value;
                    TreeViewItem product_node = new TreeViewItem() { Header = p };
                    cate_node.Items.Add(product_node);
                }
            }
        }
    }
}