using System;
using System.Collections.Generic;
using System.Linq;
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

namespace PWGenW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
            PWBox.Document.Blocks.Clear();
            PWBox.Document.Blocks.Add(new Paragraph(new Run(GeneratePassword(SelWords.SelectedIndex + 2))));
        }

        private void UpdatePasswordList()
        {
            PWBox.Document.Blocks.Clear();
            PWBox.Document.Blocks.Add(new Paragraph(new Run(GeneratePassword(SelWords.SelectedIndex + 2))));       
        }

        private Random rnd = new Random();

        private string GeneratePassword(int words = 2)
        {
            string pw = null;

            for (var i = 0; i < words; i++)
            {
                string word = Words.AllWords[rnd.Next(Words.AllWords.Count)];
                if ((bool)CBCapital.IsChecked) 
                {
                    pw += word.Substring(0, 1).ToUpper() + word.Substring(1);
                }
                else
                {
                    pw += word;
                }
                if (((bool)CBSpaces.IsChecked) && (i != words - 1)) { pw += " "; }
            }

            // append random special char
            if ((bool)CBAppendChar.IsChecked)
                pw += Words.Special[rnd.Next(Words.Special.Count)];

            // append random number
            if ((bool)CBNum.IsChecked)
                pw += rnd.Next(999).ToString();

            // append string
            if (CBAppendString != null)
                pw += CBAppendString.Text;

            StatusText.Text = "Password is " + pw.Length + " characters. Choosing from " + Words.AllWords.Count + " words.";
            return pw;
        }

        private string MakeL33t(string password)
        {
            
            switch (rnd.Next(5))
            {
                case 0:
                    password = password.Replace('i', '1');
                    break;
                case 1:
                    password = password.Replace('a', '@');
                    break;
                case 2:
                    password = password.Replace('e', '3');
                    break;
                case 3:
                    password = password.Replace('o', '0');
                    break;
                case 4:
                    password = password.Replace('l', '1');
                    break;
                case 5:
                    password = password.Replace('s', '$');
                    break;
            }
            return password;
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdatePasswordList();
        }
    }
}
