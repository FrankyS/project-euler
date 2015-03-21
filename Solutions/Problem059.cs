namespace ProjectEuler.Solutions
{
	using System;
	using System.Diagnostics;
	using System.Linq;
	using System.Text;
	using NUnit.Framework;
	using ProjectEuler.Input;

	/// <summary>
	/// XOR decryption.
	/// Each character on a computer is assigned a unique code and the preferred standard is ASCII (American Standard Code for Information Interchange). 
	/// For example, uppercase A = 65, asterisk (*) = 42, and lowercase k = 107.
	/// <para>
	/// A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each byte with a given value, taken from a secret key. 
	/// The advantage with the XOR function is that using the same encryption key on the cipher text, restores the plain text; for example, 65 XOR 42 = 107, then 107 XOR 42 = 65.
	/// </para>
	/// For unbreakable encryption, the key is the same length as the plain text message, and the key is made up of random bytes. 
	/// The user would keep the encrypted message and the encryption key in different locations, and without both "halves", it is impossible to decrypt the message.
	/// <para>
	/// Unfortunately, this method is impractical for most users, so the modified method is to use a password as a key. If the password is shorter than the message, which is likely, the key is repeated cyclically throughout the message. The balance for this method is using a sufficiently long password key for security, but short enough to be memorable.
	/// </para>
	/// Your task has been made easy, as the encryption key consists of three lower case characters. Using Problem059.txt, a file containing the encrypted ASCII codes, 
	/// and the knowledge that the plain text must contain common English words, decrypt the message and find the sum of the ASCII values in the original text.
	/// </summary>
	public class Problem059 : Problem
	{
		public override long Solution()
		{
			long solution = 0;

			byte[] encryptedBytes = Input.Problem059.Split(',')
				.Select(x => byte.Parse(x))
				.ToArray();

			byte[] key = { 103, 111, 100 };
			for (int i = 0; i < encryptedBytes.Length; i++)
			{
				int decryptedValue = encryptedBytes[i] ^ key[i % 3];
				solution += decryptedValue;
			}

			return solution;
		}

		[Test]
		public void TestForExample()
		{
			const byte uppercaseA = (byte)'A';
			const byte asterisk = (byte)'*';
			const byte lowercaseK = (byte)'k';

			Assert.AreEqual(65, uppercaseA);
			Assert.AreEqual(42, asterisk);
			Assert.AreEqual(107, lowercaseK);

			Assert.AreEqual(lowercaseK, uppercaseA ^ asterisk);
			Assert.AreEqual(uppercaseA, lowercaseK ^ asterisk);
		}

		[Test]
		public void TestForSolution()
		{
			Assert.AreEqual(107359, this.Solution());
		}
	}
}