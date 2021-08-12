using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generics make your code Type independent
            //Generics are introduced in C# 2.0. Generics allow us to design classes and methods decoupled from the data types.
            //Generic classes are extensively used by collection classes available in System.Collections.Generic namespace.

            //Example 1
            // bool Equal = Calculator.AreEqual(1, 2);
            //It's a compile time error to invoke AreEqual() method with string parameters since AreEqual() method is tightly coupled with int data type.
            //bool Equal = Calculator.AreEqual("A", "B");

            //In this example, AreEqual(int value1, int value2) only works with int data type.If, we pass any other data type, we get a compiler error.
            //So, AreEqual() method in Calculator class is tightly coupled with the int data type, and prevents it from being used with any other data type.

            //Example 2
            //One way of making AreEqual() method reusable, is to use object type parameters.
            //Since, every type in .NET directly or indirectly inherit from System.Object type, AreEqual() method works with any data type, but the problem is performance degradation due to boxing and unboxing happening. 
            //Also, AreEuqal() method is no longer type safe. It is now possible to pass integer for the first parameter, and a string for the second parameter.
            //It doesn't really make sense to compare strings with integers.
            //bool Equal = Calculator.AreEqual("A", "B");

            //So, the probem with using System.Object type is that
            //1.AreEqual() method is not type safe
            //2.Performance degradation due to boxing and unboxing.

            //Both of these issues can be solved with generics and still make AreEqual() method work with different data types.
            //To make AreEqual() method generic, we specify a type parameter using angular brackets as shown below.
            //public static bool AreEqual<T>(T value1, T value2)
            //At the point, When the client code wants to invoke this method, they need to specify the type, they want the method to operate on.
            //If the user wants the AreEqual() method to work with integers, they can invoke the method specifying int as the datatype using angular brackets as shown below.
            //bool Equal = Calculator.AreEqual<int>(10, 10);
            //To operate with string data type
            //bool Equal = Calculator.AreEqual<string>("A", "B");

            //We can also make class as Generic
            bool Equal = Calculator<int>.AreEqual(10, 12);
            if (Equal)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }

            Console.ReadLine();

        }
    }

    //<T>: Type of element

    public class Calculator<T>
    {
        //Example 1 related code
        //public static bool AreEqual(int value1, int value2)

        //Example 2 related code
        //public static bool AreEqual(object value1, object value2)
        //Generics code for AreEqual() method
        //public static bool AreEqual<T>(T value1, T value2)
        //Generics code for Calculator class
        public static bool AreEqual(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }
}
