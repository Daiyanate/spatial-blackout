using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class MyGame : Game
    {
        public Background bg { private set; get; }
        public Frame frame { private set; get; }
        public AlienSpawner spawner { private set; get; }
        public Hud hud { private set; get; }
        public GameOver gameOver { private set; get; }

        public Background background { private set; get; }
        private static MyGame instance;
        public static MyGame Get
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyGame();
                }

                return instance;
            }
        }
        private MyGame()
        {
        }
        public void Init()
        {
            background = Engine.Get.Scene.Create<Background>();

            hud = Engine.Get.Scene.Create<Hud>();

            bg = Engine.Get.Scene.Create<Background>();
            frame = Engine.Get.Scene.Create<Frame>();

            spawner = Engine.Get.Scene.Create<AlienSpawner>();

            gameOver = Engine.Get.Scene.Create<GameOver>();

        }

        public void DeInit()
        {
        }
        public void Update(float dt)
        {

        }
        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}

