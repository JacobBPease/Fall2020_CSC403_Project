using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project.code {
  public class Player : BattleCharacter {
    public Player(Vector2 initPos, Collider collider) : base(initPos, collider) {
            FrmBattle.OnVictory += BattleCharacter.LevelUp; //subscribes player's levelup method to the OnVictory event upon instantiation
    }
  }
}
