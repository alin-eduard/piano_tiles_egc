namespace PianoTilesEGC.LevelData
{
    public class TileData
    {
        private Position position;
        private float length;
        private int life;
        private TileType type;

        public Position Position
        {
            get => position;
            set => position = value;
        }

        public float Length
        {
            get => length;
            set => length = value;
        }

        public int Life
        {
            get => life;
            set => life = value;
        }

        public TileType Type
        {
            get => type;
            set => type = value;
        }
    }
}