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

    public partial class binToDec : Window
    {
        /**
         *The Global Variables that will be used throughout this form. 
        **/
        int intNum;        //to store auto generated number.
        int intGuess;      //to store guess
        string strBinary; //To store Binary value.

        public binToDec()
        {
            InitializeComponent();
        }

        /*
         * This function will start the quiz by first disabling the start button once it has been clicked.
         * A random number will then be generated, then converted into binary format.
         * The binary value will be displayed in the text box. 
        */
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            //code for creating a random number
            //between 0 and 100
            intNum = new Random().Next(0, 255);
            //Converts the number into a string again after converting value into a binary value.
            strBinary = Convert.ToString(intNum, 2);
            txtBinary.AppendText(strBinary.PadLeft(8, '0') + "\n");
        }

        /*
         * The user inputs their answer into the text box which is passed into the program and it's coverted into an integer.
         * A nested control structure is used within a try, catch. 
         * This nested control is used to determine if the user inputed answer is the same as the actual decimal value generated.
         * Message box will appear whether the answer is correct or wrong, informing the user.
         * If the answer is correct the binary and answer text boxes are cleared, and the start button is reactivated.
         * The catch is used to stop the user from inputing values other than numbers.
         * A message box appears and the text box is cleared if the value entered is not valid.
        */
        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Retrieve the guess from the text box and converts to an integer value.
                intGuess = int.Parse(txtGuess.Text);

                //If statement to check if the value entered is the same as the generated number.
                if (intGuess == intNum)
                {
                    /*
                     * Message box shown if answer is correct.
                     * Text boxes that stores the binary value and users answer are cleared.
                     * The start button is reactivated.
                     */
                    MessageBox.Show("Congratulations, you have got the answer correct");
                    txtBinary.Clear();
                    txtGuess.Clear();
                    btnStart.IsEnabled = true;
                }
                else
                {
                    //Displays a message box with the message dependant on whether the answer is above or below users guess.
                    if (intGuess < intNum)
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
                //If a non numeric value is entered, a message box is displayed and the answer box is cleared.
                MessageBox.Show("Please enter a numeric value.");
                txtGuess.Clear();
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
