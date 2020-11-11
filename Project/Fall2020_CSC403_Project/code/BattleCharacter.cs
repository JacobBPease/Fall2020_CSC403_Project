using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project.code {
  public class BattleCharacter : Character {
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Armor;
    public float strength;

    public event Action<int> AttackEvent;

    public BattleCharacter(Vector2 initPos, Collider collider) : base(initPos, collider) {
      MaxHealth = 20;
      strength = 2;
      Armor = 5;
      Health = MaxHealth;
    }

    public void OnAttack(int amount) {
      AttackEvent((int)(amount * strength));
    }

    public void AlterHealth(int amount) {
      Health += amount;
    }


        public void ElementalPower(bool fire, bool magic, bool lightning) {
      if (fire) {
        strength += 2; // add fire damage
      }
      if (magic) {
        strength += 2; // add magic damage and give the player extra health
        AlterHealth(2);
      }
      if (lightning) {
        strength += 2; // add lightning damage
        Armor++;
      }
    }
  }
}
