using player_monster.Persons;
using player_moster.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace player_monster
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            int dices, playerCurrentHealth, monsterCurrentHealth, maxhealthplayer, healthmonster, monsterDefense, playerDefense;
            
            Console.Write("Введите число здоровья для монстра: ");
            healthmonster = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число защиты для монстра: ");
            monsterDefense = Convert.ToInt32(Console.ReadLine());

            Monster monster = new Monster(healthmonster, monsterDefense);

            Console.Write("Введите число здоровья для игрока: ");
            maxhealthplayer = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число защиты для игрока: ");
            playerDefense = Convert.ToInt32(Console.ReadLine());

            Player player = new Player(maxhealthplayer, playerDefense);


            Console.WriteLine("Введите число кубиков, которыми будут играть, не должно быть меньше 1 кубика: ");
            dices = Convert.ToInt32(Console.ReadLine());

            

            do
            {

                Console.WriteLine("Ход игрока");
                player.Attack(monster, dices, monsterDefense);

                playerCurrentHealth = player.currenthealth();

                monsterCurrentHealth = monster.currenthealth();
                Console.WriteLine("Здоровье монстра: " + monsterCurrentHealth);
                Console.WriteLine("Здоровье игрока: " + playerCurrentHealth + "\n");

                Console.WriteLine("Хотите использовать зелье исцеления ? нажмите h (английская)");
                //кнопка для восстановления здоровья
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.H)
                {
                    Console.WriteLine("Вы исцелились");
                    player.UseHealthBottle(maxhealthplayer, playerCurrentHealth);
                }

                if (monsterCurrentHealth <= 0)
                {
                    Console.WriteLine("Игрок победил монстра!");
                    break;
                }

                Console.ReadKey();

                Console.WriteLine("Ход Монстра");
                monster.Attack(player, dices, playerDefense);

                playerCurrentHealth = player.currenthealth();
                monsterCurrentHealth = monster.currenthealth();
                Console.WriteLine("Здоровье монстра: " + monsterCurrentHealth);
                Console.WriteLine("Здоровье игрока: " + playerCurrentHealth + "\n");

                // Проверка, не побежден ли монстр
                if (playerCurrentHealth <= 0)
                {
                    Console.WriteLine("Монстр победил игрока!");
                    break;
                }

                Console.ReadKey();
            }
            while (playerCurrentHealth > 0 && monsterCurrentHealth > 0);

            Console.ReadKey();
        }
    }
}
