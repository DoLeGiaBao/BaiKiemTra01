using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechMartProductManager;

namespace Bai03Windowsforms
{
    public partial class Form1 : Form
    {
        private BindingList<Product> _productList;
        private BindingSource _bindingSource;
        private List<Category> _categoryList;
        private string _selectedImagePath = "";

        public Form1()
        {
            InitializeComponent();
            InitCustomComponents();
        }

        // =========================================================
        // 1. CẤU HÌNH GIAO DIỆN
        // =========================================================
        private void InitCustomComponents()
        {
            // Cấu hình phím tắt Menu Strip
            exportCSVCtrlEToolStripMenuItem.ShortcutKeys =
                Keys.Control | Keys.E;

            exitCtrlXToolStripMenuItem.ShortcutKeys =
                Keys.Control | Keys.X;

            // Cấu hình PictureBox
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;

            // Cấu hình ErrorProvider
            errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

            // =====================================================
            // CẤU HÌNH DATAGRIDVIEW
            // =====================================================
            dgvProducts.AutoGenerateColumns = false;

            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AllowUserToResizeRows = false;

            dgvProducts.ReadOnly = true;

            dgvProducts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProducts.MultiSelect = false;

            // Tự động chia đều chiều rộng các cột
            dgvProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Chiều cao dòng
            dgvProducts.RowTemplate.Height = 30;

            // Chiều cao header
            dgvProducts.ColumnHeadersHeight = 30;

            // Căn giữa tiêu đề
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Không cho header bị xuống dòng
            dgvProducts.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // Căn dữ liệu mặc định
            dgvProducts.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Không tự động tạo dòng trống cuối bảng
            dgvProducts.AllowUserToAddRows = false;
        }

        // =========================================================
        // 2. LOAD DANH MỤC
        // =========================================================
        private void LoadCategoryData()
        {
            _categoryList = new List<Category>
            {
                new Category(1, "Điện thoại"),
                new Category(2, "Laptop"),
                new Category(3, "Phụ kiện")
            };

            cboCategory.DataSource = _categoryList;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }

        // =========================================================
        // 3. KHỞI TẠO DỮ LIỆU SẢN PHẨM
        // =========================================================
        private void InitDataBinding()
        {
            _productList = new BindingList<Product>
            {
                new Product(
                    "SP001",
                    "Laptop Dell XPS 13",
                    2,
                    "Laptop",
                    25000000m,
                    10,
                    ""
                ),

                new Product(
                    "SP002",
                    "iPhone 15 Pro",
                    1,
                    "Điện thoại",
                    28000000m,
                    15,
                    ""
                ),

                new Product(
                    "SP003",
                    "Tai nghe AirPods Pro",
                    3,
                    "Phụ kiện",
                    5500000m,
                    30,
                    ""
                )
            };

            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _productList;

            dgvProducts.DataSource = _bindingSource;
        }

        // =========================================================
        // 4. CẤU HÌNH CÁC CỘT DATAGRIDVIEW
        // =========================================================
        private void SetupDataGridViewColumns()
        {
            dgvProducts.Columns.Clear();

            // -----------------------------------------------------
            // CỘT MÃ SẢN PHẨM
            // -----------------------------------------------------
            DataGridViewTextBoxColumn colProductId =
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProductId",
                    HeaderText = "Mã SP",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 15
                };

            colProductId.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.Add(colProductId);

            // -----------------------------------------------------
            // CỘT TÊN SẢN PHẨM
            // -----------------------------------------------------
            DataGridViewTextBoxColumn colProductName =
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProductName",
                    HeaderText = "Tên Sản Phẩm",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 30
                };

            colProductName.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvProducts.Columns.Add(colProductName);

            // -----------------------------------------------------
            // CỘT DANH MỤC
            // -----------------------------------------------------
            DataGridViewTextBoxColumn colCategory =
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CategoryName",
                    HeaderText = "Danh Mục",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 20
                };

            colCategory.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.Add(colCategory);

            // -----------------------------------------------------
            // CỘT ĐƠN GIÁ
            // -----------------------------------------------------
            DataGridViewTextBoxColumn colPrice =
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "UnitPrice",
                    HeaderText = "Đơn Giá (VNĐ)",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 22
                };

            colPrice.DefaultCellStyle.Format = "N0";

            colPrice.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvProducts.Columns.Add(colPrice);

            // -----------------------------------------------------
            // CỘT SỐ LƯỢNG
            // -----------------------------------------------------
            DataGridViewTextBoxColumn colQty =
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "Số Lượng",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 13
                };

            colQty.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.Add(colQty);
        }

        // =========================================================
        // 5. KIỂM TRA DỮ LIỆU
        // =========================================================
        private bool ValidateInputs()
        {
            bool isValid = true;

            errorProvider1.Clear();

            // Kiểm tra mã sản phẩm
            if (string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                errorProvider1.SetError(
                    txtProductId,
                    "Mã sản phẩm không được để trống!"
                );

                isValid = false;
            }

            // Kiểm tra tên sản phẩm
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(
                    txtProductName,
                    "Tên sản phẩm không được để trống!"
                );

                isValid = false;
            }

            // Kiểm tra đơn giá
            decimal price;

            if (!decimal.TryParse(txtUnitPrice.Text, out price) ||
                price <= 0)
            {
                errorProvider1.SetError(
                    txtUnitPrice,
                    "Đơn giá phải là số lớn hơn 0!"
                );

                isValid = false;
            }

            // Kiểm tra số lượng
            int qty;

            if (!int.TryParse(txtQuantity.Text, out qty) ||
                qty < 0)
            {
                errorProvider1.SetError(
                    txtQuantity,
                    "Số lượng phải là số nguyên lớn hơn hoặc bằng 0!"
                );

                isValid = false;
            }

            return isValid;
        }

        // =========================================================
        // 6. KHI CHỌN SẢN PHẨM TRONG DATAGRIDVIEW
        // =========================================================
        private void dgvProducts_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvProducts.CurrentRow != null &&
                dgvProducts.CurrentRow.DataBoundItem != null)
            {
                Product selectedProduct =
                    (Product)dgvProducts.CurrentRow.DataBoundItem;

                txtProductId.Text =
                    selectedProduct.ProductId;

                txtProductName.Text =
                    selectedProduct.ProductName;

                cboCategory.SelectedValue =
                    selectedProduct.CategoryId;

                txtUnitPrice.Text =
                    selectedProduct.UnitPrice.ToString("G0");

                txtQuantity.Text =
                    selectedProduct.Quantity.ToString();

                _selectedImagePath =
                    selectedProduct.ImagePath;

                if (!string.IsNullOrEmpty(_selectedImagePath) &&
                    File.Exists(_selectedImagePath))
                {
                    picAvatar.Image =
                        Image.FromFile(_selectedImagePath);
                }
                else
                {
                    picAvatar.Image = null;
                }
            }
        }

        // =========================================================
        // 7. TEXTBOX MÃ SẢN PHẨM
        // =========================================================
        private void txtProductId_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        // =========================================================
        // 8. TÌM KIẾM SẢN PHẨM
        // =========================================================
        private void textBox1_TextChanged(
            object sender,
            EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                _bindingSource.DataSource =
                    _productList;
            }
            else
            {
                var filtered =
                    _productList
                    .Where(p =>
                        p.ProductName
                            .ToLower()
                            .Contains(keyword)
                        ||
                        p.ProductId
                            .ToLower()
                            .Contains(keyword))
                    .ToList();

                _bindingSource.DataSource =
                    new BindingList<Product>(filtered);
            }
        }

        // =========================================================
        // 9. FORM LOAD
        // =========================================================
        private void Form1_Load(
            object sender,
            EventArgs e)
        {
            LoadCategoryData();

            InitDataBinding();

            SetupDataGridViewColumns();

            UpdateStatusCount();
        }

        // =========================================================
        // 10. CHỌN ẢNH
        // =========================================================
        private void btnChooseImage_Click(
            object sender,
            EventArgs e)
        {
            using (OpenFileDialog ofd =
                   new OpenFileDialog())
            {
                ofd.Title =
                    "Chọn ảnh đại diện sản phẩm";

                ofd.Filter =
                    "File Ảnh (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (ofd.ShowDialog() ==
                    DialogResult.OK)
                {
                    _selectedImagePath =
                        ofd.FileName;

                    picAvatar.Image =
                        Image.FromFile(_selectedImagePath);
                }
            }
        }

        // =========================================================
        // 11. THÊM SẢN PHẨM
        // =========================================================
        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string id =
                txtProductId.Text.Trim();

            // Kiểm tra mã trùng
            if (_productList.Any(
                p => p.ProductId.Equals(
                    id,
                    StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "Mã sản phẩm này đã tồn tại!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Category cat =
                (Category)cboCategory.SelectedItem;

            Product newProd =
                new Product(
                    id,
                    txtProductName.Text.Trim(),
                    cat.Id,
                    cat.Name,
                    decimal.Parse(txtUnitPrice.Text),
                    int.Parse(txtQuantity.Text),
                    _selectedImagePath
                );

            _productList.Add(newProd);

            UpdateStatusCount();

            ClearInputs();

            MessageBox.Show(
                "Thêm sản phẩm thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =========================================================
        // 12. CẬP NHẬT SẢN PHẨM
        // =========================================================
        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
                return;

            if (!ValidateInputs())
                return;

            Product currentProd =
                (Product)dgvProducts
                .CurrentRow
                .DataBoundItem;

            Category cat =
                (Category)cboCategory.SelectedItem;

            currentProd.ProductName =
                txtProductName.Text.Trim();

            currentProd.CategoryId =
                cat.Id;

            currentProd.CategoryName =
                cat.Name;

            currentProd.UnitPrice =
                decimal.Parse(txtUnitPrice.Text);

            currentProd.Quantity =
                int.Parse(txtQuantity.Text);

            currentProd.ImagePath =
                _selectedImagePath;

            _bindingSource.ResetBindings(false);

            MessageBox.Show(
                "Cập nhật thông tin sản phẩm thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =========================================================
        // 13. XÓA SẢN PHẨM
        // =========================================================
        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
                return;

            Product currentProd =
                (Product)dgvProducts
                .CurrentRow
                .DataBoundItem;

            DialogResult dr =
                MessageBox.Show(
                    string.Format(
                        "Bạn có chắc chắn muốn xóa sản phẩm \"{0}\" không?",
                        currentProd.ProductName
                    ),
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (dr == DialogResult.Yes)
            {
                _productList.Remove(currentProd);

                UpdateStatusCount();

                ClearInputs();

                MessageBox.Show(
                    "Đã xóa sản phẩm thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // =========================================================
        // 14. CẬP NHẬT SỐ LƯỢNG SẢN PHẨM
        // =========================================================
        private void UpdateStatusCount()
        {
            lblStatus.Text =
                string.Format(
                    "Tổng số sản phẩm: {0}",
                    _productList.Count
                );
        }

        // =========================================================
        // 15. XÓA DỮ LIỆU NHẬP
        // =========================================================
        private void ClearInputs()
        {
            txtProductId.Clear();

            txtProductName.Clear();

            txtUnitPrice.Clear();

            txtQuantity.Clear();

            if (cboCategory.Items.Count > 0)
                cboCategory.SelectedIndex = 0;

            picAvatar.Image = null;

            _selectedImagePath = "";

            errorProvider1.Clear();
        }

        // =========================================================
        // 16. STATUS STRIP
        // =========================================================
        private void statusStrip1_ItemClicked(
            object sender,
            ToolStripItemClickedEventArgs e)
        {
        }

        // =========================================================
        // 17. MENU FILE -> EXPORT CSV
        // =========================================================
        private void exportCSVCtrlEToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            ExportToCSV();
        }

        // =========================================================
        // 18. MENU FILE -> EXIT
        // =========================================================
        private void exitCtrlXToolStripMenuItem_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }

        // =========================================================
        // 19. EXPORT CSV
        // Không mở File Explorer / SaveFileDialog
        // Tự động lưu CSV vào Desktop
        // =========================================================
        private void ExportToCSV()
        {
            try
            {
                // Lấy đường dẫn Desktop
                string desktopPath =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.Desktop
                    );

                // Tên file CSV
                string filePath =
                    Path.Combine(
                        desktopPath,
                        "DanhSachSanPham_TechMart.csv"
                    );

                StringBuilder sb =
                    new StringBuilder();

                // Header
                sb.AppendLine(
                    "MaSP,TenSanPham,DanhMuc,DonGia,SoLuong"
                );

                // Dữ liệu
                foreach (Product p in _productList)
                {
                    sb.AppendLine(
                        string.Format(
                            "\"{0}\",\"{1}\",\"{2}\",{3},{4}",
                            p.ProductId,
                            p.ProductName,
                            p.CategoryName,
                            p.UnitPrice,
                            p.Quantity
                        )
                    );
                }

                // Ghi file UTF-8
                File.WriteAllText(
                    filePath,
                    sb.ToString(),
                    Encoding.UTF8
                );

                MessageBox.Show(
                    "Xuất dữ liệu thành công!\n\n" +
                    "File đã được lưu tại Desktop:\n" +
                    "DanhSachSanPham_TechMart.csv",
                    "Export CSV",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi xuất file CSV:\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}