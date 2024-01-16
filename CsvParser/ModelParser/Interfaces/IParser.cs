namespace CsvParser.ModelParser.Interfaces;

public interface IParser
{
	/// <summary>
	/// Parses sheet data to DTO and returns JSON
	/// </summary>
	/// <param name="data">Sheet columns and rows</param>
	/// <returns>Sheet data in JSON format</returns>
	string Parse(IList<IList<object>> data);
}