using DemoLINQ2SQL;
using System.Text;
Console.OutputEncoding= Encoding.UTF8;
string connecttionString = "server=localhost;database=MyStore;uid=sa;pwd=12345;TrustServerCertificate=true;";
MyStoreDataContext db = new MyStoreDataContext(connecttionString);
var dsdm = db.Categories.ToList();
Console.WriteLine("========= Danh sach danh muc =========");
foreach (var d in dsdm)
{
    Console.WriteLine($"ID: {d.CategoryID}, Ten: {d.CategoryName}");
}
//cau 2
int madm = 7;
Category cate = db.Categories.FirstOrDefault(c => c.CategoryID == madm);
if (cate == null)
{
    Console.WriteLine($"Khong tim thay danh muc co ID = {madm}");
}
else
{
    Console.WriteLine($"Danh muc co ID = {madm} la: {cate.CategoryName}");
}
//cau 3 dung Query syntax de truy cap toan bo san pham
var dssp = from p in db.Products
            select p;
Console.WriteLine("========= Danh sach san pham =========");
foreach (var p in dssp)
{
    Console.WriteLine($"{p.ProductID}\t{p.ProductName}\t{p.UnitPrice}\t{p.Category.CategoryName}");
}
//Cau 4: dung Query syntax va Anonymous type de loc ra 
// cac san pham nhung chi lay ma san pham va don gia
var dssp4 = from p in db.Products
            orderby p.UnitPrice descending
            select new
            {
                p.ProductID,
                p.UnitPrice
            };
Console.WriteLine("========= Danh sach san pham (ma san pham, don gia) =========");
foreach (var p in dssp4)
{
    Console.WriteLine($"{p.ProductID}\t{p.UnitPrice}");
}
//cau 5
var dssp5 = db.Products
            .OrderByDescending(p => p.UnitPrice)
            .Select(p => new
            {
                p.ProductID,
                p.UnitPrice
            });
Console.WriteLine("========= Danh sach san pham theo cau 5 =========");
foreach (var p in dssp5)
{
    Console.WriteLine($"{p.ProductID}\t{p.UnitPrice}");
}
//cau 6: loc ra top 3 san pham co gia tri lon nhat he thong
var dssp6 = (from p in db.Products
             orderby p.UnitPrice descending
             select p).Take(3);
Console.WriteLine("========= Top 3 san pham co don gia cao nhat =========");
foreach (var p in dssp6)
{
    Console.WriteLine($"{p.ProductID}\t{p.ProductName}\t{p.UnitPrice}\t{p.Category.CategoryName}");
}
//cau 7: Sua ten danh muc khi biet ma
var madm7 = 3;
Category cate7 = db.Categories.FirstOrDefault(c => c.CategoryID == madm7);
if (cate7 == null)
{
    Console.WriteLine($"Khong tim thay danh muc co ID = {madm7}");
}
else
{
    cate7.CategoryName = "Danh muc moi";
    db.SubmitChanges();
    Console.WriteLine($"Da sua ten danh muc co ID = {madm7} thanh: {cate7.CategoryName}");
}
//cau 8: xoa danh muc khi biet ma
var madm8 = 4;
Category cate8 = db.Categories.FirstOrDefault(c => c.CategoryID == madm8);
if (cate8 == null)
{
    Console.WriteLine($"Khong tim thay danh muc co ID = {madm8}");
}
else
{
    db.Categories.DeleteOnSubmit(cate8);
    db.SubmitChanges();
    Console.WriteLine($"Da xoa danh muc co ID = {madm8}");
}
//cau 9: xoa cac danh muc neu khong co san pham nao
//Luu y: la xoa cung 1 luc nhieu danh muc, ma cac danh muc nay khong co san pham nao
var dsdm9 = db.Categories.Where(c => !c.Products.Any()).ToList();
if (dsdm9.Count == 0)
{
    Console.WriteLine("Khong co danh muc nao khong co san pham");
}
else
{
    db.Categories.DeleteAllOnSubmit(dsdm9);
    db.SubmitChanges();
    Console.WriteLine($"Da xoa {dsdm9.Count} danh muc khong co san pham");
}
