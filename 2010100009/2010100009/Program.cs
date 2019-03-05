using System;
using System.Threading;
using System.Threading.Tasks;

namespace _2010100009
{
    class Program
    {
        static void Main(string[] args)
        {
            Student mertKayaguc = new Student("1", "Mahmut Mert Kayagüç", "Mahmut M.", "Kayagüç", "2010100009", "mertkayaguc@gmail.com");
            mertKayaguc = mertKayaguc.Edit("1", "Mahmut Mert Kayagüç", "Mahmut M.", "Kayagüç", "2010100009", "mertkayaguc@hotmail.com");

            Print(mertKayaguc);            

            var starTime = DateTime.Now;
            Calculate1();
            Calculate2();
            Calculate3();
            var sure = DateTime.Now - starTime;
            Console.WriteLine("Toplam ms:" + sure.TotalSeconds);

            Calculator().GetAwaiter().GetResult();

        }
        public static async Task Calculator()
        {
            var starTime2 = DateTime.Now;

            Task Calc1 = Calculate1Async();
            Task Calc2 = Calculate2Async();
            Task<int> Calc3 = Calculate3Async();

            await Calc1;
            await Calc2;
            await Calc3;
            /*
            await Calculate1Async();
            await Calculate2Async();
            await Calculate3Async();
            
            var sure2=DateTime.Now-starTime2;
            Console.WriteLine("Toplam ms:" + sure2.TotalSeconds);
*/
        }

        public static void Print(Student student)
        {
            Console.WriteLine($" Tam Adı :{student.FullName}");
            Console.WriteLine($" Adı :{student.Name}");
            Console.WriteLine($" Soyadı :{student.Surname}");
            Console.WriteLine($" Email :{student.Email}");
            Console.WriteLine($" Okul Numarası :{student.StudentId}");
            Console.WriteLine($" GPA : {student.CalculateGPA()} Meznuniyet : {student.CanGradute()}");
        }

        public static void Calculate1()
        {
            Console.WriteLine("Calculate 1 Start " + DateTime.Now.ToLongTimeString());
            Thread.Sleep(2000);
            Console.WriteLine("Calculate 1 End " + DateTime.Now.ToLongTimeString());
        }

        public static void Calculate2()
        {
            Console.WriteLine("Calculate 2 Start " + DateTime.Now.ToLongTimeString());
            Thread.Sleep(3000);
            Console.WriteLine("Calculate 2 End " + DateTime.Now.ToLongTimeString());

        }

        public static int Calculate3()
        {
            Console.WriteLine("Calculate 3 Start " + DateTime.Now.ToLongTimeString());

            Thread.Sleep(1000);
            Console.WriteLine("Calculate 3 End " + DateTime.Now.ToLongTimeString());

            return 3;
        }

        public static async Task Calculate1Async()
        {
            Console.WriteLine("Calculate 1 Start " + DateTime.Now.ToLongTimeString());

            await Task.Delay(2000);
            Console.WriteLine("Calculate 1 End " + DateTime.Now.ToLongTimeString());

        }

        public static async Task Calculate2Async()
        {
            Console.WriteLine("Calculate 2 Start " + DateTime.Now.ToLongTimeString());
            await Task.Delay(3000);
            Console.WriteLine("Calculate 2 End " + DateTime.Now.ToLongTimeString());
        }


        public static async Task<int> Calculate3Async()
        {
            Console.WriteLine("Calculate 3 Start " + DateTime.Now.ToLongTimeString());
            await Task.Delay(1000);
            Console.WriteLine("Calculate 3 End " + DateTime.Now.ToLongTimeString());
            return 3;
        }


    }
}