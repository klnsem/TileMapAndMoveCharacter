using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public int InternalFrameCounter { get; set; }
        public enum Directions { NORTH, EAST, SOUTH, WEST}
        public Directions Facing { get; set; }
        private bool CharacterMoving { get; set; }
        private int movingSteps = 0;
        public Character(Texture2D Texture)
        {
            this.Texture = Texture;
            Height = 36;
            Width = 32;
            currentFrame = 0;
            totalFrames = 3;
            Location = new Vector2(320, 240);
            Facing = Directions.SOUTH;
            CharacterMoving = false;
        }
        public void Update()
        {
            InternalFrameCounter++;
            if (InternalFrameCounter % 12 == 0) {
                currentFrame++;
                if (CharacterMoving && movingSteps < 3) {
                    Location = GetNewLocation(Facing);
                    movingSteps++;
                }
                if (movingSteps >= 3) {
                    movingSteps = 0;
                    CharacterMoving = false;
                }
                if (currentFrame == totalFrames) {
                    currentFrame = 0;
                }
            }
            if (InternalFrameCounter > 60) {
                InternalFrameCounter = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int row;
            switch (Facing) { // This assumes the vertical order in the spritesheet this project comes with.
                case Directions.NORTH:
                    row = 0;
                    break;
                case Directions.EAST:
                    row = 1;
                    break;
                case Directions.SOUTH:
                    row = 2;
                    break;
                case Directions.WEST:
                    row = 3;
                    break;
                default:
                    row = 0;
                    break;
            }
            int column = currentFrame;
            Rectangle sourceRectangle = new Rectangle(Width * column, Height * row, 32, 36);
            Rectangle destinationRectangle;
            destinationRectangle = new Rectangle((int)Location.X, (int)Location.Y, 32, 36);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public void MoveCharacter(Directions direction)
        {
            if (!CharacterMoving) {
                Facing = direction;
                CharacterMoving = true;
            }
        }
        public Vector2 GetNewLocation(Directions direction)
        {
            Vector2 newLocation;
            switch (direction) {
                case Directions.NORTH:
                    newLocation = new Vector2(Location.X, Location.Y - 8);
                    break;
                case Directions.EAST:
                    newLocation = new Vector2(Location.X + 8, Location.Y);
                    break;
                case Directions.SOUTH:
                    newLocation = new Vector2(Location.X, Location.Y + 8);
                    break;
                case Directions.WEST:
                    newLocation = new Vector2(Location.X - 8, Location.Y);
                    break;
                default:
                    newLocation = new Vector2(Location.X + 8, Location.Y);
                    break;
            }
            return newLocation;
        }
    }

}
