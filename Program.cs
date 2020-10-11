using System;
using System.Windows.Forms;

namespace OnlyUsChat
{
    internal static class Program
    {
        public static SelectModeForm Mode { get; private set; } = null;

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Mode = new SelectModeForm());
        }
    }
}