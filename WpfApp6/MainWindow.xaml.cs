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
using FluentValidation; 

namespace WpfApp6
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool KeyPressd = false;
        User uzivatel = new User();
        UserValidate validator = new UserValidate();

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            KeyPressd = true;
            Check();
        }


        private void Box_KeyUp(object sender, KeyEventArgs e)
        {
            KeyPressd = false;
        }


        void Check()
        {
            uzivatel.Forename = BoxFName.Text;
            uzivatel.Surname = BoxLName.Text;
            uzivatel.Email = BoxEmail.Text;
            uzivatel.Address = BoxAdress.Text;

            FluentValidation.Results.ValidationResult results = validator.Validate(uzivatel);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    OutputText.Text = "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage;
                }
            }
        }
    }
}
