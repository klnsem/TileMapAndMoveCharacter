using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapAndMoveCharacter
{
    internal struct ScreenMap
    {
        public int id;
        public int[,] tiles;
        public int mapType;
        public string tilesName;
    }
    struct Tile
    {
        public int tileId;
        public Texture2D texture;
        public int x;
        public int y;
        public int size;
        public Rectangle sheetRectangle;
        public Rectangle outputRectangle;
    }
    class Maps
    {
        internal static ScreenMap CreateMap()
        {
            ScreenMap newMap = new ScreenMap();
            newMap.id = 0;
            newMap.tiles = ReadMapTiles();
            newMap.mapType = 22;
            newMap.tilesName = "tiles";
            return newMap;
        }
        internal static int[,] ReadMapTiles()
        {
            int[,] newMap = new int[25, 15];
            for (int x = 0; x < 24; x++) {
                for (int y = 0; y < 14; y++) {
                    newMap[x, y] = 1;
                }
            }
            return newMap;
        }
        internal static Tile GetTile(int id, Texture2D texture, int outputX, int outputY)
        {
            Tile newTile = new Tile();
            newTile.tileId = 1;
            newTile.size = 32;
            newTile.x = 14 * 32;
            newTile.y = 0;
            newTile.sheetRectangle = new Rectangle(id * 32, 0 * 32, 32, 32);
            newTile.texture = texture;
            newTile.outputRectangle = new Rectangle(outputX * 32, outputY * 32, 32, 32);
            return newTile;
        }
        
    }
}
