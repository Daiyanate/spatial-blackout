using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Alien : StaticActor
    {
        private Random r = new Random();

        List<Texture> t = new List<Texture>()
        {
            new Texture("Data/Textures/Aliens/Alien-01.png"),
            new Texture("Data/Textures/Aliens/Alien-02.png"),
            new Texture("Data/Textures/Aliens/Alien-03.png"),
            new Texture("Data/Textures/Aliens/Alien-04.png")
        };

        public Alien()
        {
            Layer = ELayer.Middle;

            Sprite = new Sprite(t[r.Next(0, 4)]);
            Center();

            Speed = 100.0f;

            int forX = r.Next(-1,2);

            while (forX == 0)
                forX = r.Next(-1, 2);

            Forward.X = forX;

            int forY = r.Next(-1, 2);

            while (forY == 0)
                forY = r.Next(-1, 2);

            Forward.Y = forY;


            Position = new Vector2f(
                r.Next(0 + Convert.ToInt32(Sprite.Texture.Size.X/2), 1024 - Convert.ToInt32(Sprite.Texture.Size.X/2)),
                r.Next(0 + Convert.ToInt32(Sprite.Texture.Size.Y/2), 768 - Convert.ToInt32(Sprite.Texture.Size.Y/2))
                );
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (Position.X - Sprite.Texture.Size.X/2 < 0 || Position.X + Sprite.Texture.Size.X/2 > Engine.Get.Window.Size.X)
                Forward.X *= -1;
            else if (Position.Y - Sprite.Texture.Size.Y/2 < 0 || Position.Y + Sprite.Texture.Size.Y/2 > Engine.Get.Window.Size.Y)
                Forward.Y *= -1;
        }
    }
}
