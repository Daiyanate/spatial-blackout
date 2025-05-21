using SFML.Graphics;
using SFML.System;
using System;

namespace TcGame;




public class Hud : Actor
{
    Text t, t2, t3,t4;
    Font f;

    public float time = 27;
    private int time2;
    public float BckGrndTimer;
    public int Points;

    public enum GameStates
    {
        Gameplay,
        GameOver
    }
    public GameStates State { get; set; }
    public Hud()
    {
        Font f = new Font("Data/Fonts/LuckiestGuy.ttf");
        t = new Text("holaaa", f);
        t2 = new Text("Points", f); 

        t2.Position = new Vector2f(Engine.Get.Window.Size.X / 2 + 170, 5);
        t.Position = new Vector2f(Engine.Get.Window.Size.X / 2 - 70, 5);
        t2.Scale *= 1.5f;
        t.Scale *= 1.5f;

        t3 = new Text("Find the alien who is different from the rest!", f);
        t3.Position = new Vector2f(Engine.Get.Window.Size.X / 4 + 170, 150);
        t4 = new Text("Blackout!!!!",f);
        t4.Scale *= 2f;
        t4.Position = new Vector2f(Engine.Get.Window.Size.X/2-60, Engine.Get.Window.Size.Y / 2) ;
        
        Layer = ELayer.Hud;
        Center();
    }





    public override void Draw(RenderTarget target, RenderStates states)
    {

        base.Draw(target, states);
        t.Draw(target, states);
        t2.Draw(target, states);
        t3.Draw(target, states);

        if (time<22.5&&BckGrndTimer<=5)
        {
            t4.Draw(target, states);
        }

        if (State == GameStates.GameOver)
        {

            foreach (GameOver Gameover in Engine.Get.Scene.GetAll<GameOver>())
            {
                Layer = ELayer.Hud;
                Gameover.Draw(target, states);

            }

        } 
        


    }
    public override void Update(float dt)
    {

        base.Update(dt);

        if (time >= 0)
        {
            time -= dt;
        }
        else
        {
            time = 0;

            State = GameStates.GameOver;
        }

        time2 = Convert.ToInt32(time);
        t.DisplayedString = string.Format("Time: {0}", time2);
        t2.DisplayedString = String.Format("Points:{0} ", Points, t2);
        t3.DisplayedString = string.Format("Find the alien who is different from the rest!");


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