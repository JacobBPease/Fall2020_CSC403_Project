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
        private bool foughtBoss = false;

        public static event Action OnVictory;
        public static event OnGameOverDelegate OnGameOver;
        public delegate void OnGameOverDelegate(bool won);


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
            foughtBoss = true;
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
            
            // If player health is low change player image to baby peanut
            if (player.Health <= 5) {
                picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.babypeanut;
            }

            // If player has died
            if (player.Health <= 0) {
                OnGameOver(false);
                instance = null;
                Close();
            }
            // If player has defeated the boss
            else if (enemy.Health <= 0 && foughtBoss) { 
                OnGameOver(true);
                instance = null;
                Close();
            }
            else if (enemy.Health <= 0) {
                OnVictory(); //broadcast to the LevelUp function
                instance = null;
                Close();

            }
        }

        private void EnemyDamage(int amount) {
            enemy.AlterHealth(amount);
        }

        private void PlayerDamage(int amount) {
            player.AlterHealth(amount + player.Armor); // add armor since amount will be negative
            if (player.Armor > 0) {
                player.Armor--; // decrement armor when the player is hit
            }
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e) {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
        }

        // heal option during battle
        private void btnHeal_Click(object sender, EventArgs e)
        {
            // checks for potion in inventory and player health
            if (player.inInventory.Contains("Potion") && player.Health <= player.MaxHealth)
            {
                player.AlterHealth(2);
                UpdateHealthBars();
                player.inInventory.Remove("Potion");
            }
        }
    }
}
