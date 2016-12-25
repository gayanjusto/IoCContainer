using IoCContainer.IoC;

namespace IoCContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.Register<ITest, Test>(IoCLifeCycle.Singleton);

            var testeImp = container.GetImplementation<ITest>();
        }
    }

    public interface ITest
    {

    }

    public class Test : ITest
    {
        public int Nome { get; set; }
        public int Idade { get; set; }

    }
}
