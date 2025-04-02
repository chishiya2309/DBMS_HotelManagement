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
            //bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtName, txtID, txtPrice , cbType});
            //if (!isFill)
            //{
            //    MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    try
            //    {
            //        //int idStaff = Convert.ToInt32(datagridviewStaff.SelectedRows[0].Cells["colidStaff"].Value);
            //        //int index = cbType.SelectedIndex;
            //        //bool check1 = ServiceDAO.Instance.InsertService(int.Parse(txtID.Text), txtName.Text, (int)((DataTable)cbType.DataSource).Rows[index]["id"],
            //        //                double.Parse(txtPrice.Text));

            //        ServiceDAO.Instance.InsertDichVu(
            //            txtID.Text, txtName.Text, cbType.Text, "Sẵn sàng", double.Parse(txtPrice.Text), txtDescription.Text);


                    
            //    }
            //    catch (SqlException ex)
            //    {
            //        MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
