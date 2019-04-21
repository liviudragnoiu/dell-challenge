using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            var operation = new ComplexOperation();
            int doOperationResult = operation.Do(1, 3);
            int doExtendedOperationResult = operation.DoExtended(1, 3, 5);

            Console.WriteLine(doOperationResult);
            Console.WriteLine(doExtendedOperationResult);
        }
    }

    public class Operation
    {
        public int Do(int a, int b)
        {
            return a + b;
        }
    }

    public class ComplexOperation : Operation
    {
        public int DoExtended(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
