namespace TcGame
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public Background bg { private set; get; }
        public Frame frame { private set; get; }
        public AlienSpawner spawner { private set; get; }
        public GameOver gameOver { private set; get; }

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
            bg = Engine.Get.Scene.Create<Background>();
            frame = Engine.Get.Scene.Create<Frame>();

            hud = Engine.Get.Scene.Create<Hud>();
            gameOver = Engine.Get.Scene.Create<GameOver>();

            spawner = Engine.Get.Scene.Create<AlienSpawner>();
        }

        public void DeInit()
        {

        }

        public void Update(float dt)
        {

        }

        public void InitGame()
        {
            
        }

        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}

