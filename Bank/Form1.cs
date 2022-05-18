using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;


namespace Bank
{
    public partial class Bank : Form, IView
    {
        public Bank()
        {
            InitializeComponent();
        }

        public event EventHandler<CreateCardEventArgs> OnCreateCard;
        public event EventHandler OnLoad;

        private void Form1_Load(object sender, EventArgs e)
        {
            OnLoad?.Invoke(this, EventArgs.Empty);

            dateTimePicker.CustomFormat="yyyy-MM-dd";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        public static bool Regex(string pattern, string textBox)
        {
            Regex regex = new Regex(pattern);
          
            if (regex.IsMatch(textBox))
            {
                return true;
            }

            return false;
        }

        private void groupBoxSelect_Enter(object sender, EventArgs e)
        {

        }

        private void PurchaseCard_Click_1(object sender, EventArgs e)
        {
           
        }

        private void ChangeCardPassword_Click(object sender, EventArgs e)
        {
           
        }

        private void textFirstName_TextChanged(object sender, EventArgs e)
        {
            if (textFirstName.Text.IsMatch(@"^([A-Za-z]+)$"))
            {
                pictureBox4.Image = Properties.Resources._checked;
            }
            else 
            {
                pictureBox4.Image = Properties.Resources.multiply;
            }
        }

        private void textLastName_TextChanged(object sender, EventArgs e)
        {
            if (textLastName.Text.IsMatch(@"^([A-Za-z]+)$"))
            {
                pictureBox5.Image = Properties.Resources._checked;
            }
            else
            {
                pictureBox5.Image = Properties.Resources.multiply;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if ((DateTime.Now.AddYears(-18) > dateTimePicker.Value))
            {
                pictureBox6.Image = Properties.Resources._checked;
            }
            else
            {
                pictureBox6.Image = Properties.Resources.multiply;
            }
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            if (textEmail.Text.IsMatch(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                pictureBox3.Image = Properties.Resources._checked;
            }
            else
            {
                pictureBox3.Image = Properties.Resources.multiply;
            }
        }

        private void textPassportSerial_TextChanged(object sender, EventArgs e)
        {
            if (textPassportSerial.Text.IsMatch(@"^([A-Z,a-z]{2})([0-9]{7})$"))
            {
                pictureBox2.Image = Properties.Resources._checked;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.multiply;
            }
        }

        public void ShowRates(IEnumerable<Rate> rates)
        {
            lblRate.Text = string.Join(Environment.NewLine, rates.Select(r => $"{r.MoneyType} | {r.Value}"));
        }

        private void buttonApprove_Click(object sender, EventArgs e)
        {
            User user = new User();
            Card card = new Card();
            user.FirstName = textFirstName.Text;
            user.LastName = textLastName.Text;
            user.PassportSerial = textPassportSerial.Text;
            user.BirthDay = dateTimePicker.Value;
            user.Email = textEmail.Text;
            CreateCardEventArgs createCard = new CreateCardEventArgs(card,user);

            OnCreateCard(this, createCard);
        }

        public async void SuccessTransaction()
        {
            lblText.Location = new Point(80, 45);
            lblText.Text = "Your card created successfuly";
            await Task.Delay(5000);
            lblText.Text = "Complete the data";
            lblText.Location = new Point(130, 45);

            textFirstName.Text = "";
            textLastName.Text = "";
            textEmail.Text = "";
            textPassportSerial.Text = "";
            dateTimePicker.Value = DateTime.Now;

            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;

        }

        public void WarningMessage(string message)
        {
            lblText.Location = new Point(80, 45);
            lblText.Text = message;
        }

    }
}
