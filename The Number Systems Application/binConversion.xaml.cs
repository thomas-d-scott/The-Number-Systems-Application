using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace The_Number_Systems_Application
{
    /****************************************************************************************
     * Program Name: "Number Systems Application"
     * Developer: Thomas Scott
     * Date: 20/07/2020
     * Description: The purpose of this program is to allow students to do various tasks 
     * such as convert decimal values to binary and hex format.
     * As well as this the user can get asked hex and binary questions to convert into decimal.
     ***************************************************************************************/

    public partial class binConversion : Window
    {
        public binConversion()
        {
            InitializeComponent();
        }

        /*
         * This function will take the users value and convert it into binary format, then display it to the user.
         * After the binary value is displayed to the user they will have the option to enter another value
         * The boxes will be cleared if they say 'yes' to entering a new number. If they say 'no' the user is returned to the main page.
        */
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            //Clears the text box once the convert button has been clicked.
            txttBinary.Clear();
            try
            {
                //Declares and initiates the number value, and converts it to a integer from the text box.
                int number = Convert.ToInt32(txtDecimal.Text);
                //Converts the number into a string again after converting value into a binary value.
                string strBinary = Convert.ToString(number, 2);
                txttBinary.AppendText(strBinary.PadLeft(8, '0') + "\n");
            }

            catch (Exception)
            {
                //Error message pops up if user inputs a character instead of a numeric value.
                MessageBox.Show("Must be a numeric value");
            }
        }

        /*
         * This function allows the user to leave the page and return to the home page.
         * A message box asking for user confirmation is shown.
         * If user confirms they'd like to leave, then they will be returned to home page and this form will close.
        */
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            //Gives user option to close the program.
            result = MessageBox.Show("Are you sure you want to return to the main page?", "Exit to Main Menu?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                //Closes this page.
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //This event will show the main page when this page is closed.
            this.Owner.Show();
        }
    }
}
