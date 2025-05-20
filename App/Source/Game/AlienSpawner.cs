using System;

namespace TcGame
{
    public class AlienSpawner : Actor
    {
        private int num = 125;

        public AlienSpawner()
        {
            Alien firstAlien = Engine.Get.Scene.Create<Alien>();

            for (int i = 1; i < num; i++)
            {
                Alien newAlien = Engine.Get.Scene.Create<Alien>();

                while (newAlien.index == firstAlien.index)
                {
                    newAlien.Destroy();
                    newAlien = Engine.Get.Scene.Create<Alien>();
                }
            }
        }
    }
}
