using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Alien : StaticActor
    {
        private Random r = new Random();

        public int index;

        List<Texture> t = new List<Texture>()
        {
            new Texture("Data/Textures/Aliens/Alien-01.png"),
            new Texture("Data/Textures/Aliens/Alien-02.png"),
            new Texture("Data/Textures/Aliens/Alien-03.png"),
            new Texture("Data/Textures/Aliens/Alien-04.png")
        };

        private float speedRotation;

        public Alien()
        {
            Layer = ELayer.Middle;

            index = r.Next(0, 4);
            Sprite = new Sprite(t[index]);
            Center();

            Speed = 100.0f;
            speedRotation = 50.0f;

            Forward = new Vector2f(r.Next(-1, 2), r.Next(-1, 2));

            Position = new Vector2f(
                r.Next(0 + Convert.ToInt32(Sprite.Texture.Size.X/3), 1024 - Convert.ToInt32(Sprite.Texture.Size.X/3)),
                r.Next(0 + Convert.ToInt32(Sprite.Texture.Size.Y/3), 768 - Convert.ToInt32(Sprite.Texture.Size.Y/3))
                );
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (Position.X - Sprite.Texture.Size.X/3 <= 0 || Position.X + Sprite.Texture.Size.X/3 >= Engine.Get.Window.Size.X)
                Forward.X *= -1;
            else if (Position.Y - Sprite.Texture.Size.Y/3 <= 0 || Position.Y + Sprite.Texture.Size.Y/3 >= Engine.Get.Window.Size.Y)
                Forward.Y *= -1;

            Rotation += speedRotation * dt;
        }
    }
}
