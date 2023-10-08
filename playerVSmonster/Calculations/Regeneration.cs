using System;

namespace player_moster.Calculations
{
    internal class Regeneration
    {

        int _healthbottles = 4;

        public int Use(int maxhealth, int currenthealth)
        {
            currenthealth = currenthealth + (maxhealth / 100 * 30);
            _healthbottles--;
            if (_healthbottles == 0)
            {
                throw new ArgumentOutOfRangeException("_healthbottles", "бутылки закончились");
            }

            return currenthealth;
        }
    }
}
