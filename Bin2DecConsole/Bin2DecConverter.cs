namespace Bin2DecConsole;

public static class Bin2DecConverter
{
	public static (bool success, int? convertedValue, IList<string> errors) Convert(string binaryValue)
	{
		string sanitizedBinaryValue = Sanitize(binaryValue);
		int? convertedValue = null;
		var errors = new List<string>();
		var success = Validate(sanitizedBinaryValue, errors);

		if (success)
		{
			convertedValue = 0;
			for (int i = 0; i < sanitizedBinaryValue.Length; i++)
				if (sanitizedBinaryValue[i] == '1')
					convertedValue += (int)Math.Pow(2, sanitizedBinaryValue.Length - 1 - i);
		}

		return (success, convertedValue, errors);
	}

	private static string Sanitize(string binaryValue)
	{
		return binaryValue.Trim().Replace(" ", string.Empty);
	}

	private static bool Validate(string binaryValue, IList<string> errors)
	{
		var validations = new List<bool>
		{
			IsNeitherNullNorEmpty(binaryValue, errors),
			HasValidDigits(binaryValue, errors)
		};

		return validations.All(v => v is true);
	}

	private static bool IsNeitherNullNorEmpty(string binaryValue, IList<string> errors)
	{
		if (string.IsNullOrEmpty(binaryValue))
		{
			errors.Add("O valor não pode ser vazio.");
			return false;
		}

		return true;
	}

	private static bool HasValidDigits(string binaryValue, IList<string> errors)
	{
		if (binaryValue.Any(n => n != '0' && n != '1'))
		{
			errors.Add("O valor deve conter somente os dígitos '0' e '1'.");
			return false;
		}

		return true;
	}

}
