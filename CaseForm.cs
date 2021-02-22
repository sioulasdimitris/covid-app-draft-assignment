using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidApp
{
    
    public partial class CaseForm : Form
    {
        private bool updateForm;
        private int recordId;

        public CaseForm()
        {
            updateForm = false;
            InitializeComponent();
        }

        public CaseForm(int id)
        {
            updateForm = true;
            recordId = id;
            InitializeComponent();
            this.fillFields(id);
        }

        private void fillFields(int id)
        {
            String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
            SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
            connection.Open();//open connection with database

            String query = "Select fullname,email,phone,gender,age,diseases,address FROM cases WHERE id='" + id + "'";//query
            SQLiteCommand command = new SQLiteCommand(query, connection);//establish query
            SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable

            while (reader.Read())//reads the next row from the result set
            {

                try
                {
                    fullNameTextBox.Text = reader.GetString(0);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Please enter a proper fullname for the case!", "No Name");
                }


                try
                {
                    emailTextBox.Text = reader.GetString(1);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Please enter a proper email for the case!", "No Email");
                }


                try
                {
                    phoneTextBox.Text = reader.GetString(2);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Please enter a proper phone for the case!", "No Phone");
                }

                if (reader.GetString(3).Equals("male"))
                {
                    maleRadioButton.Checked = true;
                    femaleRadioButton.Checked = false;
                } else if (reader.GetString(3).Equals("female"))
                {
                    maleRadioButton.Checked = false;
                    femaleRadioButton.Checked = true;
                }

                try
                {
                    ageTextBox.Text = reader.GetInt32(4) + "";
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Please enter a proper age for the case!", "No Age");
                }

                underLyingDiseasesRichTextBox.Text = reader.GetString(5);


                try
                {
                    addressTextBox.Text = reader.GetString(6);
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Please enter a proper address for the case!", "No Address");
                }

               
            }

            connection.Close();//close the connection
        }

        private void CaseForm_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (updateForm)
            {
                String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
                SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
                connection.Open();//open connection with database

                String gender = "";
                if (femaleRadioButton.Checked)
                {
                    gender = "female";
                }
                else if (maleRadioButton.Checked)
                {
                    gender = "male";
                }

                string insertQuery = "UPDATE CASES SET fullname = '" + fullNameTextBox.Text + "', email = '" + emailTextBox.Text + "', phone = '" + phoneTextBox.Text + "', gender = '" + gender + "', age = '" + ageTextBox.Text + "', diseases = '" + underLyingDiseasesRichTextBox.Text + "', address = '" + addressTextBox.Text + "', datetime = '" + DateTime.Now + "' WHERE id = '" + recordId + "'";

                SQLiteCommand command = new SQLiteCommand(insertQuery, connection);//establish query

                try
                {
                    SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable
                }
                catch (System.Data.SQLite.SQLiteException)
                {
                    MessageBox.Show("Email already exists!", "Same Email");
                }

                connection.Close();//close the connection
            } else
            {
                String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
                SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
                connection.Open();//open connection with database

                String gender = "";
                if (femaleRadioButton.Checked)
                {
                    gender = "female";
                }
                else if (maleRadioButton.Checked)
                {
                    gender = "male";
                }

                string insertQuery = "INSERT INTO CASES(fullname,email,phone,gender,age,diseases,address,datetime) VALUES('" + fullNameTextBox.Text + "','" + emailTextBox.Text + "','" + phoneTextBox.Text + "','" + gender + "','" + ageTextBox.Text + "','" + underLyingDiseasesRichTextBox.Text + "','" + addressTextBox.Text + "','" + DateTime.Now + "')";

                SQLiteCommand command = new SQLiteCommand(insertQuery, connection);//establish query
                SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable

                connection.Close();//close the connection
                
            }
            this.Close();
        }
    }
}
