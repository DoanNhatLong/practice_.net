
namespace CS01
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<int> numbers = new List<int> { 5, 12, 6, 7, 9, 11 };
            Func<int, bool> isEven = n =>n %2 ==0;
            foreach(var number in numbers){
                bool res=isEven(number);
                if (res)
                {
                    Console.WriteLine(number);
                }
            }     
        }
    }
}
