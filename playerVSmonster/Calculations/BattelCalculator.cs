using System;

namespace player_moster.Calculations
{
    internal class BattelCalculator
    {

        Random random = new Random();

        public int CalculateAttackModifier(int defenderDefense, int dices)
        {
            bool isFiveOrSixPresent = false;

            int attackerattack = 0;

            int[] dicesNumbers = new int[dices];
            
            for (int i = 0; i < dices; i++)
            {
                dicesNumbers[i] += random.Next(1, 6);

                if (dicesNumbers[i] == 5 || dicesNumbers[i] == 6)
                {
                    attackerattack++;
                    isFiveOrSixPresent = true;
                }
                
            }

            int attackModifier = attackerattack - defenderDefense + 1;
            //проверка на наличие 5 или 6
            if (!isFiveOrSixPresent)
            {
                attackModifier = 0;
            }
           
            return attackModifier;
        }

        public int CalculateDamage()
        {
            int damage = random.Next(1, 6);

            return damage;
        }
    }
}
