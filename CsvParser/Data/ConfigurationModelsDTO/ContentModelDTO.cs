namespace Data.ConfigurationModelsDTO
{
    public struct ContentModelDTO
    {
        public string ID { get; private set; }

        public string Text { get; private set; }

        public string FontType { get; private set; }
        public string Style { get; private set; }
        public float Size { get; private set; }

        public ContentModelDTO(
            string id,
            string text,
            string fontType,
            string style,
            float size)
        {
            ID = id;
            Text = text;
            FontType = fontType;
            Style = style;
            Size = size;
        }
    }
}