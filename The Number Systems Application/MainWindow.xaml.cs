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
using System.Windows.Navigation;
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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /**********************************************************************************
         * The purpose of this method is to link this button to the Binary Quiz form.
         * Upon clicking on the button the user will be directed to another form.
         * The home page form will close when this button is clicked.
        **********************************************************************************/

        private void btnBinaryQuiz_Click(object sender, RoutedEventArgs e)
        {
            binToDec binaryToDec = new binToDec();
            binaryToDec.Owner = this;
            this.Hide();
            binaryToDec.Show();
        }

        /**********************************************************************************
         * The purpose of this method is to link this button to the Hexadecimal Quiz form.
         * Upon clicking on the button the user will be directed to another form.
         * The home page form will close when this button is clicked.
        **********************************************************************************/

        private void btnHexQuiz_Click(object sender, RoutedEventArgs e)
        {
            hexToDec hexadecimalToDec = new hexToDec();
            hexadecimalToDec.Owner = this;
            this.Hide();
            hexadecimalToDec.Show();
        }

        /**********************************************************************************
         * The purpose of this method is to link this button to the Binary Conversion Tool form.
         * Upon clicking on the button the user will be directed to another form.
         * The home page form will close when this button is clicked.
        **********************************************************************************/

        private void btnBinaryConversion_Click(object sender, RoutedEventArgs e)
        {
            binConversion binaryConversion = new binConversion();
            binaryConversion.Owner = this;
            this.Hide();
            binaryConversion.Show();
        }

        /**********************************************************************************
         * The purpose of this method is to link this button to the Hexadecimal Conversion Tool form.
         * Upon clicking on the button the user will be directed to another form.
         * The home page form will close when this button is clicked.
        **********************************************************************************/

        private void btnHexConversion_Click(object sender, RoutedEventArgs e)
        {
            hexConversion hexadecimalConversion = new hexConversion();
            hexadecimalConversion.Owner = this;
            this.Hide();
            hexadecimalConversion.Show();
        }

        /**********************************************************************************
         * The purpose of this method is to close the main window and the application when clicked.
         * A message box will ask the user if they're sure they'd like to exit the application.
         * If 'YES' is clicked the application will close, otherwise it will remain open.
        **********************************************************************************/

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("Are you sure you want to exit the application?", "Exit the Application?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
