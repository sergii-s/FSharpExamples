using System;
using System.Threading.Tasks;

namespace ExamplesCSharp
{

	public class GenericFunctions
	{
		public static K ExecuteFunc<T, K>(Func<T, K> func, T item)
		{
			return func(item);
		}

		public static void ExecuteAction<T>(Action<T> func, T item)
		{
			func(item);
		}

		public static T ExecuteGenericTask<T>(Task<T> task)
		{
			return task.Result;
		}

		public static void ExecuteTask(Task task)
		{
			//Another task implementation doesn't have Result
			//task.Result
		}
	}

	public class Exemple3
	{
		public static void Exemples()
		{
			Func<int, string> function = x => x.ToString();
			var res1 = GenericFunctions.ExecuteFunc(function, 10);

			Action<int> action = x => Console.WriteLine("bof");
			GenericFunctions.ExecuteAction(action, 10);
		}
	}

	// ----------------------------------

	public interface IMessageHandler<TMessage, TResult>
	{
		TResult Handle(TMessage message);
	}

	public interface IVoidMessageHandler<TMessage>
	{
		void Handle(TMessage message);
	}
}
