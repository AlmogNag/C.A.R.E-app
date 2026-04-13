using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System;   
namespace C.A.R.E_app
{
    public partial class Form1 : Form
    {
        FirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The system has been successfully reset.");

            this.BackColor = SystemColors.Control;
            lblStatus.Text = "System Standby - Monitoring...";
            lblStatus.ForeColor = Color.Black;

            picCamera.Image = null;

            try
            {
                await client.Child("AlertSystem").Child("isAlert").PutAsync(false);

                MessageBox.Show("Alert acknowledged. History log preserved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating cloud: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FirebaseClient("https://care-c0bdb-default-rtdb.europe-west1.firebasedatabase.app/");
            
            client.Child("AlertSystem")
          .AsObservable<dynamic>()
          .Subscribe(d => HandleAlertUpdate(d));
        }

        private void HandleAlertUpdate(dynamic data)
        {
            Console.WriteLine("Update received! Key: " + data.Key + " Value: " + data.Object);

            if (data != null && data.Object != null)
            {
                if (data.Key == "isAlert")
                {
                    if ((bool)data.Object == true)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.BackColor = Color.DarkRed;
                            lblStatus.Text = "Danger! Presence Detected!";
                            lblStatus.ForeColor = Color.White;
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
