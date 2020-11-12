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

        // list of possible items
        private List<string> items = new List<string>()
     {
            "Potion","Potion", 
            "Regular Staff", "Regular Sword",
            "Fire Sword", "Lightning Sword", "Magic Staff"
     };

        // list of items in inventory
        public List<string> inInventory = new List<string>()
     {
         "Potion", "Potion"
     };



        public BattleCharacter(Vector2 initPos, Collider collider) : base(initPos, collider) {
            MaxHealth = 20;
            strength = 2;
            Armor = 3;
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
                strength += 1; // add fire damage
            }
            if (magic) {
                strength += 1; // add magic damage and give the player extra health
                AlterHealth(2);
            }
            if (lightning) {
                strength += 1; // add lightning damage
                Armor++;
            }

        }

        public void addItem()
        {
            //Randomly choose item to add
            Random random = new Random();
            int randomNumber = random.Next(items.Count);
            inInventory.Add(items[randomNumber]);
            items.RemoveAt(randomNumber);
        }

        public void checkWeapons(List<string> inventory)
        {
            bool fire = false;
            bool magic = false;
            bool lightning = false;
            if (inventory.Contains("Fire Sword"))
            {
                fire = true;
            }
            if (inventory.Contains("Lightning Sword"))
            {
                magic = true;
            }
            if (inventory.Contains("Magic Staff"))
            {
                lightning = true;
            }
            ElementalPower(fire, magic, lightning);

        }

    } 
}
