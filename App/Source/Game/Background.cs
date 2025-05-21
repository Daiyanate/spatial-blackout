using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

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

        public override void Update(float dt)
        {
            base.Update(dt); 
            BlackOut();
        }
        private void BlackOut()
        {
            List<Hud> Huds = Engine.Get.Scene.GetAll<Hud>();


            foreach (Hud hud in Huds)
            {
                if (hud.time < 22.5 && hud.BckGrndTimer <= 5)
                {
                    Layer = ELayer.Front;

                }
                else
                {
                    Layer = ELayer.Background;
                }
            }



        }














    }




}