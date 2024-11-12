namespace Cryptor
{
	class Program
	{
		const string InjectionPath = "/Users/sarpinmacbookprosu/RiderProjects/Cryptor/Cryptor/Injection.txt";

		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Welcome to the Code Injector 😊!");

				// Prompt user for target program path
				Console.WriteLine("Path pretty please 🥺: ");
				string targetProgramPath = Console.ReadLine() ?? throw new NullReferenceException();

				// Read the target program code
				string targetCode = File.ReadAllText(targetProgramPath);

				// Inject the new code into the target program
				string injectedCode = InjectNewCode(targetCode, File.ReadAllText(InjectionPath));

				// Write the modified code back to the file
				File.WriteAllText(targetProgramPath, injectedCode);

				Console.WriteLine("Code injection successful 😜!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred 💀: {ex.Message}");
			}
		}

		static string InjectNewCode(string targetCode, string newCode)
		{
			int insertionPoint = targetCode.IndexOf("0"); // Replace with your desired insertion point

			if (insertionPoint == -1)
			{
				Console.WriteLine("Insertion point not found 😡!");
				return targetCode;
			}

			string[] lines = targetCode.Split('\n');
			int lineNumber = insertionPoint / lines[0].Length + 1;

			// Insert the new code at the specified line number
			for (int i = 0; i < lineNumber - 1; i++)
			{
				lines[i] += Environment.NewLine;
			}

			lines[lineNumber - 1] += newCode + Environment.NewLine;

			return string.Join("\n", lines);
		}
	}
}