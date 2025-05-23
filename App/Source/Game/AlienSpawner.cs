using SFML.Window;
using System;
using System.Linq;

namespace TcGame
{
    public class AlienSpawner : StaticActor
    {
        public int num, increase;

        public Alien firstAlien;

        public AlienSpawner()
        {
            InitializeSpawn();
        }

        public void InitializeSpawn()
        {
            num = 100;
            increase = 20;

            SpawnAliens();
        }

        public override void Update(float dt)
        {
            if (Mouse.GetPosition().X >= firstAlien.Position.X - firstAlien.Sprite.Texture.Size.X / 3 &&
                Mouse.GetPosition().X <= firstAlien.Position.X + firstAlien.Sprite.Texture.Size.X / 3 &&
                Mouse.GetPosition().Y >= firstAlien.Position.Y - firstAlien.Sprite.Texture.Size.X / 3 &&
                Mouse.GetPosition().Y <= firstAlien.Position.Y + firstAlien.Sprite.Texture.Size.Y / 2 &&
                Engine.Get.Scene.GetFirst<Hud>().State == Hud.GameStates.Gameplay)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    foreach (Hud h in Engine.Get.Scene.GetAll<Hud>())
                    {
                        h.time += 5;
                        h.points += 1;
                    }

                    num += increase;
                    SpawnAliens();
                }
            }
        }

        public void SpawnAliens()
        {
            foreach (Alien a in Engine.Get.Scene.GetAll<Alien>())
                a.Destroy();

            firstAlien = Engine.Get.Scene.Create<Alien>();
            int firstAlienIndex = new Random().Next(0,4);
            firstAlien.Initialize(firstAlienIndex);

            for (int i = 1; i < num; i++)
            {
                Alien newAlien = Engine.Get.Scene.Create<Alien>();
                newAlien.Initialize(Enumerable.Range(0, 4).Where(x => x != firstAlienIndex).OrderBy(_ => Random.Shared.Next()).First());
            }
        }
    }
}