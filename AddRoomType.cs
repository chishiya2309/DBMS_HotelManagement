using BLL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class AddRoomType: Form
    {
        public AddRoomType()
        {
            InitializeComponent();
        }

        private void InsertRoomType()
        {
            bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtName, txtID ,txtLimit, txtPrice });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //int idStaff = Convert.ToInt32(datagridviewStaff.SelectedRows[0].Cells["colidStaff"].Value);

                    bool check1 = RoomTypeDAO.Instance.InsertRoomType(int.Parse(txtID.Text), txtName.Text, double.Parse(txtPrice.Text), int.Parse(txtLimit.Text));


                    if (check1)
                    {
                        MessageBox.Show("Thêm loại phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Không thể Thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm loại phòng mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                InsertRoomType();
            }
        }
    }
}
