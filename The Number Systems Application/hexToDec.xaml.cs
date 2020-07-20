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

    public partial class hexToDec : Window
    {
        /**********************************************************************************
         * This is where the global variables used within this form are declared.
        **********************************************************************************/

        int intNum; // The global variable used to store the auto generated number value.     
        int intGuess; // The global variable used to store the users guess.     
        string strHex; //  The global variable used to store the converted to hex number value.

        public hexToDec()
        {
            InitializeComponent();
        }

        /**********************************************************************************
         * Once the start button is clicked the hex value will be produced by the system.
         * The Start button is disabled once clicked, and reenabled if answer is correct.
         * The system generates a random number between 0 and 4096, which is stored in gVar 'intNum'.
         * 'intNum' is converted to hexadecimal & string format and stored in gVar 'strHex'.
         * The data stored in 'strHex' is converted to upper case.
         * The data stored in the 'strHex' is displayed to the user in the 'txtHex' textbox.
        **********************************************************************************/

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false; // Start button is disabled once it has been clicked once.
            intNum = new Random().Next(0, 4096); // Number is generated between 0 and 4096.
            strHex = Convert.ToString(intNum, 16); // Number is converted to hex and string format.
            strHex = strHex.ToUpper(); // Sourced from: https://msdn.microsoft.com/en-us/library/ewdd6aed(v=vs.110).aspx
            txtHex.AppendText(strHex.PadLeft(4, '0') + "\n"); // Value is displayed to user. 
        }

        /**********************************************************************************
         * This method will accept the users value and compare with the generated value.
         * It will also inform the user if the answer is correct, too low or too high.
         * 'Try... Catch & Exception' is used to ensure only numeric values are accepted. 
        **********************************************************************************/

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                intGuess = int.Parse(txtGuess.Text); // Converts the value to a integer.

                /*********************************************************************
                 * Nested Control Structure using if statements to determine outcomes.
                 * Will either show correct answer, too high or too low message boxes.
                 * If correct the Start button is re-enables and all text boxes are cleared.
                 * If answer is too low or too high the guess text box will be cleared.
                 ********************************************************************/
                 
                if (intGuess == intNum) 
                {
                    MessageBox.Show("Congratulations, you have got the answer correct");
                    txtHex.Clear();
                    txtGuess.Clear();
                    btnStart.IsEnabled = true;
                }
                else
                { 
                    if (intGuess < intNum )
                    {
                        MessageBox.Show("The number you have entered is too low. Try again, please.");
                        txtGuess.Clear();
                    }
                    if (intGuess > intNum)
                    {
                        MessageBox.Show("The number you have entered is too high. Try again, please.");
                        txtGuess.Clear();
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Please enter a numeric value.");
                txtGuess.Clear();
            }
        }

        /**********************************************************************************
         * If the Exit to Main Page button is clicked, the user will get a prompt.
         * The prompt will ask the user if they're sure they'd like to exit to main page.
         * If 'YES' is clicked, the page will close and the main page is shown to the user.
         * Otherwise the page will stay open and the user can continue using as normal.
        **********************************************************************************/

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("Are you sure you want to return to the main page?", "Exit to Main Menu?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
