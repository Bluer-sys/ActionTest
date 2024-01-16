namespace Data.ConfigurationModelsDTO
{
    public class GameModelDTO
    {
        public int Strikes { get; private set; }

        public int ScorePerCorrectTile { get; private set; }
        public int ScoreToOneStar { get; private set; }
        public int ScoreToTwoStars { get; private set; }
        public int ScoreToThreeStars { get; private set; }

        public bool IsScoreShown { get; private set; }
        public bool IsStrikesShown { get; private set; }
        public bool IsTimerShown { get; private set; }

        public float InitialTileSpeed { get; private set; }
        public bool IsSpeedIncreaseOverTime { get; private set; }
        public float SpeedIncreaseRate { get; private set; }

        public bool IsTilesInRandomOrder { get; private set; }
        public string PlayMode { get; private set; }
        public float GameTimeInSeconds { get; private set; }

        public string BottomText { get; private set; }

        public string TileAlignment { get; private set; }
        public string BucketAlignment { get; private set; }

        public string AarFontType { get; private set; }
        public float AarSize { get; private set; }
        public string AarStyle { get; private set; }

        public GameModelDTO(
            int strikes,
            int scorePerCorrectTile,
            int scoreToOneStar,
            int scoreToTwoStars,
            int scoreToThreeStars,
            bool isScoreShown,
            bool isStrikesShown,
            bool isTimerShown,
            float initialTileSpeed,
            bool isSpeedIncreaseOverTime,
            float speedIncreaseRate,
            bool isTilesInRandomOrder,
            string playMode,
            float gameTimeInSeconds,
            string bottomText,
            string tileAlignment,
            string bucketAlignment,
            string aarFontType,
            float aarSize,
            string aarStyle)
        {
            Strikes = strikes;

            ScorePerCorrectTile = scorePerCorrectTile;
            ScoreToOneStar = scoreToOneStar;
            ScoreToTwoStars = scoreToTwoStars;
            ScoreToThreeStars = scoreToThreeStars;

            IsScoreShown = isScoreShown;
            IsStrikesShown = isStrikesShown;
            IsTimerShown = isTimerShown;

            InitialTileSpeed = initialTileSpeed;
            IsSpeedIncreaseOverTime = isSpeedIncreaseOverTime;
            SpeedIncreaseRate = speedIncreaseRate;

            IsTilesInRandomOrder = isTilesInRandomOrder;
            PlayMode = playMode;
            GameTimeInSeconds = gameTimeInSeconds;

            BottomText = bottomText;

            TileAlignment = tileAlignment;
            BucketAlignment = bucketAlignment;

            AarFontType = aarFontType;
            AarSize = aarSize;
            AarStyle = aarStyle;
        }
    }
}