using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_5_CST_150
{
    internal class InventoryManager
    {
        List<Product> inventoryList = new List<Product>();
        private int inventoryCount;

        public string showInventoryCount()
        {
            inventoryCount = inventoryList.Count;
            return inventoryCount.ToString();
        }

        public string showInventoryQuantity()
        {
            int totalQuantity = 0;
            int unitQuantity;
            foreach (Product i in inventoryList)
            {
                unitQuantity = i.Quantity;
                totalQuantity += unitQuantity;
            }
            return totalQuantity.ToString();
        }

        public string showInventoryTotalCost()
        {
            double totalCost = 0;
            double unitTotal;
            foreach (Product i in inventoryList)
            {
                unitTotal = i.TotalPrice;
                totalCost += unitTotal;
            }
            return totalCost.ToString();
        }

        // Add(Product product) - Add new product to list. 
        public void add(Product product)
        {
            inventoryList.Add(product);
        }

        // Sort Inventory 
        /* This method takes a parameter called choice. Its value is the zero-based index of the
         user's selection in the combobox. IEnumerable<Product> exposes the enumerator, which 
        supports the iteration over a collection of a specified type. We create a local
        variable called SortedList, which we assign the value of the sorted inventory list.
        Using OrderBy, we sort the elements in ascending order according to a specified key. How
        this list is sorted is determined by the user's choice.*/
        public string sortInventory(int choice)
        {
            // Initialize a new instance of the string builder class. 
            var sb = new StringBuilder();
            switch (choice)
            {
                // A - Z
                case 0:
                    IEnumerable<Product> sortedList = inventoryList.OrderBy(p => p.Name);
                    foreach (Product i in sortedList)
                    {
                        string str = i.ToString() + "\n";
                        border();
                        sb.Append(str + border());
                    }
                    return sb.ToString();

                // Least Expensive To Most Expensive  
                case 1:
                    IEnumerable<Product> sortedList2 = inventoryList.OrderBy(p => p.Price);
                    foreach (Product i in sortedList2)
                    {
                        string str = i.ToString() + "\n";
                        border();
                        sb.Append(str + border());
                    }
                    return sb.ToString();
                // Most Expensive To Least Expensive
                case 2:
                    IEnumerable<Product> sortedList3 = inventoryList.OrderBy(p => p.Price).Reverse();
                    foreach (Product i in sortedList3)
                    {
                        string str = i.ToString() + "\n";
                        border();
                        sb.Append(str + border());
                    }
                    return sb.ToString();

                case 3:
                    IEnumerable<Product> sortedList4 = inventoryList.OrderBy(p => p.Quantity);
                    foreach (Product i in sortedList4)
                    {
                        string str = i.ToString() + "\n";
                        border();
                        sb.Append(str + border());
                    }
                    return sb.ToString();

                case 4:
                    // Highest To Lowest Quantity 
                    IEnumerable<Product> sortedList5 = inventoryList.OrderBy(p => p.Quantity).Reverse();
                    foreach (Product i in sortedList5)
                    {
                        string str = i.ToString() + "\n";
                        border();
                        sb.Append(str + border());
                    }
                    return sb.ToString();

                // Default Case 
                default:
                    throw new Exception("No selection found!");
            }
        }

        // addProduct()
        /* Here we create a  new product and add the product to the list.*/
        public void addProduct(string name, double price, int quantity)
        {
            Product i = new Product(name, price, quantity);
            inventoryList.Add(i);
            MessageBox.Show("You added a product to your inventory.");
        }

        // Display a product 
        /* Here we utilize a string builder to create a new string.
         Our string is constructed of every item in our inventoryList.
         In addition to the items, a border is added at the end of every item.*/
        public string displayProducts()
        {
            var sb = new StringBuilder();
            foreach (Product i in inventoryList)
            {
                string str = i.ToString() + "\n";
                sb.Append(str + border());
            }
            return sb.ToString();

        }

        // Remove a product
        /* Here we use a for loop to scan the inventory. Then, we check whether the input
         is equal to the current product's name or not. If we find the product, we remove
        the product on that index. */
        public void removeProduct(string n)
        {
            int flag = 0;

            for (int i = 0; i < inventoryList.Count; i++)
            {
                if (inventoryList[i].Name.Equals(n))
                {
                    inventoryList.RemoveAt(i);
                    MessageBox.Show("Product removed");
                    flag = 1;
                }
            }

            if (flag == 0)
                MessageBox.Show("Product not found");

        }

        //Search by the name. 
        /* Here we use a for loop to scan the inventory. Then, we check whether the input
         is equal to the current product's name or not. If we find the product, we display
        the product on that index.*/
        public void searchProductByName(string queryName)
        {

            int flag = 0;

            foreach (Product i in inventoryList)
            {
                if (i.Name.Equals(queryName))
                {
                    MessageBox.Show(i.ToString());
                    flag = 1;
                }

            }

            if (flag == 0)
                MessageBox.Show("Product not found");

        }

        //Search by the price. 
        /* Here we use a for loop to scan the inventory. Then, we check whether the input
         is equal to the current product's price or not. If we find the product, we display
        the product on that index.*/
        public void searchProductByPrice(double queryPrice)
        {

            int flag = 0;

            foreach (Product i in inventoryList)
            {

                if (i.Price == queryPrice)
                {
                    MessageBox.Show(i.ToString());
                    flag = 1;
                }

            }

            if (flag == 0)
                MessageBox.Show("Product not found");

        }

        // Restock Product
        /* Here we use a for loop to scan the inventory. Then, we check whether the input
         is equal to the current product's name or not. If we find the product, we change
        that product's quantity on that index.*/
        public void restockProduct(string name, int quantity)
        {
            foreach (Product i in inventoryList)
            {
                if (i.Name.Equals(name))
                {
                    i.Quantity += quantity;
                    MessageBox.Show("You updated the quantity of this item!");
                }

            }

        }

        // Edit Product
        /* Here we iterate through the inventoryList. For each product item in the inventory list,
         if a product's name is equal to the editName, a warning will appear to the user. Using return,
        we stop the method and prevent the user from adding a duplicate product. If the user enters
        a proper name, the method will continue, and iterate through the inventoryList to find a product
        equal to the name the user enters. If a match is found, its details are changed to the details the
        user specifies.*/
        public void editProduct(string name, string editName, double editPrice, int editQuantity)
        {

            foreach (Product i in inventoryList)
            {
                if (i.Name == editName)
                {
                    MessageBox.Show("You cannot have two products of the same name!");
                    return;
                }
            }

            foreach (Product i in inventoryList)
            {
                if (i.Name.Equals(name))
                {
                    i.Name = editName;
                    i.Quantity = editQuantity;
                    i.Price = editPrice;
                    MessageBox.Show("You updated this item!");
                }
            }
        }

        // Border 
        /* This is a simple border used to divide products in the text box. It is only used by this class.*/
        private string border()
        {
            string border = "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -\n";
            return border;
        }

    }
}