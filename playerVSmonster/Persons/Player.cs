using player_moster.Calculations;
using System;

namespace player_monster.Persons
{
    internal class Player : IPerson
    {
        public int _healthpoints { get; set; }
        public int _attack { get; set; }
        public int _defense { get; set; }

        public Player(int healthpoints, int defense)
        {
            if (healthpoints < 0)
            {
                throw new ArgumentOutOfRangeException("healthpoints", "Значение здоровья не может быть отрицательным.");
            }
            if (defense < 1 || defense > 30)
            {
                throw new ArgumentOutOfRangeException("healthpoints", "Значение защиты не может быть ниже 1 и больше 30");
            }
            _healthpoints = healthpoints;
            _defense = defense;
        }


        public int currenthealth()
        {
            return _healthpoints;
        }

        public void TakeDamage(int damage)
        {
            _healthpoints -= damage;
        }

        public void TakeAttack(int attack)
        {
            _defense -= attack;
        }

        public void Attack(Monster monster, int cubes, int monsterDefense)
        {
            BattelCalculator calculator = new BattelCalculator();
            int damage = 0;
            _attack = calculator.CalculateAttackModifier(cubes, monsterDefense);
            if (_attack > 0)
            {
                damage = calculator.CalculateDamage() * _attack;
            }
            monster.TakeDamage(damage);
            monster.TakeAttack(_attack);
        }

        public void UseHealthBottle(int maxhealth, int currenthealth)
        {
            Regeneration bottle = new Regeneration();
           _healthpoints = bottle.Use(maxhealth, currenthealth);
        }
    }
}
