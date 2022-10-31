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
    public partial class Dashboard : Form
    {
        InventoryManager inventory = new InventoryManager();
        public Dashboard(string storeID, string employeeID)
        {
            InitializeComponent();
            txtDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
            txtStoreID.Text = storeID;
            txtEmployeeID.Text = employeeID;

            // Create Products
            Product White_Bread = new Product("White Bread", 3.99, 50);
            Product Wheat_Bread = new Product("Wheat Bread", 3.99, 50);
            Product Rye_Bread = new Product("Rye Bread", 6.99, 60);
            Product Sourdough_Bread = new Product("Sourdough Bread", 6.99, 28);
            Product Multigrain_Bread = new Product("Multigrain Bread", 5.99, 40);
            Product Pita_Bread = new Product("Pita Bread", 4.99, 50);
            Product Brioche = new Product("Brioche", 4.99, 34);
            Product Bagels = new Product("Bagels", 5.99, 53);
            Product Focaccia = new Product("Focaccia", 6.99, 23);
            Product Ciabatta = new Product("Ciabatta", 4.99, 32);

            // Add Products To Inventory
            inventory.add(White_Bread);
            inventory.add(Wheat_Bread);
            inventory.add(Rye_Bread);
            inventory.add(Sourdough_Bread);
            inventory.add(Multigrain_Bread);
            inventory.add(Pita_Bread);
            inventory.add(Brioche);
            inventory.add(Bagels);
            inventory.add(Focaccia);
            inventory.add(Ciabatta);

            // Display 
            txtDisplay.Text = inventory.displayProducts();
            refreshInventory();

        }


        // Add New Item 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name;
            double price;
            int quantity;
            try
            {
                name = txtNewName.Text;
                price = (Convert.ToDouble(txtNewPrice.Text));
                quantity = (Convert.ToInt32(txtNewQuantity.Text));
                inventory.addProduct(name, price, quantity);
                refreshInventory();
                txtDisplay.Text = inventory.displayProducts();
            }
            catch
            {
                MessageBox.Show("Please enter a valid name, quantity, and unit price!");
            }
        }

        // Clear The Interface
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEditPrice.Clear();
            txtEditChoice.Clear();
            txtEditQuantity.Clear();
            txtEditName.Clear();
            txtSearchByName.Clear();
            txtSearchByPrice.Clear();
            txtRestockName.Clear();
            txtRestockNum.Clear();
            txtDelete.Clear();
            txtNewName.Clear();
            txtNewQuantity.Clear();
            txtNewPrice.Clear();
            txtSearchByName.Focus();
        }


        // Search By Price
        private void btnSearchByPrice_Click(object sender, EventArgs e)
        {
            double queryPrice;
            try
            {
                if (txtSearchByPrice.Text != "")
                {
                    queryPrice = (Convert.ToDouble(txtSearchByPrice.Text));
                    inventory.searchProductByPrice(queryPrice);
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid price!");
            }
        }

        // SearchByName 
        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            string queryName;
            if (txtSearchByName.Text != "")
            {
                queryName = txtSearchByName.Text.ToString();
                inventory.searchProductByName(queryName);
            }
            else
            {
                MessageBox.Show("Please enter a valid name!");
            }
        }

        // Restock
        private void btnRestock_Click(object sender, EventArgs e)
        {
            string name;
            int quantity;
            try
            {
                name = txtRestockName.Text;
                quantity = Convert.ToInt32(txtRestockNum.Text);
                inventory.restockProduct(name, quantity);
                refreshInventory();
                txtDisplay.Text = inventory.displayProducts();
            }
            catch
            {
                MessageBox.Show("Please enter a valid number and name!");
            }
        }

        // Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name;
            name = txtDelete.Text;
            inventory.removeProduct(name);
            refreshInventory();
            txtDisplay.Text = inventory.displayProducts();
        }

        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Refresh
        private void refreshInventory()
        {
            txtTotalCount.Text = inventory.showInventoryCount();
            txtTotalQuantity.Text = inventory.showInventoryQuantity();
            txtTotalCost.Text = inventory.showInventoryTotalCost();
        }


        // Sort Inventory 
        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDisplay.Text = inventory.sortInventory(cboSort.SelectedIndex);
        }

        // Edit Product 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name;
            string editName;
            int editQuantity;
            double editPrice;
            try
            {
                name = txtEditChoice.Text;
                editName = txtEditName.Text;
                editQuantity = Convert.ToInt32(txtEditQuantity.Text);
                editPrice = Convert.ToDouble(txtEditPrice.Text);
                inventory.editProduct(name, editName, editPrice, editQuantity);
                refreshInventory();
                txtDisplay.Text = inventory.displayProducts();
            }
            catch
            {
                MessageBox.Show("Please enter a valid name, price, and quantity!");
            }
        }

        // Logout 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtDate.Clear();
            txtStoreID.Clear();
            Login form2 = new Login(); 
            this.Hide();
            form2.Show();
        }
    }
}


