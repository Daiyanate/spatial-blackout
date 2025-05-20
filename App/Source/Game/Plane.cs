using SFML.Graphics;
using SFML.System;

namespace TcGame
{
  public class Plane : StaticActor
  {
    public Plane()
    {
      Sprite = new Sprite(new Texture("Data/Textures/Player/Plane.png"));
      Position = (Vector2f) Engine.Get.Window.Size / 2;
    }
   
  }
}
