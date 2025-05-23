using System;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Alien : StaticActor
    {
        private Random r = new Random();

        public int index;

        private float speedRotation;

        public Alien() { }

        public void Initialize(int index)
        {
            Layer = ELayer.Back;
            Sprite = new Sprite(TextureManager.GetAlienTexture(index));
            Center();

            Speed = 100.0f;
            speedRotation = r.Next(-90, 91);

            Forward = new Vector2f(
                r.Next(-1, 2),
                r.Next(-1, 2)
                );

            Position = new Vector2f(
                r.Next(
                    Convert.ToInt32(Engine.Get.Window.Size.X)/4 + Convert.ToInt32(Sprite.Texture.Size.X/3),
                    Convert.ToInt32(Engine.Get.Window.Size.X)/4*3 - Convert.ToInt32(Sprite.Texture.Size.X/3) + 1),
                r.Next(
                    Convert.ToInt32(Engine.Get.Window.Size.Y)/4 + Convert.ToInt32(Sprite.Texture.Size.Y/3),
                    Convert.ToInt32(Engine.Get.Window.Size.Y)-100 - Convert.ToInt32(Sprite.Texture.Size.Y/2) + 1)
                );
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            if (Position.X - Sprite.Texture.Size.X / 3 <= Engine.Get.Window.Size.X / 4 ||
                Position.X + Sprite.Texture.Size.X / 3 >= Engine.Get.Window.Size.X / 4 * 3)
                Forward.X *= -1;
            else if (Position.Y - Sprite.Texture.Size.Y / 3 <= Engine.Get.Window.Size.Y / 4 ||
                Position.Y + Sprite.Texture.Size.Y / 2 >= Engine.Get.Window.Size.Y - 100)
                Forward.Y *= -1;

            if (Position.X >= 1920 / 4 * 3 || Position.X <= 1920 / 4 || Position.Y <= 1080 / 4 || Position.Y >= 980)
                Destroy();

            Rotation += speedRotation * dt;
        }
    }
}
