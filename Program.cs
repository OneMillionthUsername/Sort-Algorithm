using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm
{
	class Program
	{
		private int ArrayWrites;
		private int[] Array { get; set; }
		static void Main()
		{
			Program sort = new Program();
			while(true)
			{
				Console.CursorVisible = true;
				sort.SetArray(int.Parse(sort.Input("Array size:")));
				sort.RandomArrayCreate();
				sort.Output($"unsorted:", sort.Array, 0);
				sort.ArraySort();
				Console.CursorTop = 1;
				sort.Output("sorted:", sort.Array, 20);
				Console.CursorTop = 0;
				sort.Output($"Array writes = {sort.ArrayWrites}", null, 20);
				sort.ArrayWrites = 0;
				Console.CursorVisible = false;
				Console.ReadKey();
				Console.Clear();
			}
		}
		public string Input(string label)
		{
			string result;
			Console.Write(label + " ");
			result = Console.ReadLine();
			return result;
		}
		public void Output(string label, int[] nums, int cleft)
		{
			Console.CursorLeft = cleft;
			Console.WriteLine(label);
			if(nums != null)
			{
				foreach(int element in nums)
				{
					Console.CursorLeft = cleft;
					Console.WriteLine($"{element}");
				}
			}
		}
		internal void SetArray(int length)
		{
			Array = new int[length];
		}
		internal void RandomArrayCreate()
		{
			Random n = new Random();
			for(int i = 0; i < Array.GetLength(0); i++)
			{
				Array.SetValue(n.Next(1, (int)Array.GetLength(0)), i);
			}
		}
		internal void ArraySort()
		{
			for(int j = 0; j < Array.GetLength(0) - 1; j++)
			{
				while(Array[j] > Array[j + 1])
				{
					int _ = Array[j];
					Array[j] = Array[j + 1];
					Array[j + 1] = _;
					ArrayWrites++;
					if(j == 0)
					{
						break;
					}
					else
					{
						j--;
					}
				}
			}
		}
	}
}
