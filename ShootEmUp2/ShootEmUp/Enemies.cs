using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ShootEmUp
{
    class Enemies
    {
        public static Texture2D rockTexture;
        public static Rectangle rockRect;
        Vector2 rockPos;
        float speed;
        public static Color rockColor;
        float rockHealth;
        Vector2 rockScale;
        bool alive;
        float attackSpeed;
        float attackTimer;

        public Enemies(Texture2D rockTex, Vector2 enemyPos, float enemySpeed, float enemyHealth, float enemyAttackSpeed, float enemyAttackTimer)
        {
            
            rockRect = new Rectangle();
            attackSpeed = enemyAttackSpeed;
            attackTimer = enemyAttackTimer;
            speed = enemySpeed;
            rockPos = enemyPos;
            rockHealth = enemyHealth;
            rockRect = rockTex.Bounds;
            rockRect.Size = (rockTex.Bounds.Size.ToVector2() * 0.1f).ToPoint();
            rockScale = new Vector2(0.07f, 0.07f);
            rockColor = Color.White;
            rockTexture = rockTex;
            alive = true;
        }

     
        
        public void Update(float deltatime, int WindowHeight)
        {

            if (alive)
            {

                attackTimer += deltatime;
                
                if(attackTimer >= attackSpeed)
                {
                    Vector2 bulletDir = new Vector2(-1, 0);
                    BulletManager.AddBullet(new Bullet(bulletDir, 400, TextureLibrary.GetTexture("bullet"), rockPos, 1, false));
                    attackTimer = 0;
                }

                if (Game1.playerRect.Intersects(rockRect))
                {
                    rockColor = Color.Red;
                }
                else
                {
                    rockColor = Color.White;
                }

                for (int i = 0; i < BulletManager.AccessBullets.Count; i++)
                {
                    if(rockRect.Intersects(BulletManager.AccessBullets[i].AccessRectangle) && BulletManager.AccessBullets[i].AccessIsPlayer == true)
                    {
                        ChangeHealth(BulletManager.AccessBullets[i].AccessDamage);
                    }
                }
            }
            
        }

        public static void ChangeRockColor(Color color)
        {
            rockColor = color;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(rockTexture, rockRect, null, rockColor);
        }

        public void ChangeHealth(float healthMod)
        {
            rockHealth -= healthMod;
            if(rockHealth <= 0)
            {
                alive = false;
            }
        }

        public bool GetIsAlive()
        {
            return alive;
        }

            
        









    }
}
