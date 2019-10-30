using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileMapAndMoveCharacter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D mapTiles;
        private Tile[,] BackgroundToDraw;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenMap screenMap = Maps.CreateMap();
            LoadMapResources(screenMap);
            BackgroundToDraw = new Tile[15, 25];
            for (int x = 0; x < 15; x++) {
                for (int y = 0; y < 25; y++) {
                    int id = screenMap.tiles[x, y];
                    BackgroundToDraw[x, y] = Maps.GetTile(id, mapTiles, x, y);
                }
            }

            
            // TODO: use this.Content to load your game content here
        }

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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for (int x = 0; x < 15; x++) {
                for (int y = 0; y < 25; y++) {
                    spriteBatch.Draw(mapTiles, BackgroundToDraw[x, y].outputRectangle, BackgroundToDraw[x, y].sheetRectangle, Color.White);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
        internal void LoadMapResources(ScreenMap screenMap)
        {
            mapTiles = this.Content.Load<Texture2D>(screenMap.tilesName);
        }
    }
}
