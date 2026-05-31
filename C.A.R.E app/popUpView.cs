using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace C.A.R.E_app
{
    public partial class popUpView : Form
    {
        FirebaseClient client;

        public popUpView()
        {
            InitializeComponent();
            client = FirebaseService.Client;
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            picCamera.Image = null;
            try
            {
                await client.Child("AlertSystem").Child("isAlert").PutAsync(false);

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating cloud: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client.Child("AlertSystem")
                  .AsObservable<dynamic>()
                  .Subscribe(d => HandleAlertUpdate(d));

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void HandleAlertUpdate(dynamic data)
        {
            if (data != null && data.Object != null)
            {
                if (data.Key == "isAlert")
                {
                    if ((bool)data.Object == true)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.WindowState = FormWindowState.Normal;
                            this.ShowInTaskbar = true;
                            this.TopMost = true;

                            this.BackColor = Color.DarkRed;
                            lblStatus.Text = "Danger! \nPresence detected!";
                            lblStatus.ForeColor = Color.White;

                            lblStatus.Left = (this.ClientSize.Width - lblStatus.Width) / 2;
                        });
                    }
                }
                else if (data.Key == "imageUrl")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        string url = data.Object.ToString();
                        picCamera.LoadAsync(url);
                    });
                }
            }
        }
    }
}