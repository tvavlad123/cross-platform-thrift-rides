using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thrift.Protocol;
using Thrift.Transport;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var trasport = new TSocket("localhost", 8081);
            var binaryProtocol = new TBinaryProtocol(trasport);
            var turismServerProtocol = new TMultiplexedProtocol(binaryProtocol, nameof(ITransportServer.Iface));
            var server = new ITransportServer.Client(turismServerProtocol);
            try
            {
                trasport.Open();
                Application.Run(new Login(server));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            finally
            {
                trasport.Close();
            }
        }
    }
}
