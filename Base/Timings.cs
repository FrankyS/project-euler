namespace ProjectEuler.Base
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text;
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
			StringBuilder sb = new StringBuilder()
				.AppendLine("# Project-Euler")
				.AppendLine("C# Solutions for [Project-Euler](https://projecteuler.net/problems)")
				.AppendLine()
				.AppendLine("# Status")
				.AppendLine("All timings are just from the last run.")
				.AppendLine()
				.AppendLine("| # | Time | Solution | ")
				.AppendLine("| ---: | ---: | --- |");
			
			Stopwatch stopwatch = new Stopwatch();
			foreach(KeyValuePair<Type, MethodInfo> solution in this.solutions)
			{
				object instance = Activator.CreateInstance(solution.Key);

				stopwatch.Start();
				solution.Value.Invoke(instance, null);
				stopwatch.Stop();

				sb.AppendLine(CreateInfo(solution.Key.Name, stopwatch.ElapsedMilliseconds));
				stopwatch.Reset();
			}

			File.WriteAllText(@"..\..\README.md", sb.ToString());
		}

		private static string CreateInfo(string problemName, long elapsedMilliseconds)
		{
			string problemNumber = problemName.Substring(7)
				.TrimStart('0');

			return string.Format("| {0} | {1} ms | [Solution](https://github.com/FrankyS/project-euler/blob/master/Solutions/{2}.cs) |", 
				problemNumber, elapsedMilliseconds, problemName);
		}
	}
}