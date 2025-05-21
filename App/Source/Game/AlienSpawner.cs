using SFML.Window;

namespace TcGame
{
    public class AlienSpawner : StaticActor
    {
        private int num, increase;

        public Alien firstAlien;

        public AlienSpawner()
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
                    foreach (Alien a in Engine.Get.Scene.GetAll<Alien>())
                        a.Destroy();

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

        private void SpawnAliens()
        {
            firstAlien = Engine.Get.Scene.Create<Alien>();

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