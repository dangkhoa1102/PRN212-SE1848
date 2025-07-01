using MyStore_EntityFrameWork.Models;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyStore_EntityFrameWork
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoriesIntoTreeView();
        }

        private void LoadCategoriesIntoTreeView()
        {
            //Tạo gốc cây
            TreeViewItem root = new TreeViewItem();
            root.Header = "Kho hàng Cát Lái";
            tvCategory.Items.Add(root);
            //Truy vấn toàn bộ danh mục
            var categories = context.Categories.ToList();
            //Đưa danh mục lên treeview
            foreach (var category in categories)
            {
                TreeViewItem category_node = new TreeViewItem();
                category_node.Header = category.CategoryName;
                category_node.Tag = category;
                root.Items.Add(category_node);
                var products = context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
                //Nap product vao node danh muc tuong ung
                foreach (var product in products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    category_node.Items.Add(product_node); // Changed from root.Items to category_node.Items
                }
            }
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) return;
            TreeViewItem item = e.NewValue as TreeViewItem;
            if(item == null) return;
            Category category = item.Tag as Category;
            if(category == null) return;
            LoadProductsIntoListView(category);
        }

        private void LoadProductsIntoListView(Category category)
        {
            var products = context.Products
                    .Where(x => x.CategoryId == category.CategoryId)
                    .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }
    }
}
