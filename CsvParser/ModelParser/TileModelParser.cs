using CsvParser.ModelParser.Interfaces;
using Data.ConfigurationModelsDTO;
using Newtonsoft.Json;

namespace CsvParser.ModelParser;

public class TileModelParser : IParser
{
	public string Parse(IList<IList<object>> data)
	{
		List<TileModelDTO> dtos = new();

		for (int i = 1; i < data.Count; i++)
		{
			TileModelDTO dto = new(
				data[i][0].ToString()!, 
				data[i][1].ToString()!, 
				data[i][2].ToString()!
			);
			
			dtos.Add(dto);
		}

		return JsonConvert.SerializeObject(dtos, Formatting.Indented);
	}
}