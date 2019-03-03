using System;
using System.Threading.Tasks;

namespace ExamplesCSharp.Exemple4.E2
{
	public class Node
	{
	}

	public class User : Node
	{
		public readonly string ClientId;
		public readonly string MachineId;

		public User(string clientId, string machineId)
		{
			ClientId = clientId;
			MachineId = machineId;
		}
	}

	public class Product : Node
	{
		public readonly string Url;
		public readonly int ProductId;

		public Product(string url, int productId)
		{
			Url = url;
			ProductId = productId;
		}
	}

	public class Guest : Node
	{
		public readonly string MachineId;

		public Guest(string machineId)
		{
			MachineId = machineId;
		}
	}

	public class Exemple4
	{
		public static void PrintNode(Node node)
		{
			switch (node)
			{
				case User u:
				{
					Console.WriteLine("User");
					return;
				}
				case Product g:
				{
					Console.WriteLine("Product");
					return;
				}
				case Guest g:
				{
					Console.WriteLine("Guest");
					return;
				}
				// -> do not forget to add new cases
			}
		}

		public static void HandleNode(Node node)
		{
			// Ok now
		}

		public static void HandleIdentity(Node node)
		{
			switch (node)
			{
				case User u:
				{
					Console.WriteLine("User");
					return;
				}
				case Product g:
				{
					// ..... 
					throw new Exception("Identity is User or Product !!!");
				}
				case Guest g:
				{
					Console.WriteLine("Guest");
					return;
				}

				/* New case for identity : CookilessUser 
				case CookilessUser g:
				{
					Console.WriteLine("CookilessUser");
					return;
				}
				*/
			}
		}
	}
}
