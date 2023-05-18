using System;

namespace HelloWorldApplication
{
    /* 类名为 HelloWorld */
    class HelloWorld
    {
        /* main函数 */
        static void Main(string[] args)
        {
            DateTime startTime = new DateTime(1970, 1, 1); // 当地时区
            long nStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数            
            System.Diagnostics.Debug.WriteLine(nStamp);
            Console.WriteLine(nStamp);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}