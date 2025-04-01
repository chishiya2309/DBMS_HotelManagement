using BLL;
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
    public partial class FormQuanLyPhong: Form
    {
        public FormQuanLyPhong()
        {
            InitializeComponent();
            LoadFullRoomStatus();
            LoadFullRoomType();
            LoadFullRoom(GetFullRoom());

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Delete
        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá phòng này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                try
                {
                    int id = Convert.ToInt32(dgvRoom.CurrentRow.Cells["dgvIdRoom"].Value);
                    if (DeleteRoom(id))
                    {
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFullRoom(GetFullRoom());
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá phòng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public bool DeleteRoom(int id)
        {
            return RoomDAO.Instance.DeleteRoom(id);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public DataTable GetFullRoom()
        {
            return RoomDAO.Instance.LoadFullRoom();
        }



        public DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }

        private void LoadFullRoom(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dgvRoom.DataSource = source;
        }

        private void LoadFullRoomType()
        {
            
            DataTable table = GetFullRoomType();
            cbType.DataSource = table;
            cbType.DisplayMember = "typename";
            if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }

        public DataTable GetFullRoomStatus()
        {
            return StatusRoomDAO.Instance.LoadFullStatusRoom();
        }


        private void LoadFullRoomStatus()
        {

            DataTable table = GetFullRoomStatus();
            cbStatus.DataSource = table;
            cbStatus.DisplayMember = "name";
            if (table.Rows.Count > 0) cbStatus.SelectedIndex = 0;
        }

        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtIDroom.Text = string.Empty;
                txtLimit.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                

            }
            else
            {

                txtIDroom.Text = row.Cells["dgvIdRoom"].Value.ToString();
                txtLimit.Text = row.Cells["dgvLimit"].Value.ToString();
                txtName.Text = row.Cells["dgvName"].Value as string;
                txtPrice.Text = row.Cells["dgvPrice"].Value.ToString();

                cbStatus.SelectedIndex = (int)row.Cells["dgvStatusRoom"].Value - 1;
                cbType.SelectedIndex = (int)row.Cells["dgvType"].Value - 1;


            }
        }

        private void dgvRoom_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRoom.SelectedRows[0];
                ChangeText(row);
            }
        }

        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }

        private Room GetRoomNow()
        {
            Room account = new Room();

            // Xoá các khoảng trắng thừa
            //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });

            int index1 = cbType.SelectedIndex;
            int index2 = cbStatus.SelectedIndex;
            account.Id = int.Parse(txtIDroom.Text);
            account.IdRoomType = (int)((DataTable)cbType.DataSource).Rows[index1]["idRoomType"];
            account.IdStatusRoom = (int)((DataTable)cbStatus.DataSource).Rows[index2]["id"];
            account.Name = txtName.Text;
            
            return account;
        }

        private RoomType GetRoomTypeNow()
        {
            RoomType account = new RoomType();

            // Xoá các khoảng trắng thừa
            //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });

            int index = cbType.SelectedIndex;
            
            account.Id = (int)((DataTable)cbType.DataSource).Rows[index]["idRoomType"];
            account.Name = ((DataTable)cbType.DataSource).Rows[index]["typename"].ToString();
            account.Limit = int.Parse(txtLimit.Text);
            account.Price = double.Parse(txtPrice.Text);

            return account;
        }

        private void UpdateRoom()
        {
            bool isFill = CheckFillInText(new Control[] { txtName, txtLimit, txtPrice });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //int idStaff = Convert.ToInt32(dgvService.SelectedRows[0].Cells["dgvIdservice"].Value);


                    bool check1 = RoomTypeDAO.Instance.UpdateRoomType(GetRoomTypeNow());
                    bool check2 = RoomDAO.Instance.UpdateRoom(GetRoomNow());

                    if (check1 && check2)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int index = dgvRoom.SelectedRows[0].Index;
                        LoadFullRoom(GetFullRoom());
                        dgvRoom.SelectedRows[0].Selected = false;
                        dgvRoom.Rows[index].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật phòng và loại phòng tương ứng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                UpdateRoom();

            }
        }

        private void FormQuanLyPhong_Load(object sender, EventArgs e)
        {
            txtIDroom.Enabled = false;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new AddRoom().ShowDialog();
            LoadFullRoomType();
            LoadFullRoom(GetFullRoom());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //LoadFullRoomType();
                //LoadFullRoomStatus();
                LoadFullRoom(RoomDAO.Instance.Search(cbStatusSearch.Text));
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi xảy ra: " + ex);
            }
        }
    }
}
