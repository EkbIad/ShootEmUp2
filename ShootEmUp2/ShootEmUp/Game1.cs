using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShootEmUp
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        public static Rectangle playerRect;
        Color color;
        public static Texture2D rockTexture;
        Texture2D background1;
        Texture2D background2;
        Vector2 bulletScale;
       
        

       
        
       
        float enemyAttackSpeed = 1;
        float enemyAttackTimer;
     
        float bulletSpeed;
        float bulletDamage;


      
        BackgroundManager backgroundManager = new BackgroundManager();
        float backgroundSpeed;

        List<Enemies> enemy;
        //static List<Bullet> bullets;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            enemy = new List<Enemies>();
            enemy.Add(new Enemies(rockTexture, new Vector2(300,400), 30, 2, enemyAttackSpeed, 0));
            player = new Player(TextureLibrary.GetTexture("player"), new Vector2(0, 0), 600, new Vector2(0.15f, 0.15f), 0, Color.White, 3, 0.25f, TextureLibrary.GetTexture("player").Bounds.Size.ToVector2() * 0.5f);
            IsMouseVisible = true;
            
          
            

            
       
            backgroundSpeed = 500;
            
            enemyAttackTimer = 0;
            
            bulletSpeed = 1000;
            bulletDamage = 10;
            
            //bullets = new List<Bullet>();
            BulletManager.Init();
            bulletScale = new Vector2(0.2f, 0.2f);
            
            backgroundManager.Initialize(new Vector2(-1, 0), background1, background2, new Vector2(0, 0), backgroundSpeed);

        }

        

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            TextureLibrary.LoadTexture(Content, "player");
            rockTexture = Content.Load<Texture2D>("rock");
            TextureLibrary.LoadTexture(Content, "bullet");
            TextureLibrary.LoadTexture(Content, "background");
            TextureLibrary.LoadTexture(Content, "background2");
            background1 = Content.Load<Texture2D>("background");
            background2 = Content.Load<Texture2D>("background2");



        }

        //public static void RemoveBullet(Bullet bullet)
        //{
        //    bullets.Remove(bullet);

        //}

      
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].Update(deltaTime, 1080);
                if(enemy[i].GetIsAlive()== false)
                {
                    enemy.Remove(enemy[i]);
                }
            }
            
            // TODO: Add your update logic here
            
            
            backgroundManager.Update(deltaTime);
            player.Update(gameTime);



        
            

            


            

            base.Update(gameTime);
        }

        
  

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            backgroundManager.Draw(spriteBatch);
            
            for (int i = 0; i < BulletManager.AccessBullets.Count; i++)
            {
                BulletManager.AccessBullets[i].Draw(spriteBatch);
            }

            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
