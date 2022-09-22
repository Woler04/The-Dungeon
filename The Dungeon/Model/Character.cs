namespace The_Dungeon.Model
{
    public abstract class Character
    {
        private string name;
        private float baseHealth;
        private float health;
        private float baseArmor;
        private float armor;
        private float abilityPoint;
        private Bag bag;
        private string faction;
        private bool isAlive;
        private float restHealMultiplier;

        public Character(string name, float health, float armor, float abilityPoints, Bag bag, string faction)
        {
            Name = name;
            BaseHealth = health;
            Health = baseHealth;
            BaseArmor = armor;
            Armor = baseArmor;
            AbilityPoint = abilityPoints;
            Bag = bag;
            Faction = faction;
            IsAlive = true;
        }

        public bool IsAlive
        {
            get => this.isAlive; private set => this.isAlive = value;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("No name?");
                }
                this.name = value;
            }
        }

        public string Faction
        {
            get => this.faction;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("No faction?");
                }
                this.faction = value;
            }
        }

        public float Health
        {
            get => this.health;
            set
            {
                this.health = value;
                if (value <= 0)
                {
                    this.health = 0;
                    IsAlive = false;
                }
            }
        }

        public float Armor
        {
            get => this.armor;
            set
            {
                this.armor = value;
                if (value <= 0)
                {
                    this.armor = 0;
                }
            }
        }

        public float BaseHealth
        {
            get => this.baseHealth; private set => this.baseHealth = value;
        }

        public float BaseArmor
        {
            get => this.baseArmor; private set => this.baseArmor = value;
        }

        public float AbilityPoint
        {
            get => this.abilityPoint; set => this.abilityPoint = value;
        }

        public Bag Bag
        {
            get => this.bag; private set => this.bag = value;
        }

        public float RestHealMultiplier
        {
            get => restHealMultiplier; set => this.restHealMultiplier = value;
        }

        public void TakeDamage(float hitPoints)
        {
            //For a character to take damage, they need to be alive.
            //This is checked in the setter every time
            Armor -= hitPoints;
            if (Armor <= 0)
            {
                hitPoints -= BaseArmor;
                Health -= Math.Abs(hitPoints);
            }
            
        }

        public void Rest()
        {
            Health += baseHealth * RestHealMultiplier;
        }

        public void UseItem(Item itemToUse)
        {
            bag.GetItem(itemToUse.GetType().Name).AffectCharacter(this);
        }

        public void GiveCharacterItem(Item itemToGive, Character character)
        {
            if (!character.isAlive)
            {
                Console.WriteLine($"{character.Name} is deadass, gone, kicked the bucket");
            }

            character.ReceiveItem(itemToGive);
        }

        public void ReceiveItem(Item item)
        {
            Bag.AddItem(item);
        }
    }
}
