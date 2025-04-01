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
    public partial class FormBookingTest: Form
    {
        public FormBookingTest()
        {
            InitializeComponent();
            dgvBookRoom.ScrollBars = ScrollBars.Both; // Hiển thị cả thanh cuộn ngang và dọc
        }

        private void FormBookingTest_Load(object sender, EventArgs e)
        {

        }
    }
}
