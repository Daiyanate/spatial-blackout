using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public  class GameOver : StaticActor
    {
        public GameOver()
        {
            Layer = ELayer.GameOver;

            Sprite = new Sprite(new Texture("Data/Textures/GameOver.png"));
            Scale *= 0.75f;
            Center();

            Position = new Vector2f(Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
        }
    }
}
