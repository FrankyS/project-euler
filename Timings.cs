namespace ProjectEuler
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Reflection;
	using NUnit.Framework;

	[TestFixture]
	public sealed class Timings
	{
		private Dictionary<Type, MethodInfo> solutions;

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			this.solutions = assembly.GetTypes()
				.Where(x => x.BaseType == typeof(Problem))
				.ToDictionary(x => x, x => x.GetMethod("Solution", BindingFlags.Public | BindingFlags.Instance));
		}

		[Test]
		public void GetTimingsForAllProblems()
		{
			Stopwatch stopwatch = new Stopwatch();
			foreach(KeyValuePair<Type, MethodInfo> solution in this.solutions)
			{
				object instance = Activator.CreateInstance(solution.Key);

				stopwatch.Start();
				solution.Value.Invoke(instance, null);
				stopwatch.Stop();

				this.OutputInfo(solution.Key.Name, stopwatch.ElapsedMilliseconds);
				stopwatch.Reset();
			}
		}

		private void OutputInfo(string problemName, long elapsedMilliseconds)
		{
			string problemNumber = problemName.Substring(7)
				.TrimStart('0');

			Console.WriteLine("| {0} | {1} ms |", problemNumber.PadLeft(4), elapsedMilliseconds.ToString().PadLeft(4));
		}
	}
}