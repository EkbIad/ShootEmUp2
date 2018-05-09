using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShootEmUp
{
    class Player
    {
        Texture2D player;
        public static Rectangle playerRect;
        Color color;
        Vector2 playerPos;
        Vector2 playerOffset;
        Vector2 dir;
        Vector2 dirToLook;
        Vector2 position;
        Vector2 scale;
        float speed;
        float rotation;
        float health;
        bool alive = true;
        bool isMouseVisible;
        float attackSpeed;
        float attackTimer;
        float bulletSpeed;
        float bulletDamage;

        public void Initialize()
        {

           
        }
        public Player(Texture2D playerTexture, Vector2 playerStartPos, float playerSpeed, Vector2 playerScale, float playerRotation, Color playerColor, float playerHealth, float playerAttackSpeed, Vector2 offset)
        {
            player = playerTexture;
            playerOffset = offset;
            position = playerStartPos;
            speed = playerSpeed;
            scale = playerScale;
            rotation = playerRotation;
            color = playerColor;
            health = playerHealth;
            attackSpeed = playerAttackSpeed;
            isMouseVisible = true;
            playerRect = player.Bounds;
            alive = true;
            attackTimer = 0;
            health = 3;
            bulletSpeed = 400;
            bulletDamage = 1;

        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            attackTimer += deltaTime;
            float pixelsToMove = speed * deltaTime;
            dir = new Vector2();
            MouseState mouseState = Mouse.GetState();
            dirToLook = mouseState.Position.ToVector2() - playerPos;
            KeyboardState keyPress = Keyboard.GetState();

            if (alive)
            {
                if (keyPress.IsKeyDown(Keys.D))
                {
                    dir = new Vector2(1, 0);
                }
                if (keyPress.IsKeyDown(Keys.A))
                {
                    dir = new Vector2(-1, 0);
                }
                if (keyPress.IsKeyDown(Keys.W))
                {
                    dir.Y = -1;
                }
                if (keyPress.IsKeyDown(Keys.S))
                {
                    dir.Y = 1;
                }


            }

            if (mouseState.LeftButton == ButtonState.Pressed && attackTimer >= attackSpeed)
            {
                Debug.Print("Yo");
                attackTimer = 0;
                BulletManager.AddBullet(new Bullet(dirToLook, bulletSpeed, TextureLibrary.GetTexture("bullet"), playerPos, bulletDamage));
            }
            for (int i = 0; i < BulletManager.AccessBullets.Count; i++)
            {
                BulletManager.AccessBullets[i].Update(deltaTime);
            }

            if (dir != Vector2.Zero)
            {
                dir.Normalize();
                playerPos += (dir * pixelsToMove);
                playerRect.Location = (playerPos - playerOffset * scale).ToPoint();
            }




            rotation = (float)Math.Atan2(dirToLook.Y, dirToLook.X);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(player, playerPos, null, color, rotation + 90 * 0.0174532925f, playerOffset, scale, SpriteEffects.None, 0);
        }







    }
}
