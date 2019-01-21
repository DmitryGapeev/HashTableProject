using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructures
{

	public class HashTable
	{
		public int size;
		public int step;
		public string[] slots;

		public HashTable(int sz, int stp)
		{
			size = sz;
			step = stp;
			slots = new string[size];
			for (int i = 0; i < size; i++) slots[i] = null;
		}

		public int HashFun(string value)
		{
			int sumBytes = 0;
			byte[] valuesBytes = Encoding.UTF8.GetBytes(value);

			foreach (byte item in valuesBytes)
				sumBytes += item;

			return sumBytes % slots.Length;
		}

		public int SeekSlot(string value)
		{
			int position = HashFun(value);
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[position] == null)
					return position;

				position += step;
				position %= slots.Length;
			}

			return -1;
		}

		public int Put(string value)
		{
			int position = SeekSlot(value);
			if (position != -1)
				slots[position] = value;

			return position;
		}

		public int Find(string value)
		{
			int position = HashFun(value);
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[position] == value)
					return position;

				position += step;
				position %= slots.Length;
			}
			return -1;
		}
	}

}