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
        public static Color rockColor;
        float rockHealth;
        Vector2 rockScale;
        bool alive;

        public Enemies(Texture2D rockTex)
        {
            
            rockRect = new Rectangle();
            rockPos = new Vector2(100, 100);
            rockRect = rockTex.Bounds;
            rockRect.Size = (rockTex.Bounds.Size.ToVector2() * 0.1f).ToPoint();
            rockScale = new Vector2(0.07f, 0.07f);
            rockColor = Color.White;
            rockTexture = rockTex;
            alive = true;
        }

     
        
        public void Update()
        {

            if (alive)
            {
                if (Game1.playerRect.Intersects(rockRect))
                {
                    rockColor = Color.Red;
                }
                else
                {
                    rockColor = Color.White;
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
            rockHealth += healthMod;

        }

        public bool GetIsAlive()
        {
            return alive;
        }

            
        









    }
}
