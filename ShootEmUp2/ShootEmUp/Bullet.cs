using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace ShootEmUp
{
    class Bullet
    {
        Vector2 dir;
        float speed;
        Texture2D texture;
        Rectangle rectangle;
        
        Vector2 position;

        public Vector2 AccessPosition { get => position; }

        Vector2 scale;
        Vector2 offset;

        public Rectangle AccessRectangle { get => rectangle; }

        bool myIsPlayer;

        public bool AccessIsPlayer { get => myIsPlayer; }
        
        float damage;

        public float AccessDamage { get => damage; }

        public Bullet(Vector2 Bulletdir, float bulletSpeed, Texture2D bulletTexture, Vector2 startPosition, float bulletDamage, bool isPlayer = true)
        {
            
            dir = Bulletdir;
            
            damage = bulletDamage;
            
            dir.Normalize();
            speed = bulletSpeed;
            texture = bulletTexture;
            position = startPosition;
            scale = new Vector2(0.03f, 0.03f);
            offset = texture.Bounds.Size.ToVector2() * 0.2f;
            rectangle.Size = (texture.Bounds.Size.ToVector2().ToPoint());
            damage = 1;

            myIsPlayer = isPlayer;


        }

        public void Update(float deltaTime)
        {
            position += dir * speed * deltaTime;
            rectangle.Location = position.ToPoint();
            //if (rectangle.Intersects(Enemies.rockRect))
            //{
            //    Enemies.ChangeRockColor(Color.Red);
                

            //    //Game1.RemoveBullet(this);
                
            //}
            //else
            //{
            //    Enemies.ChangeRockColor(Color.White);
            //}
            

        }

        public float Damage(Rectangle otherRectangle)
        {
            float damageToDeal = 0;
            if (rectangle.Intersects(otherRectangle))
            {
                damageToDeal = damage;
                //Game1.RemoveBullet(this);
            }
            return damageToDeal;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, offset,scale,SpriteEffects.None, 0);


        }

















    }
}
