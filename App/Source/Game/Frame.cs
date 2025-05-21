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

            Position = new Vector2f(1920/2, 1080/2);
        }
    }
}
