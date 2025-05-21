using SFML.Graphics;
using SFML.System;
using System;

namespace TcGame;




public class  Hud: Actor
{

    Text t;
    Font f;
    public float time =45;
    private int time2;
    public float BckGrndTimer ;
    public Hud()
    {
        Font f = new Font("Data/Fonts/LuckiestGuy.ttf");
         t = new Text("holaaa",f);
        t.Position = new Vector2f(Engine.Get.Window.Size.X/2-70,10);
        t.Scale = new Vector2f(1.5f,1.5f); 
        Layer = ELayer.Hud;
        Center();
    }





     public override void Draw(RenderTarget target, RenderStates states) {

        base.Draw(target, states);
        t.Draw(target, states);



    }
    public override void Update(float dt)
    {
        base.Update(dt);
        if (time > 0)
        {            time -= dt;
        }
        else { time = 0; }
        time2=Convert.ToInt32(time);
        if (time<22.5f)
        {   
            
            BckGrndTimer += dt;
        }
        else if (BckGrndTimer>=5)
        {
            BckGrndTimer = BckGrndTimer;

        }
        else
        {
            time = 0;
        }
        t.DisplayedString=string.Format("Time: {0}",time2,f); 

        

    } 

}