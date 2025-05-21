using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcGame;

namespace TcGame
{
     public  class GameOver:StaticActor
    { 
        public GameOver() {

            Sprite= new Sprite(new Texture("Data/Textures/images.png"));
            Scale = new SFML.System.Vector2f(1,1) ; 
            Position= new SFML.System.Vector2f(Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y / 2) ;
            Center(); 
            Layer=ELayer.GameOver;

        }
    }
}
