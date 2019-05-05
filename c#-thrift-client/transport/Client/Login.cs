using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transport.Controller;

namespace Client
{
    public partial class Login : Form
    {
        private readonly ClientController _controller;
        public Login(ITransportServer.Iface server)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _controller = new ClientController(server);
            this.FormClosing += (a, b) => Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                int port = random.Next(1025, 65535);
                if (_controller.Login(usernameTextBox.Text, passwordTextBox.Text, port))
                {
                    var mainWindow = new TransportWindow(_controller, port);
                    Hide();
                    mainWindow.FormClosed += (a, b) => Show();
                    mainWindow.Show();
                }
                else
                    MessageBox.Show(@"Invalid username/password", @"Login Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                usernameTextBox.Clear();
                passwordTextBox.Clear();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, @"Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
