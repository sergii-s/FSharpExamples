using System;
using System.Threading.Tasks;

namespace ExamplesCSharp.Exemple4.E1
{
	public interface INode
	{
		void Print();
	}

	public class User : INode
	{
		public readonly string ClientId;
		public readonly string MachineId;

		public User(string clientId, string machineId)
		{
			ClientId = clientId;
			MachineId = machineId;
		}

		public void Print()
		{
			Console.WriteLine("User " + ClientId);
		}
	}

	public class Product : INode
	{
		public readonly string Url;
		public readonly int ProductId;

		public Product(string url, int productId)
		{
			Url = url;
			ProductId = productId;
		}

		public void Print()
		{
			Console.WriteLine("Product " + ProductId);
		}
	}

	public class Guest : INode
	{
		public readonly string MachineId;

		public Guest(string machineId)
		{
			MachineId = machineId;
		}

		public void Print()
		{
			Console.WriteLine("Guest " + MachineId);
		}
	}

	public class Exemple4
	{
		public static void PrintNode(INode node)
		{
			node.Print();
		}

		public static void HandleNode(INode node)
		{
			// business logic in entity, moche
			//Nodde.Handle(_service1, _service2)

			if (node is User)
			{
				var userNode = (User) node;
				// ...
			}
			else if (node is Product)
			{
				var productNode = (Product) node;
				// ...
			}
			else if (node is Guest)
			{
				var productNode = (Guest) node;
				// ...
			}

			// -> do not forget to add new cases
		}
	}
}

