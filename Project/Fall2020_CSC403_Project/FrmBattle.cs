using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
    public partial class FrmBattle : Form {
        public static FrmBattle instance = null;
        private Enemy enemy;
        private Player player;
        private bool isBossFight = false;
        
        private FrmBattle() {
            InitializeComponent();
            player = Game.player;
        }

        public void Setup() {
            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;
            picLost.Visible = false;
            picWin.Visible = false;

            // Observer pattern
            enemy.AttackEvent += PlayerDamage;
            player.AttackEvent += EnemyDamage;

            // show health
            UpdateHealthBars();
        }

        public void SetupForBossBattle() {
            picBossBattle.Location = Point.Empty;
            picBossBattle.Size = ClientSize;
            picBossBattle.Visible = true;

            SoundPlayer simpleSound = new SoundPlayer(Resources.final_battle);
            simpleSound.Play();

            tmrFinalBattle.Enabled = true;
            isBossFight = true;
        }

        public static FrmBattle GetInstance(Enemy enemy) {
            if (instance == null) {
                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.Setup();
            }
            return instance;
        }

        private void UpdateHealthBars() {
            float playerHealthPer = player.Health / (float)player.MaxHealth;
            float enemyHealthPer = enemy.Health / (float)enemy.MaxHealth;

            const int MAX_HEALTHBAR_WIDTH = 226;
            lblPlayerHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * playerHealthPer);
            lblEnemyHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * enemyHealthPer);

            lblPlayerHealthFull.Text = player.Health.ToString();
            lblEnemyHealthFull.Text = enemy.Health.ToString();
        }

        private void btnAttack_Click(object sender, EventArgs e) {
            player.OnAttack(-4);
            if (enemy.Health > 0) {
                enemy.OnAttack(-2);
            }

            UpdateHealthBars();

            // Determine if the game is over
            if (player.Health <= 0) { GameOver(false); }
            else if (enemy.Health <= 0 && isBossFight == true) { GameOver(true); }
            else if (enemy.Health <= 0) {
                instance = null;
                Close();
            }
        }

        /// <summary>
        /// Method which displays image and sound depending on whether or not the player has died
        /// or defeated the final boss.
        /// </summary>
        /// <param name="won">Bool if the player has defeated the boss.</param>
        private void GameOver(bool won) {
            // Player has died
            if (won == false) {
                // Display lost image and play lost music
                picLost.Location = Point.Empty;
                picLost.Size = ClientSize;
                picLost.Visible = true;
                SoundPlayer simpleSound = new SoundPlayer(Resources.lost_music);
                simpleSound.Play();
            }
            // Player has defeated boss
            else {
                // Display win image and play win music
                picWin.Location = Point.Empty;
                picWin.Size = ClientSize;
                picWin.Visible = true;
                SoundPlayer simpleSound = new SoundPlayer(Resources.win_music);
                simpleSound.Play();
            }
        }

        private void EnemyDamage(int amount) {
            enemy.AlterHealth(amount);
        }

        private void PlayerDamage(int amount) {
            player.AlterHealth(amount);
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e) {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
        }
    }
}
