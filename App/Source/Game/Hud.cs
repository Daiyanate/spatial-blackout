using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame;
public class Hud : Actor
{
    Text counter, score, instructions, blackout;

    public float time, bckGrndTimer;

    public int points;

    public enum GameStates
    {
        Gameplay,
        GameOver
    }

    public GameStates State { get; set; }

    public Hud()
    {
        Layer = ELayer.Hud;

        time = 30.0f;

        Font f = new Font("Data/Fonts/LuckiestGuy.ttf");

        instructions = new Text("Find the alien that is different from the rest!", f);
        instructions.FillColor = new Color(245, 206, 14, 255);
        instructions.CharacterSize = 75;
        instructions.Origin = new Vector2f(instructions.GetLocalBounds().Width/2, instructions.GetLocalBounds().Height/2);
        instructions.Position = new Vector2f(Engine.Get.Window.Size.X/2, instructions.GetLocalBounds().Height);

        counter = new Text("Time: ", f);
        counter.CharacterSize = 50;
        counter.Origin = new Vector2f(counter.GetLocalBounds().Width, counter.GetLocalBounds().Height/2);
        counter.Position = new Vector2f(Engine.Get.Window.Size.X/2 - 150, 150);

        score = new Text("Points: ", f);
        score.CharacterSize = 50;
        score.Origin = new Vector2f(0, score.GetLocalBounds().Height/2);
        score.Position = new Vector2f(Engine.Get.Window.Size.X/2 + 150, 150);

        blackout = new Text("Blackout!!!!", f);
        blackout.CharacterSize = 75;
        blackout.Origin = new Vector2f(blackout.GetLocalBounds().Width/2, blackout.GetLocalBounds().Height/2);
        blackout.Position = new Vector2f(Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
    }

    public override void Draw(RenderTarget rt, RenderStates rs)
    {
        base.Draw(rt, rs);

        instructions.Draw(rt, rs);

        counter.Draw(rt, rs);
        score.Draw(rt, rs);

        if (time <= 20.0f && bckGrndTimer <= 5)
            blackout.Draw(rt, rs);

        if (State == GameStates.GameOver)
        {
            foreach (GameOver Gameover in Engine.Get.Scene.GetAll<GameOver>())
            {
                Layer = ELayer.Hud;
                Gameover.Draw(rt, rs);

                if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                {
                    foreach (Hud h in Engine.Get.Scene.GetAll<Hud>())
                        h.Destroy();
                    foreach (GameOver g in Engine.Get.Scene.GetAll<GameOver>())
                        g.Destroy();
                    foreach (AlienSpawner s in Engine.Get.Scene.GetAll<AlienSpawner>())
                        s.Destroy();
                    foreach (Alien a in Engine.Get.Scene.GetAll<Alien>())
                        a.Destroy();

                    Engine.Get.Scene.Create<Hud>();
                    Engine.Get.Scene.Create<GameOver>();
                    Engine.Get.Scene.Create<AlienSpawner>();
                }
            }
        }
    }

    public override void Update(float dt)
    {
        base.Update(dt);
        
        if (time > 0)
            time -= dt;
        else
            State = GameStates.GameOver;

        instructions.DisplayedString = string.Format("Find the alien that is different from the rest!");

        counter.Origin = new Vector2f(counter.GetLocalBounds().Width, counter.GetLocalBounds().Height / 2);
        counter.Position = new Vector2f(Engine.Get.Window.Size.X/2-150, 150);

        counter.DisplayedString = string.Format($"Time: {Convert.ToInt32(time)}");

        score.Origin = new Vector2f(0, score.GetLocalBounds().Height / 2);
        score.Position = new Vector2f(Engine.Get.Window.Size.X/2+150, 150);

        score.DisplayedString = string.Format($"Points: {points}");

        if (time <= 20.0f)
            bckGrndTimer += dt;
        else if (bckGrndTimer >= 5)
            bckGrndTimer = bckGrndTimer;
    }
}