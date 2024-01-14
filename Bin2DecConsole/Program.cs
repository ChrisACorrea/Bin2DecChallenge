Console.Write("Insira o valor em binário: ");
var binaryValue = Console.ReadLine() ?? "";

if (binaryValue.Any(n => n != '0' && n != '1'))
{
	Console.WriteLine("Valor inválido. O valor deve conter somente os dígitos '0' e '1'.");
	Environment.Exit(0);
}

var decimalValue = 0;
for (int i = 0; i < binaryValue.Length; i++)
	if (binaryValue[i] == '1')
		decimalValue += (int)Math.Pow(2, binaryValue.Length - 1 - i);

Console.WriteLine("");
Console.WriteLine($"O valor decimal de {binaryValue} é: {decimalValue}");