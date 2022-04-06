// # project 0: store application

// ## functionality
// * interactive console application ✓
// * place orders to store locations for customers
// * add a new customer  ✓
// * search customers by name 
// * display details of an order  ✓
// * display all order history of a store location 
//- string message = ("Transfer of " + quantity + storeInfo[x,y,0) + " from the DC to " + store);

// * display all order history of a customer  ✓
// * input validation  ✓
// * exception handling
// * persistent data (no prices, customers, order history, etc. hardcoded in C#)  ✓
// * (optional: order history can be sorted by earliest, latest, cheapest, most expensive, etc.)
// * (optional: get a suggested order for a customer based on his order history)
// * (optional: display some statistics based on order history)
// * (optional: asynchronous network & file I/O)

// ## design
// * don't use public fields
// * define and use at least one interface 
// * documentation with `<summary>` XML comments on all public types and members (optional: `<params>` and `<return>`)

// #### customer
// * has first name, last name, etc.  ✓
// * (optional: has a default store location to order from)

// #### order
// * has a store location  ✓
// * has a customer  ✓
// * has an order time (when the order was placed)
// * can contain multiple kinds of product in the same order  ✓
// * rejects orders with unreasonably high product quantities  ✓
// * (optional: some additional business rules, like special deals)

// #### location
// * has an inventory  ✓
// * inventory decreases when orders are accepted  ✓
// * rejects orders that cannot be fulfilled with remaining inventory  ✓
// * (optional: for at least one product, more than one inventory item decrements when ordering that product)

// ### test
// * at least 10 test methods
// * focus on unit testing business logic; testing the console-app-specific parts is low priority

// Due 4/6
// Should add git ignore.

//now that we have SQL, go from XML to SQL


using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using ShopAppTry3.Logic;
using System.Data.SqlClient;



namespace ShopAppTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<CustomerInfo> customerAccounts = new List<CustomerInfo>(); 
        public List<string> customerAccounts = new List<string>();
        //public XmlSerializer storeSerializer { get; } = new ( typeof( string[,,) );

        public XmlSerializer DCSerializer { get; } = new(typeof(string[]));
        public XmlSerializer storeSerializer { get; } = new(typeof(string[]));
        public XmlSerializer customerSerializer { get; } = new (typeof(List<string>));
        //public XmlSerializer customerSerializer { get; } = new(typeof(string));
        public MainWindow()
        {
            //string customerBlock = getXMLAsString(doc);
            //string[] customerList = customerBlock.Split('|');

            string[,] DCInfo = new string[10,2];
            
            InitializeComponent();
            TextBox[] DCtextBoxes = new TextBox[10] { DCInventory1, DCInventory2, DCInventory3, DCInventory4, DCInventory5, DCInventory6, DCInventory7, DCInventory8, DCInventory9, DCInventory10 };
            TextBox[] qtyBoxes = new TextBox[10] { Quantity10, Quantity1, Quantity2, Quantity3, Quantity4, Quantity5, Quantity6, Quantity7, Quantity8, Quantity9 };
            TextBox[] dcqtyBoxes = new TextBox[10] { DCQuantity10, DCQuantity1, DCQuantity2, DCQuantity3, DCQuantity4, DCQuantity5, DCQuantity6, DCQuantity7, DCQuantity8, DCQuantity9 };
            TextBox[] textBoxes = new TextBox[10] { Inventory10, Inventory1, Inventory2, Inventory3, Inventory4, Inventory5, Inventory6, Inventory7, Inventory8, Inventory9 };

            Random random = new Random();



            //around here I need to put the read from file for the DC inventory so its auto displayed.


            //Once I get the xml working, I need to put the first save function here, then delete it so future runs will have data to run from.

            string[] productName = returnInfo("PName"); //new read code block start
            string[] storeName = returnInfo("SName");
            string[] makers = returnInfo("Maker");
            string[] prices = returnInfo("Price");
            string[] quantity1 = returnInfo("Quantity1");
            string[] quantity2 = returnInfo("Quantity2");
            string[] quantity3 = returnInfo("Quantity3");
            string[] quantity4 = returnInfo("Quantity4");
            string[] quantity0 = returnInfo("Quantity0");
            //MessageBox.Show("Loaded? " + quantity0[1]);
            string[,] allQuantity = new string[5, 20];
            for (int j = 0; j < 20; j++)
            {
                allQuantity[1, j] = quantity1[j];
                allQuantity[2, j] = quantity2[j];
                allQuantity[3, j] = quantity3[j];
                allQuantity[4, j] = quantity4[j];
                allQuantity[0, j] = quantity0[j]; //read code block end
            }
            

            //Set all Account fields to read only and be empty.
            AccountNumberDisplay.Text = "";
            AccountNumberDisplay.IsReadOnly = true;
            AccountNumSearchField.Text = "";
            //AccountNumSearchField.IsReadOnly = true; Not needed, don't re add by accident.
            AccountFirstNameDisplay.Text = "";
            AccountFirstNameDisplay.IsReadOnly = true;
            AccountLastNameDisplay.Text = "";
            AccountLastNameDisplay.IsReadOnly = true;
            AccountAddress1.Text = "";
            AccountAddress1.IsReadOnly = true;
            AccountAddress2.Text = "";
            AccountAddress2.IsReadOnly = true;
            AccountStateDisplay.Text = "";
            AccountStateDisplay.IsReadOnly = true;
            AccountCityDisplay.Text = "";
            AccountCityDisplay.IsReadOnly = true;
            AccountZipDisplay.Text = "";
            AccountZipDisplay.IsReadOnly = true;
            AccountNumSearchField_Copy.Text = "";

            for (int i = 0; i < 10; i++)
            {
                int j = i;
                textBoxes[i].IsReadOnly = true;
                textBoxes[i].Text = "";
                DCtextBoxes[i].IsReadOnly = true;
                DCtextBoxes[i].Text = (productName[j] + " | " + makers[j] + " | " + allQuantity[0,j]);
                qtyBoxes[i].Text = "";
                dcqtyBoxes[i].Text = "";
            }
            



            AccountSaveButton.IsEnabled = false; //Should only show up when adding an account
            AccountSaveButton.Visibility = Visibility.Hidden;

            //StoreOrderButton.IsEnabled = false;
            //StoreOrderButton.Visibility = Visibility.Hidden;

            
        }
        //with SQL, i can probably rework these to work with that, since the input methods will be similar, though I have to go index by index which is inconvenient.
        public string[] fileReader(string location) //first reader
        {
            string[] temp = new string[10];

            //using (StreamReader reader = new(location))
            //{
            //    temp = (String[])DCSerializer.Deserialize(reader);
            //}
            return temp;
        }

        public List<string> fileCustomerReader(string location) //second reader
        {
            List<string> temp = new List<string>();
            using (StreamReader reader2 = new(location))
            {
                temp = (List<string>)customerSerializer.Deserialize(reader2);
            }
            if (String.IsNullOrEmpty(temp[0]))
            {
                temp.Add("Error");
            }

            return temp;
        }

        private void AccountSearchClick(object sender, RoutedEventArgs e) //searching for account by num
        {
            int accountNum;
            //string path = $"accounts.xml";
            //List<string> custAccounts = new List<string> { };
            //custAccounts = fileCustomerReader(path);

             //new read code block start
            

            if (String.IsNullOrEmpty(AccountNumSearchField.Text))
            { 
                MessageBox.Show("Please Enter a valid number");
            }
            else if (!int.TryParse(AccountNumSearchField.Text, out accountNum))
            {
                MessageBox.Show("Please Enter a valid number");
            }
            else
            {
                accountNum = int.Parse(AccountNumSearchField.Text);
                string result = custCheck(accountNum);
                if (String.IsNullOrEmpty(result))
                {
                    MessageBox.Show("That account number does not exist");
                }
                else
                {
                    //string thisCustomer = custAccounts[accountNum].ToString();
                    string[] custInfo = customerInfo(accountNum);

                    //string[] custDetails = thisCustomer.Split("|");
                    AccountNumberDisplay.Text = custInfo[0];
                    AccountFirstNameDisplay.Text = custInfo[1];
                    AccountLastNameDisplay.Text = custInfo[2];
                    AccountAddress1.Text = custInfo[3];
                    AccountAddress2.Text = custInfo[4];
                    AccountCityDisplay.Text = custInfo[5];
                    AccountStateDisplay.Text = custInfo[6];
                    AccountZipDisplay.Text = custInfo[7];
                }
                

            }
            //need check if account number exists.
        }

        private void CreateNewAccountClick(object sender, RoutedEventArgs e)
        {
            
            string[] temp = returnInfo("NewNum");
            int max = 1 + int.Parse(temp[0]);
            AccountNumberDisplay.Text = max.ToString(); 
            AccountNumberDisplay.Background = Brushes.White;
            AccountFirstNameDisplay.Text = "";
            AccountFirstNameDisplay.IsReadOnly = false;
            AccountFirstNameDisplay.Background = Brushes.White;
            AccountLastNameDisplay.Text = "";
            AccountLastNameDisplay.IsReadOnly = false;
            AccountLastNameDisplay.Background = Brushes.White;
            AccountAddress1.Text = "";
            AccountAddress1.IsReadOnly = false;
            AccountAddress1.Background = Brushes.White;
            AccountAddress2.Text = "";
            AccountAddress2.IsReadOnly = false;
            AccountAddress2.Background = Brushes.White;
            AccountStateDisplay.Text = "";
            AccountStateDisplay.IsReadOnly = false;
            AccountStateDisplay.Background = Brushes.White;
            AccountCityDisplay.Text = "";
            AccountCityDisplay.IsReadOnly = false;
            AccountCityDisplay.Background = Brushes.White;
            AccountZipDisplay.Text = "";
            AccountZipDisplay.IsReadOnly = false;
            AccountZipDisplay.Background = Brushes.White;
            AccountSaveButton.IsEnabled = true;
            AccountSaveButton.Visibility = Visibility.Visible;
        }

        private void AccountSaveButton_Click(object sender, RoutedEventArgs e)
        {
            string[] stateArray = { "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "MP", "OH", "OK", "OR", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "VI", "WA", "WV", "WI", "WY" };
            //put code to save account info here.
            //Need lots of validation of course.
            bool validState = true;
            string errors = "";
            string? address2 = AccountAddress2.Text;
            int errorCount = 0;

            if (String.IsNullOrEmpty(AccountFirstNameDisplay.Text))
            {
                errors += "You need to enter a First Name.\n";
                errorCount++;
            }
            if (AccountFirstNameDisplay.Text.Contains('|'))
            {
                errors += "One of your entries contains the invalid character: | \n Please remove.\n";
                errorCount++;
            }
            if (String.IsNullOrEmpty(AccountLastNameDisplay.Text))
            {
                errors += "You need to enter a Last Name.\n";
                errorCount++;
            }
            if (AccountLastNameDisplay.Text.Contains('|'))
            {
                errors += "One of your entries contains the invalid character: | \n Please remove.\n";
                errorCount++;
            }
            if (String.IsNullOrEmpty(AccountAddress1.Text))
            {
                errors += "You need to enter an address.\n";
                errorCount++;
            }
            if (AccountAddress1.Text.Contains('|'))
            {
                errors += "One of your entries contains the invalid character: | \n Please remove.\n";
                errorCount++;
            }
            if (String.IsNullOrEmpty(AccountAddress2.Text))
            {
                address2 = "-";
            }
            if (AccountAddress2.Text.Contains('|'))
            {
                errors += "One of your entries contains the invalid character: | \n Please remove.\n";
                errorCount++;
            }
            if (String.IsNullOrEmpty(AccountCityDisplay.Text))
            {
                errors += "You need to enter a city name.\n";
                errorCount++;
            }
            if (AccountCityDisplay.Text.Contains('|'))
            {
                errors += "One of your entries contains the invalid character: | \n Please remove.\n";
                errorCount++;
            }
            if (String.IsNullOrEmpty(AccountStateDisplay.Text))
            {
                errors += "You need to enter a state abbreviation.\n";
                errorCount++;
            }
            if (AccountStateDisplay.Text.Contains('|'))
            {
                errors += "One of your entries contains the invalid character: | \n Please remove.\n";
                errorCount++;
            }
            else
            {
                validState = stateArray.Contains((AccountStateDisplay.Text).ToUpper());
            }
            if (validState == false)
            {
                errors += "You did not enter a valid state abbreviation\n";
                errorCount++;
            }
            int zipNum;
            if (!int.TryParse(AccountZipDisplay.Text, out zipNum))
            {
                errors += "You need to enter a valid zip code\n";
                errorCount++;
            }
            if (AccountZipDisplay.Text.Contains('|'))
            {
                errors += "One of your entries contains the invalid character: | \n Please remove.\n";
                errorCount++;
            }
            if (errorCount == 0) 
            {
                
                string[] newData = {AccountNumberDisplay.Text, AccountFirstNameDisplay.Text, AccountLastNameDisplay.Text, AccountAddress1.Text, address2, AccountCityDisplay.Text, AccountStateDisplay.Text,AccountZipDisplay.Text };
                saveNewCustomer(newData);
                MessageBox.Show("Hey you saved the thing");
            }
            else
            {
                MessageBox.Show("Errors:\n " + errors);
            }
            //Late night thoughts on this: I can set the accounts into a 2d array or 2d list. [x][y]. X will be the account number, each Y will be a different column
            //one column per bit of data, so I can also post it. Need to add search function. I'll just have test account stuff be used for filling.
            //Also need error for searching out of range.
        }

        public XmlSerializer inventoryMoving { get; } = new(typeof(string[]));
        public XmlSerializer inventoryMoving2 { get; } = new(typeof(string[]));
        private void DC_Order_Button_Click(object sender, RoutedEventArgs e)
        {
            int errorCount = 0;
            TextBox[] textBoxes = new TextBox[10] { DCInventory1, DCInventory2, DCInventory3, DCInventory4, DCInventory5, DCInventory6, DCInventory7, DCInventory8, DCInventory9, DCInventory10 };
            TextBox[] qtyBoxes = new TextBox[10] { DCQuantity10, DCQuantity1, DCQuantity2, DCQuantity3, DCQuantity4, DCQuantity5, DCQuantity6, DCQuantity7, DCQuantity8, DCQuantity9 };
            string[,,] storeInfo = new string[4, 10, 2]; //perhaps I should try invert the arrangement of the dimensions, so instead of store -> product -> quantity, it becomes quantity -> product -> store
            string[,] DCInfo = new string[10, 2];
            string errors = "";
            string str = StoreSendSelector.Text;
            int storeNum = 0;
            string[] temp = new string[10];
            string path = $"dcInventory1.xml";
            string[] productName = new string[20];

            productName = returnInfo("PName"); //new read code block start
            string[] storeName = returnInfo("SName");
            string[] makers = returnInfo("Maker");
            string[] prices = returnInfo("Price");
            string[] quantity1 = returnInfo("Quantity1");
            string[] quantity2 = returnInfo("Quantity2");
            string[] quantity3 = returnInfo("Quantity3");
            string[] quantity4 = returnInfo("Quantity4");
            string[] quantity0 = returnInfo("Quantity0");

            string[,] allQuantity = new string[5, 20];
            for (int j = 0; j < 20; j++)
            {
                allQuantity[1, j] = quantity1[j];
                allQuantity[2, j] = quantity2[j];
                allQuantity[3, j] = quantity3[j];
                allQuantity[4, j] = quantity4[j];
                allQuantity[0, j] = quantity0[j]; //read code block end
            }


            if (!String.IsNullOrEmpty(str))  //what store is this sending to
            {
                if (str == "147th St (New York)")
                {
                    storeNum = 1;
                }
                else if (str == "Delancy St AKA Canal St (New York)")
                {
                    storeNum = 2;
                }
                else if (str == "95th St (New York)")
                {
                    storeNum = 3;
                }
                else if (str == "Cicero Ave (Chicago)")
                {
                    storeNum = 4;
                }
                else
                {
                    errors = (errors + "Something went wrong, invalid store somehow selected.\n");
                    errorCount++;
                } 
            }
            else
            {
                errors = (errors + "You must choose a store to send to\n");
                errorCount++;
            }



            for (int i = 0; i < 10; i++)
            {
                int quantity;
                if (!String.IsNullOrEmpty(qtyBoxes[i].Text))
                {
                    if (!int.TryParse(qtyBoxes[i].Text, out quantity)) //check for valid quantities
                    {
                        int j = i;
                        if (j == 0)
                        {
                            j = 10;
                        }
                        errors = (errors + "Invalid quantity for item: " + j + "\n");
                        errorCount++;
                    }
                    else
                    {
                        quantity = int.Parse(qtyBoxes[i].Text);
                        int dcQuantity = int.Parse(allQuantity[0,i]);
                        int j = i;
                        if (j == 0)
                        {
                            j = 10;
                        }
                        if (quantity > dcQuantity)
                        {
                            errors = (errors + "Quantiy for item: " + j + " exceeds DC quantity.\n");
                            errorCount++;
                        }
                    }

                }
            }
            if (errorCount == 0)
            {
                    //do ordering.
                string[] newStoreQuantity = new string[10];
                string[] newDCQuantity = new string[10];
                //string errorTracking = "";
                for (int i = 0; i < 10; i++)
                {
                    int quantity = 0;
                    int dcQuantity = 0;
                    int storeQuantity = 0;
                    if (!String.IsNullOrEmpty(qtyBoxes[i].Text))
                    {
                        MessageBox.Show("Starting amounts " + allQuantity[storeNum, i] + " in dc: " + allQuantity[0, i]);
                        quantity = int.Parse(qtyBoxes[i].Text);
                        dcQuantity = int.Parse(allQuantity[0, i]);
                        storeQuantity = int.Parse(allQuantity[storeNum,i]);
                        storeQuantity = storeQuantity + quantity;
                        dcQuantity = dcQuantity - quantity;
                        allQuantity[storeNum, i] = storeQuantity.ToString();
                        allQuantity[0, i] = dcQuantity.ToString();
                        saveQuantityChange(0,i,dcQuantity);
                        saveQuantityChange(storeNum, i, storeQuantity);
                        MessageBox.Show("End amounts: " + allQuantity[storeNum,i] + " dc: " + allQuantity[0,i]);
                    }
                }
                
                //path = put dc to store orders here.

                MessageBox.Show("Order entered. Inventories adjusted.\n ");
            }
            else
            {
                MessageBox.Show("Errors:\n " + errors);
            }

        }
        private void Store_Order_Button_Click(object sender, RoutedEventArgs e) //not removing properly, also need to make sure to refresh quantity boxes, and have success message.
        {
            TextBox[] qtyBoxes = new TextBox[10] {Quantity1, Quantity2, Quantity3, Quantity4, Quantity5, Quantity6, Quantity7, Quantity8, Quantity9, Quantity10 };
            //string[,,] storeInfo = new string[4, 10, 2]; 
            int errorCount = 0;
            int storeNum = 0;
            string str = StoreSelector.Text;
            int accountNum;
            string errors = "";
            string[] temp = new string[10];
            string path = $"dcInventory1.xml";
            string note = "";
            string[] productName = returnInfo("PName"); //new read code block start
            string[] storeName = returnInfo("SName");
            string[] makers = returnInfo("Maker");
            string[] prices = returnInfo("Price");
            string[] quantity1 = returnInfo("Quantity1");
            string[] quantity2 = returnInfo("Quantity2");
            string[] quantity3 = returnInfo("Quantity3");
            string[] quantity4 = returnInfo("Quantity4");
            string[] quantity0 = returnInfo("Quantity0");

            string[,] allQuantity = new string[5, 20];
            for (int j = 0; j < 20; j++)
            {
                allQuantity[1, j] = quantity1[j];
                allQuantity[2, j] = quantity2[j];
                allQuantity[3, j] = quantity3[j];
                allQuantity[4, j] = quantity4[j];
                allQuantity[0, j] = quantity0[j]; //read code block end
            }
            if (!String.IsNullOrEmpty(str))
            {
                if (str == "147th St (New York)")
                {
                    storeNum = 1;
                }
                else if (str == "Delancy St AKA Canal St (New York)")
                {
                    storeNum = 2;
                }
                else if (str == "95th St (New York)")
                {
                    storeNum = 3;
                }
                else if (str == "Cicero Ave (Chicago)")
                {
                    storeNum = 4;
                }
                else
                {
                    errors = (errors + "Something went wrong, invalid store somehow selected.\n");
                    errorCount++;
                }
            }
            else
            {
                errors = (errors + "You must choose a store to send from\n");
                errorCount++;
            }

            accountNum = int.Parse(AccountNumSearchField_Copy.Text);
            string result = custCheck(accountNum);

            if (String.IsNullOrEmpty(result))
            {
                errors = (errors + "That account number does not exist");
                errorCount++;
            }
            else if (String.IsNullOrEmpty(AccountNumSearchField_Copy.Text))
            {

                //need if statement to check account numbers.
                errors = (errors + "Please Enter a valid account number\n");
                errorCount++;
            }
            else if (!int.TryParse(AccountNumSearchField_Copy.Text, out accountNum))
            {
                errors = (errors + "Please Enter a valid account number\n");
                errorCount++;
            }
            for (int i = 0; i < 10; i++)
            {
                int quantity;
                if (!String.IsNullOrEmpty(qtyBoxes[i].Text))
                {
                    if (!int.TryParse(qtyBoxes[i].Text, out quantity))
                    {
                        int j = i;
                        if (j == 0)
                        {
                            j = 10;
                        }
                        errors = (errors + "Invalid quantity for item: " + j + "\n");
                        errorCount++;
                    }
                    else
                    { 
                        quantity = int.Parse(qtyBoxes[i].Text);
                        int storeQuantity = int.Parse(allQuantity[storeNum, i]);
                        int j = i;
                        if (j == 0)
                        {
                            j = 10;
                        }
                        if (quantity > storeQuantity)
                        {
                            errors = (errors + "Quantiy for item: " + j + " exceeds store quantity.\n");
                            errorCount++;
                        }

                    }

                }
            }
            if (errorCount == 0)
            {
                //do ordering.  still have to update to sql.
                int quantity = 0;
                int storeQuantity = 0;
                
                for (int i = 0; i < 10; i++)
                {
                    if (!String.IsNullOrEmpty(qtyBoxes[i].Text))
                    {
                        int j = i + 1;
                        quantity = int.Parse(qtyBoxes[i].Text);
                        storeQuantity = int.Parse(allQuantity[storeNum, i]);
                        storeQuantity = storeQuantity - quantity;
                        allQuantity[storeNum, i] = storeQuantity.ToString();
                        if (quantity > 0)
                        {
                            note = note + "Transfer of " + quantity + " " + productName[i] + " from " + storeName[storeNum] + " to customer. \n";
                        }
                        saveQuantityChange(storeNum, j, storeQuantity);
                    }
                }
                MessageBox.Show("Order Placed.");
                //record changes here


                string[] tempFix = new string[10];
                for (int i = 0; i < 10; i++)
                {
                    tempFix[i] = allQuantity[storeNum, i];
                }
                var newStringWriter = new StringWriter();
                inventoryMoving.Serialize(newStringWriter, tempFix);

                File.WriteAllText(path, newStringWriter.ToString());

                newStringWriter.Flush();
                accountNum = int.Parse(AccountNumSearchField_Copy.Text);
                path = "Account_" + accountNum + "_Records.txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                note = note + File.ReadAllText(path);
                File.WriteAllText(path, note);
                for (int i = 0; i < 10; i++)
                {
                    qtyBoxes[i].Text = "";
                }
                Store_Display_Button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                MessageBox.Show("Errors:\n " + errors);
            }

        }
            private void Display_Store_Button_Click(object sender, RoutedEventArgs e)
            {
            //< ComboBoxItem Content = "147th St (New York)" />
            //< ComboBoxItem Content = "Delancy St AKA Canal St (New York)" />
            //< ComboBoxItem Content = "95th St (New York)" />
            //< ComboBoxItem Content = "Cicero Ave (Chicago)" />
            string[] productName = returnInfo("PName"); //new read code block start
            string[] storeName = returnInfo("SName");
            string[] makers = returnInfo("Maker");
            string[] prices = returnInfo("Price");
            string[] quantity1 = returnInfo("Quantity1");
            string[] quantity2 = returnInfo("Quantity2");
            string[] quantity3 = returnInfo("Quantity3");
            string[] quantity4 = returnInfo("Quantity4");
            string[] quantity0 = returnInfo("Quantity0");

            string[,] allQuantity = new string[5, 20];
            for (int j = 0; j < 20; j++)
            {
                allQuantity[1, j] = quantity1[j];
                allQuantity[2, j] = quantity2[j];
                allQuantity[3, j] = quantity3[j];
                allQuantity[4, j] = quantity4[j];
                allQuantity[0, j] = quantity0[j]; //read code block end
            }
            TextBox[] textBoxes = new TextBox[10] {Inventory1, Inventory2, Inventory3, Inventory4, Inventory5, Inventory6, Inventory7, Inventory8, Inventory9, Inventory10 };
                string str = StoreSelector.Text;
                if (str == "147th St (New York)")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        textBoxes[i].Text = (productName[i] + " | " + makers[i] + " | " + allQuantity[1, i] + " | $" + prices[i]);
                    }
                }
                else if (str == "Delancy St AKA Canal St (New York)")
                {
                    for (int i = 0; i < 10; i++)
                    {
                    textBoxes[i].Text = (productName[i] + " | " + makers[i] + " | " + allQuantity[2, i] + " | $" + prices[i]);
                }
                }
                else if (str == "95th St (New York)")
                {
                    for (int i = 0; i < 10; i++)
                    {
                    textBoxes[i].Text = (productName[i] + " | " + makers[i] + " | " + allQuantity[3, i] + " | $" + prices[i]);
                }
                }
                else if (str == "Cicero Ave (Chicago)")
                {
                    for (int i = 0; i < 10; i++)
                    {
                    textBoxes[i].Text = (productName[i] + " | " + makers[i] + " | " + allQuantity[4, i] + " | $" + prices[i]);
                }
                }
                else
                {
                    MessageBox.Show("Please select a store.");
                }

            }


        private readonly string _connectionString = "Server=tcp:firsttryserver.database.windows.net,1433;Initial Catalog=FirstTryResourceGroupDatabase;Persist Security Info=False;User ID=Mechsrule1;Password=ed3MxmE23EKEsed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public void saveQuantityChange(int store, int itemNum, int newAmount)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            string index = ("Inventory.Item" + itemNum.ToString());
            
            if (store == 0)
            {
                store = 5;
            }
            connection.Open();
            using SqlCommand cmd = new SqlCommand("UPDATE " + index + " SET Quantity = " + newAmount.ToString() + " WHERE Store_ID = " + store.ToString(), connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void customerSaveInfo(string[] custInfo, string storeName, int quantity, string productName) //this is where I will put the account transactions.
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            string index = ("Customers.Record" + custInfo[0].ToString());

            using SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM " + index + " WHERE TABLE_SCEMA = 'Customers' AND TABLE_Name = 'Customers.Accounts') CREATE TABLE " + index + "(TransactionNumber INT PRIMARY KEY IDENTITY, Transaction NVARCAR(4000),)", connection);
            cmd.ExecuteNonQuery();
            using SqlCommand cmd2 = new SqlCommand("INSERT INTO " + index + " (Transaction) VALUES ('Transfer of " + quantity + " " + productName + " from " + storeName + " to the customer.')", connection);
            cmd2.ExecuteNonQuery();
        }
        public string[] customerInfo(int custNum) //customer reading lines
        {
            string[] infoGot = new string[8];
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand(
                    "SELECT CustomerID, FirstName, LastName, Address1, Address2, City, StateAbb, Zip FROM Customers.Accounts " +
                    "WHERE CustomerID = " + custNum, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                infoGot[0] = reader.GetInt32(0).ToString();
                infoGot[1] = reader.GetString(1);
                infoGot[2] = reader.GetString(2);
                infoGot[3] = reader.GetString(3);
                infoGot[4] = reader.GetString(4);
                infoGot[5] = reader.GetString(5);
                infoGot[6] = reader.GetString(6);
                infoGot[7] = reader.GetString(7);
            }
            return infoGot;
        }
        public void saveNewCustomer(string[] custData) //customer saving new account
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            //string index = ("Customer.Accounts");
            connection.Open();
            using SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Customers.Accounts (FirstName, LastName, Address1, Address2, City, StateAbb, Zip ) VALUES  ('" + custData[1].ToUpper() + "', '" + custData[2].ToUpper() + "', '" + custData[3].ToUpper() + "', '" + custData[4].ToUpper() + "', '" + custData[5].ToUpper() + "', '" + custData[6].ToUpper() + "', '" + custData[7].ToUpper() + "')", connection);
            //using SqlDataReader reader = cmd.ExecuteReader();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public string custCheck(int custNum)
        {
            string[] infoGot = new string[1];
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            using SqlCommand cmd = new SqlCommand(
                    "SELECT CustomerID FROM Customers.Accounts " +
                    "WHERE CustomerID = " + custNum, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                infoGot[0] = reader.GetInt32(0).ToString();
            }
            string num = infoGot[0];
            return num;
        }

        public string[] returnInfo(string? infoName)
        {
            string[] infoGot = new string[1];
            infoGot[0] = "Error";
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string[] storeNames = new string[4];
            string[] productNames = new string[20];
            string[] manufactorer = new string[20];
            string[] price = new string[20];
            string[] store1Quantities = new string[20];
            string[] store2Quantities = new string[20];
            string[] store3Quantities = new string[20];
            string[] store4Quantities = new string[20];
            string[] DCQuantities = new string[20];
            string[] custNum = new string[1];
            if (infoName == "SName")
            {
                for (int i = 0; i < 4; i++)
                {
                    using SqlCommand cmd = new SqlCommand(
                    "SELECT Name FROM Names.Stores " +
                    "WHERE Store_ID = " + i, connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        storeNames[i] = reader.GetString(0);
                    }
                }
                connection.Close();
                return storeNames;
            }
            else if (infoName == "PName")
            {
                for (int j = 0; j < 20; j++)
                {
                    int i = j + 1;
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT ProductName FROM Names.Product " +
                        "WHERE ProductNum = " + i, connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        productNames[j] = reader.GetString(0);
                    }
                }
                connection.Close();
                return productNames;
            }
            else if (infoName == "Maker")
            {
                for (int j = 0; j < 20; j++)
                {
                    int i = j + 1;
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT ProductMaker FROM Names.Product " +
                        "WHERE ProductNum = " + i, connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        manufactorer[j] = reader.GetString(0);
                    }
                }
                connection.Close();
                return manufactorer;
            }
            else if (infoName == "Price")
            {
                for (int j = 0; j < 20; j++) //reset to 20
                {
                    int i = j + 1;
                    string test = ("Inventory.Item" + i.ToString());
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT Price FROM " + test + " " +
                        "WHERE Store_ID = " + "1", connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        price[j] = (reader.GetSqlMoney(0).ToString());
                    }
                }
                connection.Close();
                return price;
            }
            else if (infoName == "Quantity0")
            {
                for (int j = 0; j < 20; j++)
                {
                    int i = j + 1;
                    string test = ("Inventory.Item" + i.ToString());
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT Quantity FROM " + test + " " +
                        "WHERE Store_ID = " + "5", connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DCQuantities[j] = (reader.GetInt32(0).ToString());
                    }
                }
                connection.Close();
                return DCQuantities;
            }
            else if (infoName == "Quantity1")
            {
                for (int j = 0; j < 20; j++)
                {
                    int i = j + 1;
                    string test = ("Inventory.Item" + i.ToString());
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT Quantity FROM " + test + " " +
                        "WHERE Store_ID = " + "1", connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        store1Quantities[j] = (reader.GetInt32(0).ToString());
                    }
                }
                connection.Close();
                return store1Quantities;
            }
            else if (infoName == "Quantity2")
            {
                for (int j = 0; j < 20; j++)
                {
                    int i = j + 1;
                    string test = ("Inventory.Item" + i.ToString());
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT Quantity FROM " + test + " " +
                        "WHERE Store_ID = " + "2", connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        store2Quantities[j] = (reader.GetInt32(0).ToString());
                    }
                }
                connection.Close();
                return store2Quantities;
            }
            else if (infoName == "Quantity3")
            {
                for (int j = 0; j < 20; j++)
                {
                    int i = j + 1;
                    string test = ("Inventory.Item" + i.ToString());
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT Quantity FROM " + test + " " +
                        "WHERE Store_ID = " + "3", connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        store3Quantities[j] = (reader.GetInt32(0).ToString());
                    }
                }
                connection.Close();
                return store3Quantities;
            }
            else if (infoName == "Quantity4")
            {
                for (int j = 0; j < 20; j++)
                {
                    int i = j + 1;
                    string test = ("Inventory.Item" + i.ToString());
                    using SqlCommand cmd = new SqlCommand(
                        "SELECT Quantity FROM " + test + " " +
                        "WHERE Store_ID = " + "4", connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        store4Quantities[j] = (reader.GetInt32(0).ToString());
                    }
                }
                connection.Close();
                return store4Quantities;
            }
            else if (infoName == "NewNum")
            {
                using SqlCommand cmd = new SqlCommand(
                       "SELECT COUNT (*) FROM Customers.Accounts", connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    custNum[0] = (reader.GetInt32(0).ToString());
                }
                return custNum;
            }

            connection.Close();

            return infoGot;
        }
    }

    }


namespace ShopAppTry3
{
    public static class Globals
    {

    }
    public class CustomerInfo
    {
        protected int accountNumber { get; set; }
        protected string? firstName { get; set; }
        protected string? lastName { get; set; }
        protected string? city { get; set; }
        protected string? state { get; set; }
        protected int? zip { get; set; }
        public XmlSerializer DCSerializer { get; } = new(typeof(string[]));
        public CustomerInfo() { }
        public CustomerInfo(int acNum, string Fname, string Lname, string city, string state, int zip)
        {
            this.accountNumber = acNum;
            this.firstName = Fname;
            this.lastName = Lname;
            this.city = city;
            this.state = state;
            this.zip = zip;

        }
        protected void Record(List<string> custAccountList)
        {
            string[] tempData = new string[10];
            var newStringWriter = new StringWriter();
            string[,] DCInfo = new string[1,1];
            
            for (int i = 0; i < 10; i++)
            {
                tempData[i] = DCInfo[i, 0];
            }

            string path = $"dcInventory1.xml";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            File.WriteAllText(path, newStringWriter.ToString());
            newStringWriter.Flush();
            for (int i = 0; i < 10; i++)
            {
                tempData[i] = DCInfo[i, 1];
            }

            //DCSerializer.Serialize(newStringWriter, tempData);

            path = $"dcInventory2.xml";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            File.WriteAllText(path, newStringWriter.ToString());
            newStringWriter.Close();
        }

    }
    
    public class Trying
    {

    }
}

//< Canvas x: Name = "Main_Menu" >
//</ Canvas >
//< Button Content = "Main Menu" Canvas.Left = "73" Canvas.Top = "85" Click = "Main_Menu_Button" HorizontalAlignment = "Center" VerticalAlignment = "Top" Name = "MainMenuButton" />
//< Button Content = "Customer Accounts" Canvas.Left = "73" Canvas.Top = "132" HorizontalAlignment = "Left" VerticalAlignment = "Top" Click = "Customer_Menu_Button" Name = "CustomMenuButton" />
//< Button Content = "Store Accounts" Canvas.Left = "73" Canvas.Top = "177" Click = "Store_Menu_Button" Name = "StoreMenuButton" />
//< Button Content = "Inventory" Canvas.Left = "73" Canvas.Top = "227" HorizontalAlignment = "Left" VerticalAlignment = "Top" Click = "Inventory_Button" Name = "InventoryButton" />
//for (int j = 0; j < 10; j++)
//{
//    DCInfo[j, 0] = productName[j];
//    DCInfo[j, 1] = random.Next(0, 1000).ToString();
//}
//for (int i = 0; i < 10; i++)
//{
//    DCtextBoxes[i].Text = (DCInfo[i, 0] + DCInfo[i, 1]);
//}
//

//}