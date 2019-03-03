using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamplesCSharp
{
	public class User
	{
		public string Name { get; }
		public string Email { get; }
		public int Age { get; }

		public User(string name, string email, int age)
		{
			Name = name;
			Email = email;
			Age = age;
		}

		protected bool Equals(User other)
		{
			return string.Equals(Name, other.Name) && string.Equals(Email, other.Email) && Age == other.Age;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((User) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Name != null ? Name.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Age;
				return hashCode;
			}
		}

		public static bool operator ==(User left, User right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(User left, User right)
		{
			return !Equals(left, right);
		}
	}

	public class Example1
	{
		public static void Example()
		{
			var users = new List<User>
			{
				new User("Adam", "adam@gmail.com", 18),
				new User("Koko", "Koko@gmail.com", 20),
				new User("Adam", "adam@gmail.com", 18)
			};
			var distinctUsers = users.Distinct();
		}
	}


}
