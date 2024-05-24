using System;
using System.Windows.Forms;

namespace Pet_Haven
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        int startPoint = 0;

        // Event handler for form load event
        private void SplashForm_Load(object sender, EventArgs e)
        {
            timer1.Start(); // Starts the timer for the progress bar animation
        }

        // Click event handler for a label (currently unused)
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            // Placeholder for any actions on label click
        }

        // Event handler for the timer tick event
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 2; // Increment progress value
            guna2ProgressBar1.Value = startPoint; // Update progress bar value

            // Check if progress bar reaches maximum value
            if (guna2ProgressBar1.Value == 100)
            {
                guna2ProgressBar1.Value = 0; // Reset progress bar
                timer1.Stop(); // Stop the timer

                // Hide the splash form and show the login form
                this.Hide();
                LoginForm login = new LoginForm();
                login.ShowDialog();
            }
        }

        // Event handler for progress bar value changed event (currently unused)
        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {
            // Placeholder for any actions on progress bar value change
        }

        // Event handler for progress bar value changed event (currently unused)
        private void guna2ProgressBar1_ValueChanged_1(object sender, EventArgs e)
        {
            // Placeholder for any actions on progress bar value change
        }

        // Event handler for progress bar value changed event (currently unused)
        private void guna2ProgressBar1_ValueChanged_2(object sender, EventArgs e)
        {
            // Placeholder for any actions on progress bar value change
        }
    }
}
