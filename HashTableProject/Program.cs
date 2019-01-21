using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			TestHashTable();
			Console.ReadKey();
		}

		static void TestHashTable()
		{
			Console.WriteLine("test hash table");
			HashTable hashTable = new HashTable(11, 2);
			char s = 'a';
			for(int i = 0; i < 10; i++, s++)
				hashTable.Put(new string(s, 10));
			
			foreach (string item in hashTable.slots)
				Console.WriteLine(item + " ");

			Console.WriteLine();
			Console.WriteLine("put z string");
			hashTable.Put(new string('z', 10));

			foreach (string item in hashTable.slots)
				Console.WriteLine(item + " ");

			Console.WriteLine();
			Console.WriteLine("try to put 'end'");
			int position = hashTable.Put("end");
			Console.WriteLine("result position = " + position);

			Console.WriteLine("find values test");
			s = 'a';
			for (int i = 0; i < 10; i++, s++)
			{
				string value = new string(s, 10);
				position = hashTable.Find(value);
				Console.WriteLine("position = " + position + ", value = "+value);
			}
				

			Console.WriteLine(new string('=', 50));
		}
	}
}
