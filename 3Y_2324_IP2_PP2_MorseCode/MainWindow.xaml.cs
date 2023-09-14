using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace _3Y_2324_IP2_PP2_MorseCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileManager fm = new FileManager();

        public MainWindow()
        {
            InitializeComponent();
            //Console.Beep(9000, 10000);

            btnDoTheThing.Content = "Read";
        }

        private void chkbWriteMode_Checked(object sender, RoutedEventArgs e)
        {
            btnDoTheThing.Content = "Write";
            tbFilePath.Text = "";
            tbMessage.Text = "";
        }

        private void chkbWriteMode_Unchecked(object sender, RoutedEventArgs e)
        {
            btnDoTheThing.Content = "Read";
            tbFilePath.Text = "";
            tbMessage.Text = "";
        }

        private void btnDoTheThing_Click(object sender, RoutedEventArgs e)
        {
            if((bool)chkbWriteMode.IsChecked) 
            { 
                fm.writeFile(tbFilePath.Text, messageToMorse(tbMessage.Text.ToUpper()));
            }
            else
            {
                if(fm.fileCheck(tbFilePath.Text)) 
                { 
                    morseRead(fm.readFile(tbFilePath.Text));
                }
                else
                {
                    MessageBox.Show("File being read is invalid/locked. Please double check.");
                }
            }
        }

        private void morseRead(List<string> lines)
        {
            foreach(string line in lines) 
            {
                if(line.Length > 0)
                {
                    foreach (char l in line)
                    {
                        switch (l)
                        {
                            case '.':
                                Console.Beep(3000, 100);
                                break;
                            case '-':
                                Console.Beep(3000, 300);
                                break;
                        }
                    }
                    Thread.Sleep(200);
                    tbMessage.Text += morseToLetter(line);
                }
                else
                {
                    Thread.Sleep(300);
                    tbMessage.Text += " ";
                }
            }
        }

        private char morseToLetter(string morseString)
        {
            char letter = ' ';

            switch(morseString)
            {
                case ".-":
                    letter = 'A';
                    break;
                case "-...":
                    letter = 'B';
                    break;
                case "-.-.":
                    letter = 'C';
                    break;
                case "-..":
                    letter = 'D';
                    break;
                case ".":
                    letter = 'E';
                    break;
                case "..-.":
                    letter = 'F';
                    break;
                case "--.":
                    letter = 'G';
                    break;
                case "....":
                    letter = 'H';
                    break;
                case "..":
                    letter = 'I';
                    break;
                case ".---":
                    letter = 'J';
                    break;
                case "-.-":
                    letter = 'K';
                    break;
                case ".-..":
                    letter = 'L';
                    break;
                case "--":
                    letter = 'M';
                    break;
                case "-.":
                    letter = 'N';
                    break;
                case "---":
                    letter = 'O';
                    break;
                case ".--.":
                    letter = 'P';
                    break;
                case "--.-":
                    letter = 'Q';
                    break;
                case ".-.":
                    letter = 'R';
                    break;
                case "...":
                    letter = 'S';
                    break;
                case "-":
                    letter = 'T';
                    break;
                case "..-":
                    letter = 'U';
                    break;
                case "...-":
                    letter = 'V';
                    break;
                case ".--":
                    letter = 'W';
                    break;
                case "-..-":
                    letter = 'X';
                    break;
                case "-.--":
                    letter = 'Y';
                    break;
                case "--..":
                    letter = 'Z';
                    break;
                case ".----":
                    letter = '1';
                    break;
                case "..---":
                    letter = '2';
                    break;
                case "...--":
                    letter = '3';
                    break;
                case "....-":
                    letter = '4';
                    break;
                case ".....":
                    letter = '5';
                    break;
                case "-....":
                    letter = '6';
                    break;
                case "--...":
                    letter = '7';
                    break;
                case "---..":
                    letter = '8';
                    break;
                case "----.":
                    letter = '9';
                    break;
                case "-----":
                    letter = '0';
                    break;
            }

            return letter;
        }

        private List<string> messageToMorse(string letters)
        {
            List<string> morse = new List<string>();

            foreach(char letter in letters)
            {
                switch (letter)
                {
                    case 'A':
                        morse.Add(".-");
                        break;
                    case 'B':
                        morse.Add("-...");
                        break;
                    case 'C':
                        morse.Add("-.-.");
                        break;
                    case 'D':
                        morse.Add("-..");
                        break;
                    case 'E':
                        morse.Add(".");
                        break;
                    case 'F':
                        morse.Add("..-.");
                        break;
                    case 'G':
                        morse.Add("--.");
                        break;
                    case 'H':
                        morse.Add("....");
                        break;
                    case 'I':
                        morse.Add("..");
                        break;
                    case 'J':
                        morse.Add(".---");
                        break;
                    case 'K':
                        morse.Add("-.-");
                        break;
                    case 'L':
                        morse.Add(".-..");
                        break;
                    case 'M':
                        morse.Add("--");
                        break;
                    case 'N':
                        morse.Add("-.");
                        break;
                    case 'O':
                        morse.Add("---");
                        break;
                    case 'P':
                        morse.Add(".--.");
                        break;
                    case 'Q':
                        morse.Add("--.-");
                        break;
                    case 'R':
                        morse.Add(".-.");
                        break;
                    case 'S':
                        morse.Add("...");
                        break;
                    case 'T':
                        morse.Add("-");
                        break;
                    case 'U':
                        morse.Add("..-");
                        break;
                    case 'V':
                        morse.Add("...-");
                        break;
                    case 'W':
                        morse.Add(".--");
                        break;
                    case 'X':
                        morse.Add("-..-");
                        break;
                    case 'Y':
                        morse.Add("-.--");
                        break;
                    case 'Z':
                        morse.Add("--..");
                        break;
                    case '1':
                        morse.Add(".----");
                        break;
                    case '2':
                        morse.Add("..---");
                        break;
                    case '3':
                        morse.Add("...--");
                        break;
                    case '4':
                        morse.Add("....-");
                        break;
                    case '5':
                        morse.Add(".....");
                        break;
                    case '6':
                        morse.Add("-....");
                        break;
                    case '7':
                        morse.Add("--...");
                        break;
                    case '8':
                        morse.Add("---..");
                        break;
                    case '9':
                        morse.Add("----.");
                        break;
                    case '0':
                        morse.Add("-----");
                        break;
                    case ' ':
                        morse.Add("");
                        break;
                }
            }

            return morse;
        }
    }
}
