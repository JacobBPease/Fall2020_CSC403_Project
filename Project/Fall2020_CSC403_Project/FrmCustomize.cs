using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
    public partial class FrmCustomize : Form {

        public static FrmCustomize instance = null;
        private Bitmap[] players = { Resources.player_young, Resources.player_mannered, Resources.player_real, Resources.player_cursed, Resources.player };
        private int[] strengths = { 2, 3, 4, 1, 0};
        private int playerIndex = 0;

        public static event doneCustomizingDelegate DoneCustomizing;
        public delegate void doneCustomizingDelegate(Bitmap bitmap, int strength);

        public FrmCustomize() {
            InitializeComponent();
            BackColor = Color.LightSlateGray;
        }

        public static FrmCustomize GetInstance() {
            if (instance == null) {
                instance = new FrmCustomize();
            }
            return instance;
        }

        private void btnNext_Click(object sender, EventArgs e) {
            picPlayer.BackgroundImage = players[playerIndex];
            playerIndex++;
            if (playerIndex > players.Length - 1) { playerIndex = 0; }
        }

        private void btnDone_Click(object sender, EventArgs e) {
            DoneCustomizing((Bitmap)picPlayer.BackgroundImage, strengths[playerIndex]);
            instance = null;
            Close();
        }
    }
}
