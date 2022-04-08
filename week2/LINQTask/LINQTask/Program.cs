using LINQTask.Data;
using System;
using System.Linq;

namespace LINQTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
           FilterService filterService = new FilterService();
           filterService.FilterOut();
        }
    }
}
