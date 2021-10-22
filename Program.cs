using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Algorithm
{
	class Program
	{
		public Program()
		{
			Console.CursorVisible = false;
			Console.WriteLine("Array properties:\n1. random\n2. static");
			switch (Console.ReadLine())
			{
				case "1":
					{
						SetArray(int.Parse(Input("Array size:")));
						RandomArrayCreate();
						break;
					}
				case "2":
					{
						StaticArrayCreate();
						break;
					}
				default:
					{
						Console.WriteLine("Input error");
						break;
					}
			}
		}
		private ulong Arraychecks = 0;
		private ulong Arrayaccesses = 0;
		private int[] Array { get; set; }
		static void Main()
		{
			while(true)
			{
				Program sort = new Program();
				sort.Output($"unsorted:", sort.Array, 0);
				sort.ArrayBubbleSort();
				Console.CursorTop = 5;
				sort.Output("sorted:", sort.Array, 20);
				Console.CursorTop = 0;
				sort.Output($"Array accesses = {sort.Arrayaccesses}; Array checks = {sort.Arraychecks}", null, 20);
				sort.Arrayaccesses = 0;
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
				//File.AppendAllText("randomarray.txt", $"{Array[i]}, ");
			}
		}
		internal void StaticArrayCreate()
		{
				Array = new int[] 
				{ 
					31, 1, 78, 38, 19, 26, 75, 46, 12, 57,
					76, 69, 66, 35, 70, 22, 42, 33, 74, 58,
					87, 95, 78, 9, 88, 68, 41, 94, 66, 58, 
					69, 92, 37, 28, 78, 91, 91, 37, 67, 19,
					44, 39, 70, 57, 46, 82, 59, 43, 7, 46, 
					38, 70, 70, 29, 4, 35, 23, 69, 49, 51,
					84, 81, 79, 53, 87, 84, 33, 38, 56, 78,
					31, 6, 66, 56, 14, 49, 25, 21, 62, 7, 
					9, 98, 87, 21, 21, 99, 22, 9, 24, 44,
					68, 22, 87, 17, 34, 63, 59, 18, 70, 62 
				};
		}
		internal void ArrayBubbleSort()
		{
			int jumpindex;
			for(int j = 0; j < Array.GetLength(0) - 1; j++)
			{
				Arraychecks++;
				jumpindex = j;
				while(Array[j] > Array[j + 1])
				{
					int _ = Array[j];
					Array[j] = Array[j + 1];
					Array[j + 1] = _;
					Arrayaccesses++;
					if(j == 0)
					{
						break;
					}
					else
					{
						j--;
					}
				}
				j = jumpindex;
			}
		}
	}
}
