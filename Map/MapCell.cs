using DungeonCrawlerGame.Objects;

namespace DungeonCrawlerGame.Map
{
    public class MapCell 
    {
        public bool IsEmpty { get; set; } = true;
        public int Texture { get; set; }
        public GameObject Object { get; set; }
        public int Appearance { get; set; } = 0;

        public MapCell(int texture, bool isEmpty, int appearance = 0)
        {
            Texture = texture;
            IsEmpty = isEmpty;
            Appearance = appearance;
        }
    }
}