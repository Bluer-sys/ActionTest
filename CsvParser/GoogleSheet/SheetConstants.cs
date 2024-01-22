namespace CsvParser.GoogleSheet;

public static class SheetConstants
{
	public const string SheetId = "1urut9HakHCFUcK_hm1ybPNJCvDSeBj52A0Tqw7vmoZs";

	public const double DefaultDelayPerRequest = 0.1f;
	
	public const string CredentialCachePath = "Credentials/credentials.json";
	
	public const string OutputFolder = "Data";
	public const string TokenFolder = "token";
	
	public const string ServerKeyPath = "Utilities/key.json";

	public static string GetKeyPath()
	{
		string workingDir = Environment.CurrentDirectory;

		string projectDir = Directory.GetParent(workingDir).Parent.Parent.FullName;

		string keyDir = projectDir + "/" + ServerKeyPath;
		
		return keyDir;
	}
}