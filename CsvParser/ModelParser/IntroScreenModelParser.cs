using CsvParser.ModelParser.Interfaces;
using Data.ConfigurationModelsDTO;
using Newtonsoft.Json;

namespace CsvParser.ModelParser;

public class IntroScreenModelParser : IParser
{
	public string Parse(IList<IList<object>> data)
	{
		List<string> instructions = new();

		for (int i = 2; i < data.Count; i++)
		{
			instructions.Add( data[i][1].ToString()! );
		}
		
		IntroScreenModelDTO dto = new(
			data[0][1].ToString()!,
			data[1][1].ToString()!,
			instructions
		);

		return JsonConvert.SerializeObject(dto, Formatting.Indented);
	}
}