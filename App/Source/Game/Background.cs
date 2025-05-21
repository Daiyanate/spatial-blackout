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

            Position = new Vector2f(1920/2, 1080/2);
        }
    }
}