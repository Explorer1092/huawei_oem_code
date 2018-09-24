using System;
using System.Security.Cryptography;  
using System.Globalization;
using System.Linq;
public class Program
{
	public static void Main()
	{
		uint number;
		int num2;
		string data = "9A 33 44 E3 50 96 CF 31 95 49 E4 A3 A1 13 46 63 A7 7D 0B 89 EA 05 92 56 A1 C8 30 38 C1 EF 99 B6";
		string str2 = "41 39 CB 0E D2 8F 6F 87 78 A8 1A 0C CA DA AB 22 5B 6E 0B A2 73 49 48 04 FF 3A BC 4D AD 90 1D C9";

		SHA256Managed managed = new SHA256Managed();

		byte[] secondArray = new byte[32];
		byte[] destinationArray = new byte[64];
		byte[] buffer = new byte[8];

		//this loop is simply creating a byte array of 32 elements (first string input)  each after converted form of hex ascii value.

		for (num2 = 0; num2 < 32; num2++)
		{
			uint.TryParse(data.Substring(num2 * 3, 2), NumberStyles.HexNumber, null, out number);
			secondArray[num2] = (byte)number;
		}
		Console.WriteLine("secondArray = "+BitConverter.ToString(secondArray).Replace("-",""));
		// this loop is creating a byte array of 64 elements but 32 pairs(95 characters) of hexadecimal numbers from your 2nd input string and after conversion put in to this array from 32 to 63th position of this array ....

		num2 = 0;

		for (; num2 < 32; num2++)
		{
			uint.TryParse(str2.Substring(num2 * 3, 2), NumberStyles.HexNumber, null, out number);
			destinationArray[32 + num2] = (byte)number;

		}
		Console.WriteLine("destinationArray = "+BitConverter.ToString(destinationArray).Replace("-",""));

		int i = 98925750;

		// this loop is simply creating a buffer array[8] of character 57 each in it .
		int num5 = i;
		for (num2 = 0; num2 < 8; num2++)
		{
			buffer[7 - num2] = (byte)((num5 % 10) + 48);
			num5 /= 10;
		}
		Console.WriteLine("buffer = "+BitConverter.ToString(buffer).Replace("-",""));


		// hashing with 256 bit excryption the array and then copying to first 32 empty location of destination array .
		Array.Copy(managed.ComputeHash(buffer), destinationArray, 32);
		Console.WriteLine("managed.ComputeHash(buffer) = "+BitConverter.ToString(managed.ComputeHash(buffer)).Replace("-",""));

		// comparison of two byte array with their encryption values and if found equal then will show the required string code and will be knocked out of this loop ...
		Console.WriteLine("destinationArray = "+BitConverter.ToString(destinationArray).Replace("-",""));
		Console.WriteLine("managed.ComputeHash(destinationArray) = "+BitConverter.ToString(managed.ComputeHash(destinationArray)).Replace("-",""));
		if (managed.ComputeHash(destinationArray).SequenceEqual<Byte>(secondArray))
		{
			Console.WriteLine("sucess");
		}
	}
}
