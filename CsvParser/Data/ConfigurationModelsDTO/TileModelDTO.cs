namespace Data.ConfigurationModelsDTO
{
    public class TileModelDTO
    {
        public string ID { get; private set; }
        public string BucketID { get; private set; }

        public string AarText { get; private set; }

        public TileModelDTO(
            string id,
            string bucketID,
            string aarText)
        {
            ID = id;
            BucketID = bucketID;
            AarText = aarText;
        }
    }
}
