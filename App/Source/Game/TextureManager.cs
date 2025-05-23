using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace TcGame
{
    public static class TextureManager
    {
        private static List<Texture> _alienTextures = new List<Texture>()
        {
            new Texture("Data/Textures/Aliens/Alien-01.png"),
            new Texture("Data/Textures/Aliens/Alien-02.png"),
            new Texture("Data/Textures/Aliens/Alien-03.png"),
            new Texture("Data/Textures/Aliens/Alien-04.png")
        };

        private static Font _font = new Font("Data/Fonts/LuckiestGuy.ttf");

        public static List<Texture> AlienTextures { get { return _alienTextures; } }

        public static Texture GetAlienTexture(int index)
        {
            return _alienTextures[Math.Clamp(index, 0, _alienTextures.Count - 1)];
        }

        public static Font HUDFont { get { return _font; } }
    }
}
