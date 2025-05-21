using SFML.Graphics;
using SFML.System;
using System;

namespace TcGame;




public class  Hud: Actor
{
    Text t2;
    Text t;
    Font f; 
    
    public float time =45;
    private int time2;
    public float BckGrndTimer;
    public int Points; 

    public enum GameStatess
    {
        Gameplay,
        GameOver
    }
    public GameStatess State { get; set; }
    public Hud()
    {
        Font f = new Font("Data/Fonts/LuckiestGuy.ttf");
         t = new Text("holaaa",f);
        t2 = new Text("Points",f); 
        t2.Position=new Vector2f(Engine.Get.Window.Size.X / 2+170, 5);
        t.Position = new Vector2f(Engine.Get.Window.Size.X/2-70,5); 
        t2.Scale=new Vector2f(1.5f,1.5f);
        t.Scale = new Vector2f(1.5f,1.5f); 
        Layer = ELayer.Hud;
        Center();   
      
       
    }





     public override void Draw(RenderTarget target, RenderStates states) {

        base.Draw(target, states);
        t.Draw(target, states);
        t2.Draw(target, states); 
        
        if (State == GameStatess.GameOver)
        {
            
            foreach (GameOver  Gameover in Engine.Get.Scene.GetAll<GameOver>())
            {   
                Layer= ELayer.Hud;
                Gameover.Draw(target, states);

            }

        }
        

    }
    public override void Update(float dt)
    {
        
        base.Update(dt); 
        if (time>=0)
        {
            time -= dt;
        }
        else
        {
           time = 0;
            
          State= GameStatess.GameOver;
        }  
       
        time2 = Convert.ToInt32(time);
        t.DisplayedString=string.Format("Time: {0}",time2);
        t2.DisplayedString = String.Format("Points:{0} ",Points,t2);



        if (time < 22.5f)
        {

            BckGrndTimer += dt;
        }
        else if (BckGrndTimer >= 5)
        {
            BckGrndTimer = BckGrndTimer;

        }

    } 

}