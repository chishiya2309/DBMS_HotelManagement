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
    public partial class AddRoom: Form
    {
        public AddRoom()
        {
            InitializeComponent();
            LoadFullRoomType();
        }

        public DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }

        private void LoadFullRoomType()
        {

            DataTable table = GetFullRoomType();
            cbType.DataSource = table;
            cbType.DisplayMember = "typename";
            if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }

        private void InsertRoom()
        {
            bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtName });
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
                    int index = cbType.SelectedIndex;
                    bool check1 = RoomDAO.Instance.InsertRoom(txtName.Text, (int)((DataTable)cbType.DataSource).Rows[index]["idRoomType"], 1);


                    if (check1)
                    {
                        MessageBox.Show("Thêm phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            DialogResult result = MessageBox.Show("Bạn có muốn thêm phòng mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                InsertRoom();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            new AddRoomType().ShowDialog();
            LoadFullRoomType();
        }
    }
}
