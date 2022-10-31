using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_5_CST_150
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        // Image Atrribution: https://game-icons.net/1x1/delapouite/stack.html#download by Delapouite under CC BY 3.0

        // Create a new user
        User user = new User("demo", 343, 103);

        // Login Button 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text == user.getEmployeeID().ToString() && txtStoreID.Text == user.getStoreID().ToString() && txtPassword.Text == user.getPassword())
            {
                Dashboard form1 = new Dashboard(txtEmployeeID.Text, txtStoreID.Text);
                this.Hide();
                form1.Show();
            }
            else
            {
                MessageBox.Show("You entered the wrong employeeID, storeID, or password!");
            }
        }

        // Forgot Password (Hint) 
        private void btnHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a demo! Your password is 'demo', your employeeID is 343, and your storeID is 103.");
        }
    }
}

