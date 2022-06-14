using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData()
        {
            int count = System.IO.File.ReadAllLines("input.txt").Length;
            Student[] studs = new Student[count];
            StreamReader read = new StreamReader("input.txt");
            for (int i = 0; i < count; i++)
            {
                studs[i] = new Student(read.ReadLine());
            }
            return studs;
        }

        static void runMenu(Student[] studs)
        {
            double sum = 0;
            double average = 0;
            for (int i = 0; i < studs.Length; i++)
            {
                sum = 0;
                char[] arr ={studs[i].mathematicsMark,studs[i].physicsMark,studs[i].informaticsMark};
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == '-')
                    {
                        arr[j] = '2';
                    }
                    sum += (int)Char.GetNumericValue(arr[j]);
                }
                average = sum / arr.Length;
                if (average>4.5)
                {
                    Console.WriteLine($"{studs[i].surName} {studs[i].firstName} {studs[i].patronymic} {average}");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Результат виконання");
            runMenu(ReadData());
        }
    }
}
