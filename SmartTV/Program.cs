using System.Windows.Forms;

namespace LgTvController
{
    static class Program
    {
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RemoteControl());
        }
    }
}
