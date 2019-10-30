using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
/**
 * mostly following: http://rbwhitaker.wikidot.com/monogame-texture-atlases-1 
 */
namespace TileMapAndMoveCharacter
{
    class Character
    {
        public Texture2D Texture { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public Rectangle Rectangle { get; set; }
        private int currentFrame;
        private int totalFrames;
        public Vector2 Location { get; set; }
        public Character(Texture2D Texture)
        {
            this.Texture = Texture;
            Height = 36;
            Width = 32;
            currentFrame = 0;
            totalFrames = 12;
            Location = new Vector2(320, 240);
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames) {
                currentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int row = (int)((float)currentFrame / (float)3);
            int column = currentFrame % 3;
            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, 32, 36);
            Rectangle destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 32, 36);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

}
