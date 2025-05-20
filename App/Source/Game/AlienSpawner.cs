using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcGame
{
    public class AlienSpawner : Actor
    {
        private Random r = new Random();

        private int minAliens = 100;
        private int maxAliens = 100;

        public AlienSpawner()
        {
            int num = r.Next(minAliens, maxAliens);

            Alien a = Engine.Get.Scene.Create<Alien>();

            for (int i = 0; i < num; i++)
            {
                Alien firstAlien = Engine.Get.Scene.GetFirst<Alien>();
                Alien newAlien = new Alien();

                while (newAlien == firstAlien)
                {
                    newAlien = new Alien();
                }

                newAlien = Engine.Get.Scene.Create<Alien>();
            }
        }
    }
}
