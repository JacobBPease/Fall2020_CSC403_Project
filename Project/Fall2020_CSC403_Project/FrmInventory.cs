using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmInventory : Form
    {
        public FrmInventory()
        {
            InitializeComponent();
        }

        public void FormatItems(List<string> inventory)
        {
            int x = 0;
            int y = 0;
            foreach (string item in inventory)
            {
                this.tableLayoutPanel1.GetControlFromPosition(x, y).Text = item;
                x++;
                if (x == 3)
                {
                    x = 0;
                    y++;
                }
            };

         
        }
    }
}
