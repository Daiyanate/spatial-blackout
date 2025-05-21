using SFML.Graphics;
using SFML.System;

namespace TcGame
{
  public class Plane : StaticActor
  {
    public Plane()
    {
      Sprite = new Sprite(new Texture("Data/Textures/Player/Plane.png"));
            Position = new Vector2f(Engine.Get.Window.Position.X/2, Engine.Get.Window.Position.Y / 2) ; 
            Layer=ELayer.Middle;
    }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);
        }
    }
}
