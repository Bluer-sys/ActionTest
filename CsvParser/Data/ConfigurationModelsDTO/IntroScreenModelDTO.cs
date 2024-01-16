using System.Collections.Generic;

namespace Data.ConfigurationModelsDTO
{
    public class IntroScreenModelDTO
    {
        public string GameTitle { get; private set; }
        public string ExampleTileID { get; private set; }

        public IEnumerable<string> Instructions { get; private set; }

        public IntroScreenModelDTO(
            string gameTitle,
            string exampleTileID,
            IEnumerable<string> instructions)
        {
            GameTitle = gameTitle;
            ExampleTileID = exampleTileID;

            Instructions = instructions;
        }
    }
}