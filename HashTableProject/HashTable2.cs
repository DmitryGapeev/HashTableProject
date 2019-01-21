using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsDataStructures
{

	public class HashTable<T>
	{
		public int size;
		public int step;
		public T[] slots;

		private SlotStatus[] slotsStatus;

		private enum SlotStatus
		{
			Empty, Fill
		}

		private Func<T, int> hashFunction;

		public HashTable(int sz, int stp, List<Func<T, int>> hashFunctions):this(sz, stp)
		{
			Random rnd = new Random();
			int functionIndex = rnd.Next(0, hashFunctions.Count);
			hashFunction = hashFunctions[functionIndex];
		}

		public HashTable(int sz, int stp, Func<T, int> hashFunction) : this(sz, stp)
		{
			this.hashFunction = hashFunction;
		}

		private HashTable(int sz, int stp)
		{
			size = sz;
			step = stp;
			slots = new T[size];
			slotsStatus = new SlotStatus[size];

			for (int i = 0; i < size; i++)
				slotsStatus[i] = SlotStatus.Empty;
		}

		public int HashFun(T value)
		{
			return hashFunction(value);
		}

		public int SeekSlot(T value)
		{
			int position = HashFun(value);

			for (int i = 0; i < slotsStatus.Length; i++)
			{
				if (slotsStatus[position] == SlotStatus.Empty)
					return position;
				
				position += step;
				position %= slots.Length;
			}

			return -1;
		}

		public int Put(T value)
		{
			int position = SeekSlot(value);
			if (position != -1)
			{
				slots[position] = value;
				slotsStatus[position] = SlotStatus.Fill;
			}

			return position;
		}

		public int Find(T value)
		{
			int position = HashFun(value);

			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[position].Equals(value))
					return position;
				if(slotsStatus[position] == SlotStatus.Empty)
					break;

				position += step;
				position %= slots.Length;
			}
			return -1;
		}
	}

}