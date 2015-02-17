namespace ProjectEuler.Solutions
{
	using NUnit.Framework;

	/// <summary>
	/// Self powers.
	/// The series, 1<sup>1</sup> + 2<sup>2</sup> + 3<sup>3</sup> + ... + 10<sup>10</sup> = 10405071317.
	/// <para>Find the last ten digits of the series, 1<sup>1</sup> + 2<sup>2</sup> + 3<sup>3</sup> + ... + 1000<sup>1000</sup>.</para>
	/// </summary>
	public class Problem048 : Problem
	{
		public override long Solution()
		{
			long result = 0;

			const long modulo = 10000000000;
			for (int i = 1; i <= 1000; i++)
			{
				long current = 1;
				for (int j = 1; j <= i; j++)
				{
					current *= i;
					current %= modulo;
				}

				result += current;
				result %= modulo;
			}
			
			return result;
		}

		[Test]
		public void TestForProblem()
		{
			Assert.AreEqual(9110846700, this.Solution());
		}
	}
}