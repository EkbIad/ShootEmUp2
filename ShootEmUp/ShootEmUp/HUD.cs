using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootEmUp
{
    public class HUD
    {
        public int playerScore, screenWidth, screenHeight;
        public SpriteFont playerScoreFont;
        public Vector2 playerScorePos;
        public bool showHud;


        public HUD()
        {
            playerScore = 0;
            showHud = true;
            screenHeight = 1080;
            screenWidth = 1920;
            playerScoreFont = null;
            playerScorePos = new Vector2(screenWidth / 2, 50);

        }

        public void LoadContent(ContentManager Content)
        {
            playerScoreFont = Content.Load<SpriteFont>("Segoe UI Mono");

        }
        
        public void Update(GameTime gametime)
        {
            KeyboardState keyState = Keyboard.GetState();
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            if (showHud)
            {
                spriteBatch.DrawString(playerScoreFont, "Score - " + playerScore, playerScorePos, Color.Red);
            }
        }

    }
}
