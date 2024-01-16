using System.Globalization;
using CsvParser.ModelParser.Interfaces;
using Data.ConfigurationModelsDTO;
using Newtonsoft.Json;

namespace CsvParser.ModelParser;

public class GameModelParser : IParser
{
	public string Parse(IList<IList<object>> data)
	{
		GameModelDTO dto = new(
			int.Parse( data[0][1].ToString()!, CultureInfo.InvariantCulture ),
			int.Parse( data[1][1].ToString()!, CultureInfo.InvariantCulture ),
			int.Parse( data[2][1].ToString()!, CultureInfo.InvariantCulture ),
			int.Parse( data[3][1].ToString()!, CultureInfo.InvariantCulture ),
			int.Parse( data[4][1].ToString()!, CultureInfo.InvariantCulture ),
			bool.Parse( data[5][1].ToString()!  ),
			bool.Parse( data[6][1].ToString()! ),
			bool.Parse( data[7][1].ToString()! ),
			float.Parse( data[8][1].ToString()!, CultureInfo.InvariantCulture ),
			bool.Parse( data[9][1].ToString()! ),
			float.Parse( data[10][1].ToString()!, CultureInfo.InvariantCulture ),
			bool.Parse( data[11][1].ToString()! ),
			data[12][1].ToString()!,
			float.Parse( data[13][1].ToString()!, CultureInfo.InvariantCulture ),
			data[14][1].ToString()!,
			data[15][1].ToString()!,
			data[16][1].ToString()!,
			data[17][1].ToString()!,
			float.Parse( data[18][1].ToString()!, CultureInfo.InvariantCulture ),
			data[19][1].ToString()!
		);

		return JsonConvert.SerializeObject(dto, Formatting.Indented);
	}
}