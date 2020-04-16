using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

//Bryce Huston
//Programming II
//AT2 Final Project
//30003673
//13.06.19

namespace Virada_Games
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //product, customer and transaction files .dat
        string productFile = "product.dat";
        string customerFile = "customer.dat";
        string transactionFile = "transactions.dat";

        //List<T> for product, customer and transaction
        List<Product> productList = new List<Product>();

        List<Customers> customerList = new List<Customers>();

        List<Transactions> transactionList = new List<Transactions>();

        //Add button which calls upon DisplayProducts method which saves all data to a List<T> structure and displays ProductID and Description in the listbox
        private void btnProductsAdd_Click(object sender, EventArgs e)
        {
            //If text any of the text boxs are empty display error message
            if (String.IsNullOrEmpty(tbItemProductID.Text))
            {
                MessageBox.Show("Please enter a ProductID", "Error", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(tbItemDescription.Text))
            {
                MessageBox.Show("Please enter a description", "Error", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(tbItemStockQuantity.Text))
            {
                MessageBox.Show("Please enter Stock Quantity", "Error", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(tbItemRetailPrice.Text))
            {
                MessageBox.Show("Please enter Retail Price", "Error", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    if (!(tbGamesMediaType.Text == "" && tbGamesPublisher.Text == "") && (tbPlatformsModelNumber.Text == "" && tbAccessoriesPlatformType.Text == ""))
                    {
                        Games newGames = new Games();
                        newGames.setProductID(tbItemProductID.Text);
                        newGames.setDescription(tbItemDescription.Text);
                        newGames.setStockQuantity(int.Parse(tbItemStockQuantity.Text));
                        newGames.setRetailPrice(double.Parse(tbItemRetailPrice.Text));
                        newGames.setPublisher(tbGamesPublisher.Text);
                        newGames.setMediaType(tbGamesMediaType.Text);
                        productList.Add(newGames);
                    }

                    else if (!(tbPlatformsModelNumber.Text == "") && (tbGamesMediaType.Text == "" && tbGamesPublisher.Text == "" && tbAccessoriesPlatformType.Text == ""))
                    {
                        Platforms newPlatforms = new Platforms();
                        newPlatforms.setModelNumber(int.Parse(tbPlatformsModelNumber.Text));
                        newPlatforms.setProductID(tbItemProductID.Text);
                        newPlatforms.setDescription(tbItemDescription.Text);
                        newPlatforms.setStockQuantity(int.Parse(tbItemStockQuantity.Text));
                        newPlatforms.setRetailPrice(double.Parse(tbItemRetailPrice.Text));
                        productList.Add(newPlatforms);
                    }

                    else if (!(tbAccessoriesPlatformType.Text == "") && (tbGamesMediaType.Text == "" && tbGamesPublisher.Text == "" && tbPlatformsModelNumber.Text == ""))
                    {
                        Accessories newAccessories = new Accessories();
                        newAccessories.setProductID(tbItemProductID.Text);
                        newAccessories.setDescription(tbItemDescription.Text);
                        newAccessories.setStockQuantity(int.Parse(tbItemStockQuantity.Text));
                        newAccessories.setRetailPrice(double.Parse(tbItemRetailPrice.Text));
                        newAccessories.setPlatformType(tbAccessoriesPlatformType.Text);
                        productList.Add(newAccessories);
                    }

                    else
                    {
                        MessageBox.Show("To Much Information", "Error", MessageBoxButtons.OK);
                    }
                }

                //If any of the text boxes are the wrong variable type display error message
                catch
                {
                    MessageBox.Show("Incompatible Variable Type", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DisplayProducts();
                Clear();
            }
        }

        //Method to display Products in ListBox
        public void DisplayProducts()
        {
            lstProductsOutput.Items.Clear();

            foreach (Product p in productList)
            {
                lstProductsOutput.Items.Add(p.ToString());
            }
        }

        //Method that clears all text boxes
        public void Clear()
        {
            tbItemProductID.Clear();
            tbItemDescription.Clear();
            tbItemStockQuantity.Clear();
            tbItemRetailPrice.Clear();
            tbGamesPublisher.Clear();
            tbGamesMediaType.Clear();
            tbPlatformsModelNumber.Clear();
            tbAccessoriesPlatformType.Clear();
            tbCustomerInfoCustID.Clear();
            tbCustomerInfoFamilyName.Clear();
            tbCustomerInfoFirstName.Clear();
            tbCustomerInfoEmail.Clear();
            tbTransactionInfoCustID.Clear();
            tbTransactionInfoProductID.Clear();
            tbTransactionInfoQuantity.Clear();
            tbTransactionInfoRetailPrice.Clear();
            tbTransactionInfoDate.Clear();
        }

        //Add button which calls upon DisplayCustomers method which saves all data to a List<T> structure and displays CustID, Family Name and First Name in the listbox
        private void btnCustomersAdd_Click(object sender, EventArgs e)
        {
            //If text any of the text boxs are empty display error message
            if (string.IsNullOrEmpty(tbCustomerInfoCustID.Text))
            {
                DialogResult result = MessageBox.Show("Generate a default customer?", "Default", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Customers newCustomers = new Customers();
                    newCustomers.setCustID("C000");
                    newCustomers.setFamilyName("unknown");
                    newCustomers.setFirstName("unknown");
                    newCustomers.setEmailAddress("unknown");
                    customerList.Add(newCustomers);
                    DisplayCustomers();
                }
                else
                {
                    //Nothing
                }
            }
            else if (string.IsNullOrEmpty(tbCustomerInfoFamilyName.Text))
            {
                MessageBox.Show("Please enter Family Name", "Error", MessageBoxButtons.YesNo);
            }
            else if (string.IsNullOrEmpty(tbCustomerInfoFirstName.Text))
            {
                MessageBox.Show("Please enter First Name", "Error", MessageBoxButtons.YesNo);
            }
            else if (string.IsNullOrEmpty(tbCustomerInfoEmail.Text))
            {
                MessageBox.Show("Please enter Email", "Error", MessageBoxButtons.YesNo);
            }
            else
            {
                Customers newCustomers = new Customers();
                newCustomers.setCustID(tbCustomerInfoCustID.Text);
                newCustomers.setFamilyName(tbCustomerInfoFamilyName.Text);
                newCustomers.setFirstName(tbCustomerInfoFirstName.Text);
                newCustomers.setEmailAddress(tbCustomerInfoEmail.Text);

                customerList.Add(newCustomers);
                DisplayCustomers();
                Clear();
            }
        }

        //Method to display Customers in ListBox
        public void DisplayCustomers()
        {
            lstCustomersOutput.Items.Clear();

            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i] != null)
                {
                    lstCustomersOutput.Items.Add(customerList[i]);
                }
            }
        }

        //Save Methods for Product, Customers and Transactions
        public void SaveProducts(string filename)
        {
            try
            {
                using (Stream fileStream = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter serializer = new BinaryFormatter();

                    serializer.Serialize(fileStream, productList);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex, "Exception Throw", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveCustomers(string filename)
        {
            try
            {
                using (Stream fileStream = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter serializer = new BinaryFormatter();

                    serializer.Serialize(fileStream, customerList);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex, "Exception Throw", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveTransactions(string filename)
        {
            try
            {
                using (Stream fileStream = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter serializer = new BinaryFormatter();

                    serializer.Serialize(fileStream, transactionList);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex, "Exception Throw", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Load Methods for Product, Customers and Transactions
        public void OpenProducts(string filename)
        {
            try
            {
                using (Stream fileStream = File.OpenRead(filename))
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    productList = (List<Product>)deserializer.Deserialize(fileStream);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex, "Exception Throw", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenCustomers(string filename)
        {
            try
            {
                using (Stream fileStream = File.OpenRead(filename))
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    customerList = (List<Customers>)deserializer.Deserialize(fileStream);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex, "Exception Throw", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenTransactions(string filename)
        {
            try
            {
                using (Stream fileStream = File.OpenRead(filename))
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    transactionList = (List<Transactions>)deserializer.Deserialize(fileStream);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex, "Exception Throw", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Add button which calls upon DisplayTransactions method which saves all data to a List<T> structure and displays CustID, ProductID, Quantity, Retail Price and Date in the listbox
        private void btnTransactionsAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbTransactionInfoQuantity.Text))
            {
                MessageBox.Show("Please enter quantity", "Error", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(tbTransactionInfoDate.Text))
            {
                MessageBox.Show("Please enter a date", "Error", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    Transactions newTransactions = new Transactions();
                    newTransactions.setCustID(tbTransactionInfoCustID.Text);
                    newTransactions.setProductID(tbTransactionInfoProductID.Text);
                    newTransactions.setQuantity(int.Parse(tbTransactionInfoQuantity.Text));
                    newTransactions.setRetailPrice(double.Parse(tbTransactionInfoRetailPrice.Text));
                    newTransactions.setDate(tbTransactionInfoDate.Text);
                    transactionList.Add(newTransactions);
                }
                catch
                {
                    MessageBox.Show("Incompatible Variable Type", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DisplayTransactions();
            }
        }

        //Method to display Transactions in ListBox
        public void DisplayTransactions()
        {
            lstTransactionsOutput.Items.Clear();

            for (int i = 0; i < transactionList.Count; i++)
            {
                if (transactionList[i] != null)
                {
                    lstTransactionsOutput.Items.Add(transactionList[i]);
                }
            }
        }

        //When a item in the Product ListBox is selected the proper text boxes are filled
        private void lstProductsOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstProductsOutput.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            // Select item from Output box
            Games game;
            Platforms platform;
            Accessories accessorie;

            if (productList[index] is Games)
            {
                ClearProducts();
                game = (Games)productList[index];
                tbItemProductID.Text = game.getProductID().ToString();
                tbTransactionInfoProductID.Text = game.getProductID().ToString();
                tbItemDescription.Text = game.getDescription();
                tbItemStockQuantity.Text = game.getStockQuantity().ToString();
                tbItemRetailPrice.Text = game.getRetailPrice().ToString();
                tbTransactionInfoRetailPrice.Text = game.getRetailPrice().ToString();
                tbGamesPublisher.Text = game.getPublisher();
                tbGamesMediaType.Text = game.getMediaType();
            }

            else if (productList[index] is Platforms)
            {
                ClearProducts();
                platform = (Platforms)productList[index];
                tbItemProductID.Text = productList[index].getProductID().ToString();
                tbTransactionInfoProductID.Text = productList[index].getProductID().ToString();
                tbItemDescription.Text = productList[index].getDescription();
                tbItemStockQuantity.Text = productList[index].getStockQuantity().ToString();
                tbItemRetailPrice.Text = productList[index].getRetailPrice().ToString();
                tbTransactionInfoRetailPrice.Text = platform.getRetailPrice().ToString();
                tbPlatformsModelNumber.Text = platform.getModelNumber().ToString();
            }

            else if (productList[index] is Accessories)
            {
                ClearProducts();
                accessorie = (Accessories)productList[index];
                tbItemProductID.Text = productList[index].getProductID().ToString();
                tbTransactionInfoProductID.Text = productList[index].getProductID().ToString();
                tbItemDescription.Text = productList[index].getDescription();
                tbItemStockQuantity.Text = productList[index].getStockQuantity().ToString();
                tbItemRetailPrice.Text = productList[index].getRetailPrice().ToString();
                tbAccessoriesPlatformType.Text = accessorie.getPlatformType();
                tbTransactionInfoRetailPrice.Text = accessorie.getRetailPrice().ToString();
            }

        }

        //When a item in the Customer ListBox is selected the proper text boxes are filled
        private void lstCustomersOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstCustomersOutput.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("Please select item");
                return;
            }
            tbCustomerInfoCustID.Text = customerList[index].getCustID();
            tbTransactionInfoCustID.Text = customerList[index].getCustID();
            tbCustomerInfoFamilyName.Text = customerList[index].getFamilyName();
            tbCustomerInfoFirstName.Text = customerList[index].getFirstName();
            tbCustomerInfoEmail.Text = customerList[index].getEmailAddress();
        }



        //Clear method to just clear text boxes associated with product
        public void ClearProducts()
        {
            tbItemProductID.Clear();
            tbItemDescription.Clear();
            tbItemStockQuantity.Clear();
            tbItemRetailPrice.Clear();
            tbGamesPublisher.Clear();
            tbGamesMediaType.Clear();
            tbPlatformsModelNumber.Clear();
            tbAccessoriesPlatformType.Clear();
        }

        //When ProductID text box is double clicked it will clear all products
        private void tbItemProductID_DoubleClick(object sender, EventArgs e)
        {
            ClearProducts();
        }

        //When CustId text box  is click it will text boxs associated with Customer
        private void tbCustomerInfoCustID_DoubleClick(object sender, EventArgs e)
        {
            ClearCustomers();
        }

        //Method to clear all Customer Text Boxs
        private void ClearCustomers()
        {
            tbCustomerInfoCustID.Clear();
            tbCustomerInfoFamilyName.Clear();
            tbCustomerInfoFirstName.Clear();
            tbCustomerInfoEmail.Clear();
        }

        //When a item in the Transaction ListBox is selected the proper text boxes are filled and both the appropiate records from the Products and Customer ListBoxs are selected
        private void LstTransactionsOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstTransactionsOutput.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("Please select item");
                return;
            }

            tbTransactionInfoCustID.Text = transactionList[index].getCustID();
            tbTransactionInfoProductID.Text = transactionList[index].getProductID().ToString();
            tbTransactionInfoQuantity.Text = transactionList[index].getQuantity().ToString();
            tbTransactionInfoRetailPrice.Text = transactionList[index].getRetailPrice().ToString();
            tbTransactionInfoDate.Text = transactionList[index].getDate();

            tbCustomerInfoCustID.Text = customerList[index].getCustID();
            tbCustomerInfoFamilyName.Text = customerList[index].getFamilyName();
            tbCustomerInfoFirstName.Text = customerList[index].getFirstName();
            tbCustomerInfoEmail.Text = customerList[index].getEmailAddress();

            Games game;
            Platforms platform;
            Accessories accessorie;

            if (productList[index] is Games)
            {
                ClearProducts();
                game = (Games)productList[index];
                tbItemProductID.Text = game.getProductID().ToString();
                tbTransactionInfoProductID.Text = game.getProductID().ToString();
                tbItemDescription.Text = game.getDescription();
                tbItemStockQuantity.Text = game.getStockQuantity().ToString();
                tbItemRetailPrice.Text = game.getRetailPrice().ToString();
                tbGamesPublisher.Text = game.getPublisher();
                tbGamesMediaType.Text = game.getMediaType();
            }

            else if (productList[index] is Platforms)
            {
                ClearProducts();
                platform = (Platforms)productList[index];
                tbItemProductID.Text = productList[index].getProductID().ToString();
                tbTransactionInfoProductID.Text = productList[index].getProductID().ToString();
                tbItemDescription.Text = productList[index].getDescription();
                tbItemStockQuantity.Text = productList[index].getStockQuantity().ToString();
                tbItemRetailPrice.Text = productList[index].getRetailPrice().ToString();
                tbPlatformsModelNumber.Text = platform.getModelNumber().ToString();
            }

            else if (productList[index] is Accessories)
            {
                ClearProducts();
                accessorie = (Accessories)productList[index];
                tbItemProductID.Text = productList[index].getProductID().ToString();
                tbTransactionInfoProductID.Text = productList[index].getProductID().ToString();
                tbItemDescription.Text = productList[index].getDescription();
                tbItemStockQuantity.Text = productList[index].getStockQuantity().ToString();
                tbItemRetailPrice.Text = productList[index].getRetailPrice().ToString();
                tbAccessoriesPlatformType.Text = accessorie.getPlatformType();
            }

            //Selects Product Record
            lstProductsOutput.SelectedIndex = index;
            lstProductsOutput.Focus();

            //Selects Customer Record
            lstCustomersOutput.SelectedIndex = index;
            lstCustomersOutput.Focus();

        }

        //Loads .dat files
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {

                //If product file exists then open and display products
                if (File.Exists(productFile))
                {
                    OpenProducts(productFile);
                    DisplayProducts();
                }

                else
                {
                    MessageBox.Show(productFile + " Does Not Exist", "Error", MessageBoxButtons.OK);
                }

                //If customer file exists then open and dispay customers
                if (File.Exists(customerFile))
                {
                    OpenCustomers(customerFile);
                    DisplayCustomers();
                }

                else
                {
                    MessageBox.Show(customerFile + " Does Not Exist", "Error", MessageBoxButtons.OK);
                }

                //if transaction file exists open and display transactions
                if (File.Exists(transactionFile))
                {
                    OpenTransactions(transactionFile);
                    DisplayTransactions();
                }

                else
                {
                    MessageBox.Show(transactionFile + " Does Not Exist", "Error", MessageBoxButtons.OK);
                }

            }
            catch (IOException x)
            {
                MessageBox.Show("Exeption: " + x, "Exception Throw", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Saves Products, Customer and Transactions to .dat file
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Saving product to product file when form closes
            SaveProducts(productFile);

            //Saving customer to customer file when form closes
            SaveCustomers(customerFile);

            //Saving transactions to transaction file when form closes
            SaveTransactions(transactionFile);
        }
    }
}
