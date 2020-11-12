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
                // show item name
                // this.tableLayoutPanel1.GetControlFromPosition(x, y).Text = item;

                // add image of items in labels
                switch (item)
                {
                    case ("Potion"):
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Potion;
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        break;
                    case ("Regular Sword"):
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Regular_Sword;
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        break;
                    case ("Fire Sword"):
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Fire_Sword;
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        break;
                    case ("Lightning Sword"):
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Lightning_Sword;
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        break;
                    case ("Regular Staff"):
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Regular_Staff;
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        break;
                    case ("Magic Staff"):
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Magic_Staff;
                        this.tableLayoutPanel1.GetControlFromPosition(x, y).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        break;

                }

            // move on to next label                    
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
