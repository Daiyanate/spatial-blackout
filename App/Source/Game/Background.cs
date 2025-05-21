using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Background : StaticActor
    {
        public Background()
        {
            Layer = ELayer.Background;

            Sprite = new Sprite(new Texture("Data/Textures/Background.png"));
            Center();

            Position = new Vector2f(Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            BlackOut();
        }

        private void BlackOut()
        {
            foreach (Hud h in Engine.Get.Scene.GetAll<Hud>())
            {
                if (h.time <= 20.0f && h.bckGrndTimer <= 5)
                    Layer = ELayer.Front;
                else
                    Layer = ELayer.Background;
            }
        }
    }
}