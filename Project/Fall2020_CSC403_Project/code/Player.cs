using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project.code {
  public class Player : BattleCharacter {

    public Bitmap image;

    public Player(Vector2 initPos, Collider collider, Bitmap bitmap) : base(initPos, collider) {
            image = bitmap;
            FrmBattle.OnVictory += Player.LevelUp; //subscribes player's levelup method to the OnVictory event upon instantiation
    }
    public static void LevelUp()
    {
        int StrengthInmcrement = 1;

           Game.player.strength += StrengthInmcrement; //increments the player's strength by the increment
           Game.player.AlterHealth(Game.player.MaxHealth - Game.player.Health); //heals the character to full after each battle

    }
    }
}
