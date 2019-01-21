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
			TestHashFunctions();
			//TestHashTable();
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

		static void TestHashFunctions()
		{

			int tableSize = 50;
			int[] values = new int[tableSize];
			Random rnd = new Random();

			for (int i = 0; i < tableSize; i++)
			{
				int newValue = rnd.Next(0, 5000);
				values[i] = newValue;
				Console.Write(newValue+" ");
			}
				

			List<Func<int, int>> hashFunctions = new List<Func<int, int>>
			{
				x => ((7 * x + 5) % 17) % tableSize,
				x => ((3 * x + 1) % 13) % tableSize,
				x => ((17 * x + 13) % 31) % tableSize
			};

			HashTable<int> hashTable = new HashTable<int>(tableSize, 3, hashFunctions[0]);

			Console.WriteLine(Environment.NewLine + "test put values" + Environment.NewLine);

			for (int i = 0; i <values.Length / 2; i++)
				hashTable.Put(values[i]);

			foreach (var t in hashTable.slots)
				Console.Write(t+" ");

			Console.WriteLine();
			Console.WriteLine(Environment.NewLine + "test put values" + Environment.NewLine);
			hashTable = new HashTable<int>(tableSize, 3, hashFunctions[1]);

			for (int i = 0; i < values.Length / 2; i++)
				hashTable.Put(values[i]);

			foreach (var t in hashTable.slots)
				Console.Write(t + " ");

			Console.WriteLine();
			Console.WriteLine(Environment.NewLine + "test put values" + Environment.NewLine);
			hashTable = new HashTable<int>(tableSize, 3, hashFunctions[2]);

			for (int i = 0; i < values.Length / 2; i++)
				hashTable.Put(values[i]);

			foreach (var t in hashTable.slots)
				Console.Write(t + " ");

			Console.WriteLine();
			Console.WriteLine(new string('=', 50));
		}
	}
}
