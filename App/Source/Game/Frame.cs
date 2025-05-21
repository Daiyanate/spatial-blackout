using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Frame : StaticActor
    {
        public Frame()
        {
            Layer = ELayer.Middle;

            Sprite = new Sprite(new Texture("Data/Textures/Frame.png"));
            Center();

            Position = new Vector2f(Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
        }
    }
}
