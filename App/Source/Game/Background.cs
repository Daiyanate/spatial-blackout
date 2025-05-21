using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace TcGame
{
  public class Background : StaticActor
  {
       

    public Background()
    {
      Layer = ELayer.Background;
      Sprite = new Sprite(new Texture("Data/Textures/Player/fondo2.jpg"));
    }
    public override void Update(float dt)
    {
            BlackOut();
            


            
            

    }
     private void  BlackOut() {

           List<Hud> Huds = Engine.Get.Scene.GetAll<Hud>();
            
          
            foreach (Hud hud in Huds)
            {
                if (hud.time<22.5&&hud.BckGrndTimer<=5)
                {
                    Layer=ELayer.Front;
                    
                }
                else
                {
                    Layer=ELayer.Background;
                }
            }
               
        
     }



  }
}

