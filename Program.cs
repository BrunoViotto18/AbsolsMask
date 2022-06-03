namespace AbsolsMask
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaLogin());
            //Application.Run(new Game(1));
        }
    }
}