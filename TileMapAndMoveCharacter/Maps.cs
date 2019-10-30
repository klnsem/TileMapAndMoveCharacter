using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

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
        public int sheetX;
        public int sheetY;
        public int size;
        public Rectangle sheetRectangle;
        public Rectangle outputRectangle;
    }
    class Maps
    {
        internal static int[,] LoadMapFromFile(string fileName) {
            int[,] newMap = new int[15, 25];
            try {
                using (StreamReader sr = new StreamReader("Content\\" + fileName)) {
                    string line;
                    int x = 0;
                    while ((line = sr.ReadLine()) != null) {
                        string[] splitLine = line.Split(',');
                        for (int y = 0; y < splitLine.Length; y++) {
                            newMap[x, y] = int.Parse(splitLine[y]);
                        }
                        x++;
                    }
                }
            } catch (Exception e) {
                System.Console.WriteLine("ERROR: " + e);
            }
            return newMap;
        }
        internal static ScreenMap CreateMap()
        {
            ScreenMap newMap = new ScreenMap();
            newMap.id = 0;
            newMap.tiles = LoadMapFromFile("map1.mapr");
            newMap.mapType = 22;
            newMap.tilesName = "tiles";
            return newMap;
        }
        internal static Tile GetTile(int id, Texture2D texture, int outputX, int outputY)
        {
            Tile newTile = new Tile();
            newTile.tileId = 1;
            newTile.size = 32;
            newTile.sheetX = 14 * 32;
            newTile.sheetY = 0;
            newTile.sheetRectangle = new Rectangle(id * 32, 0 * 32, 32, 32);
            newTile.texture = texture;
            newTile.outputRectangle = new Rectangle(outputY * 32, outputX * 32, 32, 32);
            return newTile;
        }
        
    }
}
