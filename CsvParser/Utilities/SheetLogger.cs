using CsvParser.GoogleSheet;

namespace CsvParser.Utilities;

public static class SheetLogger
{
	public static void Log(SheetData data)
	{
		Console.WriteLine();
		Console.WriteLine( "===" + data.Title + "===" );
		
		for (int i = 0; i < data.Values.Count; i++)
		{
			for (int j = 0; j < data.Values[i].Count; j++)
			{
				Console.Write( data.Values[i][j] + " " );
			}

			Console.WriteLine();
		}
	}
}