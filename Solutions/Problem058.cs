namespace ProjectEuler.Solutions
{
	using System;
	using System.Collections.Generic;
	using NUnit.Framework;
	using ProjectEuler.Helper;

	/// <summary>
	/// Spiral primes.
	/// Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed.
	/// <para>37 36 35 34 33 32 31</para>
	/// <para>38 17 16 15 14 13 30</para>
	/// <para>39 18  5  4  3 12 29</para>
	/// <para>40 19  6  1  2 11 28</para>
	/// <para>41 20  7  8  9 10 27</para>
	/// <para>42 21 22 23 24 25 26</para>
	/// <para>43 44 45 46 47 48 49</para>
	/// It is interesting to note that the odd squares lie along the bottom right diagonal, but what is more interesting is that 8 out of the 13 numbers lying along both diagonals are prime; 
	/// that is, a ratio of 8/13 ≈ 62%.
	/// <para>
	/// If one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will be formed. 
	/// If this process is continued, what is the side length of the square spiral for which the ratio of primes along both diagonals first falls below 10%?
	/// </para>
	/// </summary>
	public class Problem058 : Problem
	{
		public override long Solution()
		{
			int size = 1;

			double amountPrimes = 0;

			long currentNumber = 1;
			double ratio;
			do
			{
				size++;
				for (int i = 0; i < 4; i++)
				{
					currentNumber += size;
					if (Primes.IsPrimeNumber(currentNumber))
					{
						amountPrimes++;
					}
				}
				size++;

				double amountNumbers = size * 2 - 1;
				ratio = amountPrimes / amountNumbers;
			} while (ratio >= 0.10);

			return size;
		}

		[Test]
		public void TestForSolution()
		{
			Assert.AreEqual(26241, this.Solution());
		}
	}
}