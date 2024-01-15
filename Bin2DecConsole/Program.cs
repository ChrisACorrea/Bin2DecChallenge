using Bin2DecConsole;

Console.Write("Insira o valor em binário: ");
var binaryValue = Console.ReadLine() ?? "";

var (success, convertedValue, errors) = Bin2DecConverter.Convert(binaryValue);
Console.WriteLine("");

if (success)
	Console.WriteLine($"O valor decimal é: {convertedValue}");
else
	foreach (var error in errors)
	{
		Console.WriteLine(error);
	}
