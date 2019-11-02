using DungeonCrawlerGame.Objects;

namespace DungeonCrawlerGame.Map
{
    public class MapCell 
    {
        public bool IsEmpty { get; set; }
        public int Texture { get; set; }
        public GameObject Object { get; set; }
        public int Appearance { get; set; }

        public MapCell(int texture, bool isEmpty)
        {
            Texture = texture;
            IsEmpty = isEmpty;
        }
    }
}