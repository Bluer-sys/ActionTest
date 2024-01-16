using CsvParser.GoogleSheet;
using CsvParser.GoogleSheet.Interfaces;
using CsvParser.ModelParser;
using CsvParser.ModelParser.Interfaces;
using CsvParser.Utilities;

namespace CsvParser;

public class Application
{
	private readonly IGoogleSheetsReader _googleSheetsReader;
	
	public Application(IGoogleSheetsReader googleSheetsReader)
	{
		_googleSheetsReader = googleSheetsReader;
	}

	public async Task RunAsync()
	{
		IReadOnlyList<SheetData> sheets = (await _googleSheetsReader.GetAsync(SheetConstants.SheetId)).ToList();
		
		ParseAndWriteAllAsync( sheets );
	}

	private async void ParseAndWriteAllAsync(IReadOnlyList<SheetData> sheets)
	{
		if ( !Directory.Exists( SheetConstants.OutputFolder ) )
		{
			Directory.CreateDirectory( SheetConstants.OutputFolder );
		}
		
		SheetData tiles = sheets[0];
		SheetData tileContents = sheets[1];
		SheetData buckets = sheets[2];
		SheetData game = sheets[3];
		SheetData introScreen = sheets[4];
		
		await ParseToFileAsync( tiles, new TileModelParser() );
		await ParseToFileAsync( tileContents, new ContentsParser() );
		await ParseToFileAsync( buckets, new ContentsParser() );
		await ParseToFileAsync( game, new GameModelParser() );
		await ParseToFileAsync( introScreen, new IntroScreenModelParser() );
	}

	private async Task ParseToFileAsync(SheetData sheet, IParser parser)
	{
		using (StreamWriter file = File.CreateText( SheetConstants.OutputFolder + "/" + sheet.Title + ".json" ))
		{
			await file.WriteAsync( parser.Parse( sheet.Values ) );

			SheetLogger.Log( sheet );
		}
	}
}