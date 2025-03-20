using BLL;
using BLL.DAO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormThongTin: Form
    {
        public FormThongTin(int id)
        {
            InitializeComponent();
            LoadProfile(id);
        }

        public void LoadProfile(int id)
        {
            Staff staff = StaffDAO.Instance.LoadStaffInforById(id);
            DataTable acc = AccountDAO.Instance.GetAccountById(id);
            label1.Text = staff.Fullname;
            textBox1.Text = acc.Rows[0]["userName"].ToString();
            textBox2.Text = staff.Fullname;
            textBox6.Text = staff.IdNumber;
            textBox7.Text = staff.Address;
            textBox8.Text = staff.Phone;
            guna2DateTimePicker1.Value = staff.DoB;
            comboBox1.Text = staff.Sex;
        }

        private void FormThongTin_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
