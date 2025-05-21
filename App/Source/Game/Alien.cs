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

        public List<Texture> t = new List<Texture>()
        {
            new Texture("Data/Textures/Aliens/Alien-01.png"),
            new Texture("Data/Textures/Aliens/Alien-02.png"),
            new Texture("Data/Textures/Aliens/Alien-03.png"),
            new Texture("Data/Textures/Aliens/Alien-04.png")
        };

        private float speedRotation;

        public Alien()
        {
            Layer = ELayer.Back;

            index = r.Next(0, 4);
            Sprite = new Sprite(t[index]);
            Center();

            Speed = 100.0f;
            speedRotation = r.Next(-90,91);

            Forward = new Vector2f(
                r.Next(-1, 2),
                r.Next(-1, 2)
                );

            Position = new Vector2f(
                r.Next(1920/4 + Convert.ToInt32(Sprite.Texture.Size.X/3), 1920/4*3 - Convert.ToInt32(Sprite.Texture.Size.X/3)+1),
                r.Next(1080/4 + Convert.ToInt32(Sprite.Texture.Size.Y/3), 980 - Convert.ToInt32(Sprite.Texture.Size.Y/2)+1)
                );
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (Position.X - Sprite.Texture.Size.X/3 <= 1920/4 || Position.X + Sprite.Texture.Size.X/3 >= 1920/4*3)
                Forward.X *= -1;
            else if (Position.Y - Sprite.Texture.Size.Y/3 <= 1080/4 || Position.Y + Sprite.Texture.Size.Y/2 >= 980)
                Forward.Y *= -1;

            if (Position.X >= 1920/4*3 || Position.X <= 1920/4 || Position.Y <= 1080/4 || Position.Y >= 980)
                Destroy();

            Rotation += speedRotation * dt;
        }
    }
}
