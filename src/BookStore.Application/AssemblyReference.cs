using System.Reflection;

namespace BookStore.Application
{
    public static class AssemblyReference
    {
        public static Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
