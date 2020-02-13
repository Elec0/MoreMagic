using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using System.Collections.Generic;
using xTile;
using xTile.Tiles;
using static SpaceCore.Content;

namespace MoreMagic
{
    public class Content
    {
        public static Texture2D loadTexture(string path)
        {
            return ModEntry.instance.Helper.Content.Load<Texture2D>($"res/{path}", ContentSource.ModFolder);
        }
        public static string loadTextureKey(string path)
        {
            return ModEntry.instance.Helper.Content.GetActualAssetKey($"res/{path}", ContentSource.ModFolder);
        }

        public static Map loadMap(string mapName, string variant = "map")
        {
            string path = $"res/{mapName}/{variant}.tmx";
            return SpaceCore.Content.loadTmx(ModEntry.instance.Helper, mapName, path);
        }

        public static TileSheet loadTilesheet(string ts, Map xmap, out Dictionary<int, TileAnimation> animMapping)
        {
            string path = $"res/{ts}.tsx";
            return SpaceCore.Content.loadTsx(ModEntry.instance.Helper, path, ts, xmap, out animMapping);
        }
    }
}
