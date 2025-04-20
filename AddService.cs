using BLL.DAO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class AddService: Form
    {
        public AddService()
        {
            InitializeComponent();
            LoadFullServiceType();
        }

        private void AddService_Load(object sender, EventArgs e)
        {

        }

        public DataTable GetFullServiceType()
        {
            string query = "SELECT LoaiDichVu FROM DichVu GROUP BY LoaiDichVu";
            return DBConnection.Instance.ExecuteQuery(query);
        }

        private void LoadFullServiceType()
        {
            
            DataTable table = GetFullServiceType();
            cbType.DataSource = table;
            cbType.DisplayMember = "LoaiDichVu";
            if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }

        private void InsertService()
        {
            bool isFill = FormNhanVien.CheckFillInText(new string[] { txtName.Text, txtID.Text, txtPrice.Text, cbType.Text });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    ServiceDAO.Instance.InsertDichVu(
                        txtID.Text, txtName.Text, cbType.Text, "Sẵn sàng", double.Parse(txtPrice.Text), txtDescription.Text);

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 229)
                    {
                        MessageBox.Show("Bạn không có quyền truy cập vào chức năng này", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Close();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UserSession.Role == "Lễ tân")
            {
                MessageBox.Show("Lễ tân không có quyền thêm dịch vụ mới!", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có muốn thêm dịch vụ mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                InsertService();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
