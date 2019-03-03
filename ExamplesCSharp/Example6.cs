using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamplesCSharp.Exemple6
{
	public class CompilerIntegratedFeatures
	{
		// Compose int into elevetad type IEnumerable<T>
		public IEnumerable<int> EnumerableExemple()
		{
			yield return 1;
			yield return 2;
			if (2 > 1)
			{
				yield return 10;
			}
			else
			{
				yield return 20;
			}
		}

		// Compose int into elevetad type Task<T>
		public async Task<int> TaskExemple()
		{
			await Task.Delay(100);
			if (2 > 1)
			{
				await Task.Delay(100);
			}

			return 10;
		}
	}




	public class Railway
	{
		public FSharpResult<int, string> WorkflowStep1(int input)
		{
			if (input % 2 == 0)
			{
				return FSharpResult<int, string>.NewError("Sholud be odd");
			}
			else
			{
				var result = input * 356;
				return FSharpResult<int, string>.NewOk(result);
			}
		}

		public FSharpResult<decimal, string> WorkflowStep2(int input)
		{
			if (input % 3 == 0)
			{
				return FSharpResult<decimal, string>.NewError("Sholud not be dividable by 3");
			}
			else
			{
				var result = input * 100.0m / 356;
				return FSharpResult<decimal, string>.NewOk(result);
			}
		}

		public string WorkflowStep3(decimal result)
		{
			return $"Result: {result}";
		}

		public FSharpResult<string, string> MyWorkflow1()
		{
			var input = 123;
			var step1 = WorkflowStep1(input);
			var step2 = step1.Bind(s1 => WorkflowStep2(s1));
			var step3 = step2.Map(s2 => WorkflowStep3(s2));

			return step3;
		}
	}






	public static class FSharpResultExtensions
	{
		public static FSharpResult<TOk1, TError> Map<TOk, TError, TOk1>(this FSharpResult<TOk, TError> result,
			Func<TOk, TOk1> continuation)
		{
			if (result.IsError)
			{
				return FSharpResult<TOk1, TError>.NewError(result.ErrorValue);
			}
			else
			{
				return FSharpResult<TOk1, TError>.NewOk(continuation(result.ResultValue));
			}
		}

		public static FSharpResult<TOk1, TError> Bind<TOk, TError, TOk1>(this FSharpResult<TOk, TError> result,
			Func<TOk, FSharpResult<TOk1, TError>> continuation)
		{
			if (result.IsError)
			{
				return FSharpResult<TOk1, TError>.NewError(result.ErrorValue);
			}
			else
			{
				return continuation(result.ResultValue);
			}
		}
	}
}
