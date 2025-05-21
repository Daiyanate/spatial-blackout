using SFML.Graphics;
using SFML.System;

namespace TcGame
{
    public class Hud : Actor
    {
        public Text t;

        public Hud()
        {
            Layer = ELayer.Hud;

            t = new Text("Find the alien who is different from the rest!", new Font("Data/Fonts/LuckiestGuy.ttf"));

            t.Position = new Vector2f(25, 25);
        }

        public override void Update(float dt)
        {
            t.DisplayedString = string.Format("Find the alien who is different from the rest!");
        }

        public override void Draw(RenderTarget rt, RenderStates st)
        {
            rt.Draw(t);
        }
    }
}

