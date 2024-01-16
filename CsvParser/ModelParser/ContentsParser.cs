using System.Globalization;
using CsvParser.ModelParser.Interfaces;
using Data.ConfigurationModelsDTO;
using Newtonsoft.Json;

namespace CsvParser.ModelParser;

public class ContentsParser : IParser
{
	public string Parse(IList<IList<object>> data)
	{
		List<ContentModelDTO> dtos = new();

		for (int i = 1; i < data.Count; i++)
		{
			ContentModelDTO dto = new(
				data[i][0].ToString()!, 
				data[i][1].ToString()!, 
				data[i][2].ToString()!,
				data[i][3].ToString()!,
				float.Parse(data[i][4].ToString()!, CultureInfo.InvariantCulture)
			);
			
			dtos.Add(dto);
		}

		return JsonConvert.SerializeObject(dtos, Formatting.Indented);
	}
}