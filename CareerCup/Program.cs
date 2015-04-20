using CareerCup.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();

				// List available problems
				IProblem[] problems = Assembly.GetExecutingAssembly().GetTypes()
					.Where(t => !t.IsInterface && typeof(IProblem).IsAssignableFrom(t))
					.Select(t => (IProblem)Activator.CreateInstance(t))
					.OrderBy(t => { int i = 1; return t.Id().Split(new char[] { '.' }).Sum(e => Convert.ToInt16(e) * (100 ^ i--)); })
					.ToArray();

				// Print them
				foreach (var problem in problems)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write(problem.Id());
					Console.ResetColor();
					Console.WriteLine(": " + problem.Statement());
				}

				// Get user's selection and args
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("Enter problem number and args, or press enter to quit: ");
				Console.ResetColor();

				// Quit on empty line or q
				var input = Console.ReadLine();
				if (string.IsNullOrEmpty(input) || input == "q")
					break;

				// Get problem number and arguments
				var problemNumber = input.Split(new char[] { ' ' })[0];
				var problemArgs = input.Substring(problemNumber.Length).Trim();

				try
				{
					Console.Clear();

					// Run the requested problem
					var problem = problems.Where(p => p.Id() == problemNumber).First();
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(problem.Statement());

					// Problem can be run with a single or multiple iterations
					string[] iterationArgs = null;

					// If user provided args, it's a single iteration
					if (!string.IsNullOrEmpty(problemArgs))
						iterationArgs = new string[1] { problemArgs };
					else
					{
						iterationArgs = problem.TestArgs();
						if (iterationArgs == null || iterationArgs.Length == 0)
							iterationArgs = new string[] { null };
					}

					// Execute problem iterations
					foreach (var iargs in iterationArgs)
					{
						// Confirm args back to the user
						if (!string.IsNullOrEmpty(iargs))
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine(iargs);
						}

						// Run
						Console.ResetColor();
						problem.Run(iargs);
						Console.ResetColor();
						Console.WriteLine();
					}
				}
				catch (Exception ex)
				{
					// In case of errors
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(ex.Message);
					Console.ResetColor();
				}


				// Repeat or quit 
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("Press any key to continue, or q or escape to quit... ");
				Console.ResetColor();
				var key = Console.ReadKey();
				if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Q)
					break;
			}
		}
	}
}
