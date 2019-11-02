using DungeonCrawlerGame.Objects;

namespace DungeonCrawlerGame.Map
{
    public class MapCell 
    {
        public MapTexture Texture { get; set; }
        public bool IsEmpty { get; set; }
        public GameObject Object { get; set; } 
    }
}