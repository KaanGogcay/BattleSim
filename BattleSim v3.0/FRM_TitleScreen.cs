using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleSim_v3._0
{
    public partial class FRM_TitleScreen : Form
    {
        public FRM_TitleScreen()
        {
            InitializeComponent();
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FRM_ChooseNeoFighter(this).Show();
        }
    }
}
