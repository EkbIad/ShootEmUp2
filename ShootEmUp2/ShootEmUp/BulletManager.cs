using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootEmUp
{
    static class BulletManager
    {
        static public void Init()
        {
            myBullets = new List<Bullet>();
        }

        static public void Update(GameTime someTime)
        {
            for (int i = 0; i < myBullets.Count; i++)
            {
                myBullets[i].Update((float)someTime.ElapsedGameTime.TotalSeconds);

                if(myBullets[i].AccessPosition.X <= 0 || myBullets[i].AccessPosition.X >= 1920 || myBullets[i].AccessPosition.Y <= 0 || myBullets[i].AccessPosition.Y  >= 1080)
                {
                    myBullets.RemoveAt(i);
                    i--;
                }
            }
        }

        static public void Draw(SpriteBatch aSpriteBatch)
        {
            for (int i = 0; i < myBullets.Count; i++)
            {
                myBullets[i].Draw(aSpriteBatch);
            }
        }

        static public void AddBullet(Bullet aBullet)
        {
            myBullets.Add(aBullet);
        }


        static List<Bullet> myBullets;

        static public List<Bullet> AccessBullets { get => myBullets; }
    }
}
