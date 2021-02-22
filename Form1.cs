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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registerNewCaseButton_Click(object sender, EventArgs e)
        {
            //create and open the form RegisterNewCaseForm
            CaseForm caseForm = new CaseForm();
            caseForm.Show();
        }

        private void viewAllRegisteredCasesButton_Click(object sender, EventArgs e)
        {
            resultsPanel.Controls.Clear();//remove all controls from the panel

            //controls
            int xPos = 0;
            int yPos = 0;
            List<System.Windows.Forms.Label> indexLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> idLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> nameLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> genderLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> dateLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Button> viewRecordButtons = new List<System.Windows.Forms.Button>();
            List<System.Windows.Forms.Button> deleteRecordButtons = new List<System.Windows.Forms.Button>();
            int n = 0;

            String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
            SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
            connection.Open();//open connection with database
           
            String query = "Select id,fullname,gender,datetime From cases;";//query
            SQLiteCommand command = new SQLiteCommand(query, connection);//establish query
            SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable
            
            while (reader.Read())//reads the next row from the result set
            {
               
                xPos = 0;
                yPos = n * 40;
                indexLabels.Add(new System.Windows.Forms.Label());
                indexLabels[n].BackColor = Color.White;
                indexLabels[n].Width = 10; // Width of button
                indexLabels[n].Left = xPos;
                indexLabels[n].Top = yPos;
                indexLabels[n].Text = n + 1 + "";
                resultsPanel.Controls.Add(indexLabels[n]);

                idLabels.Add(new System.Windows.Forms.Label());
                idLabels[n].BackColor = Color.White;
                indexLabels[n].Width = 10; // Width of button
                idLabels[n].Left = xPos + 20;
                idLabels[n].Top = yPos;
                idLabels[n].Text = reader.GetInt32(0) + "";
                resultsPanel.Controls.Add(idLabels[n]);

                nameLabels.Add(new System.Windows.Forms.Label());
                nameLabels[n].BackColor = Color.White;
                nameLabels[n].Left = xPos + 120;
                nameLabels[n].Top = yPos;
                nameLabels[n].Text = reader.GetString(1);
                resultsPanel.Controls.Add(nameLabels[n]);

                genderLabels.Add(new System.Windows.Forms.Label());
                genderLabels[n].BackColor = Color.White;
                genderLabels[n].Left = xPos + 220;
                genderLabels[n].Top = yPos;
                genderLabels[n].Text = reader.GetString(2);
                resultsPanel.Controls.Add(genderLabels[n]);

                dateLabels.Add(new System.Windows.Forms.Label());
                dateLabels[n].BackColor = Color.White;
                dateLabels[n].Width = 130; // Width of button
                dateLabels[n].Left = xPos + 320;
                dateLabels[n].Top = yPos;
                dateLabels[n].Text = reader.GetString(3);
                resultsPanel.Controls.Add(dateLabels[n]);

                viewRecordButtons.Add(new System.Windows.Forms.Button());
                viewRecordButtons[n].Tag = reader.GetInt32(0) + ""; // Tag of button
                viewRecordButtons[n].Width = 50; // Width of button
                viewRecordButtons[n].Height = 20; // Height of button
                viewRecordButtons[n].Left = xPos + 450;
                viewRecordButtons[n].Top = yPos;
                viewRecordButtons[n].Text = "View";
                viewRecordButtons[n].Click += new System.EventHandler(viewButton);
                resultsPanel.Controls.Add(viewRecordButtons[n]); // panel hold the Buttons

                deleteRecordButtons.Add(new System.Windows.Forms.Button());
                deleteRecordButtons[n].Tag = reader.GetInt32(0) + ""; // Tag of button
                deleteRecordButtons[n].Width = 50; // Width of button
                deleteRecordButtons[n].Height = 20; // Height of button
                deleteRecordButtons[n].Left = xPos + 500;
                deleteRecordButtons[n].Top = yPos;
                deleteRecordButtons[n].Text = "Delete";
                deleteRecordButtons[n].Click += new System.EventHandler(DeleteButton);
                resultsPanel.Controls.Add(deleteRecordButtons[n]); // panel hold the Buttons

                n++;
            }

            

            connection.Close();//close the connection
        }

        public void viewButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Int32.Parse(btn.Tag.ToString());
            viewRecord(id);
        }

        public void viewRecord(int id)
        {
            //create and open the form RegisterNewCaseForm
            CaseForm caseForm = new CaseForm(id);
            caseForm.Show();
        }

        public void DeleteButton(Object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            int id = Int32.Parse(btn.Tag.ToString());
            deleteRecord(id);
        }

        public void deleteRecord(int id)
        {
            String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
            SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
            connection.Open();//open connection with database

            String query = "DELETE FROM cases WHERE id='" + id + "'";//query
            SQLiteCommand command = new SQLiteCommand(query, connection);//establish query
            SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable

            connection.Close();//close the connection
        }

            private void Form1_Load(object sender, EventArgs e)
        {
            this.addScrollbarToResultsPanel();
        }


        private void addScrollbarToResultsPanel()
        {
            resultsPanel.AutoScroll = false;
            resultsPanel.HorizontalScroll.Enabled = false;
            resultsPanel.HorizontalScroll.Visible = false;
            resultsPanel.HorizontalScroll.Maximum = 0;
            resultsPanel.AutoScroll = true;
        }

        private void item1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gender stats
            String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
            SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
            connection.Open();//open connection with database

            //total cases
            String queryTotalCases = "Select Count(*) From cases;";//query
            SQLiteCommand command = new SQLiteCommand(queryTotalCases, connection);//establish query
            SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable
            int totalCases = 0;
            while (reader.Read())//reads the next row from the result set
            {
                totalCases = totalCases + reader.GetInt32(0);
            }

            //male cases
            String queryMaleCases = "Select Count(*) From cases WHERE gender = 'male';";//query
            SQLiteCommand command1 = new SQLiteCommand(queryMaleCases, connection);//establish query
            SQLiteDataReader reader1 = command1.ExecuteReader();//execute query and save the result to the reader variable
            int maleCases = 0;
            while (reader1.Read())//reads the next row from the result set
            {
                maleCases = maleCases + reader1.GetInt32(0);
            }

            //female cases
            String queryFemaleCases = "Select Count(*) From cases WHERE gender = 'female';";//query
            SQLiteCommand command2 = new SQLiteCommand(queryFemaleCases, connection);//establish query
            SQLiteDataReader reader2 = command2.ExecuteReader();//execute query and save the result to the reader variable
            int femaleCases = 0;
            while (reader2.Read())//reads the next row from the result set
            {
                femaleCases = femaleCases + reader2.GetInt32(0);
            }

            string title = "Gender Stats";
            string message = "Total Cases: " + totalCases + "\nMale Cases: "+ (int)Math.Round((double)(100 * maleCases) / totalCases) + "%\nFemale Cases: "+ (int)Math.Round((double)(100 * femaleCases) / totalCases) + "%";
            MessageBox.Show(message, title);
            connection.Close();
        }

        private void item2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //age stats
            String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
            SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
            connection.Open();//open connection with database

            //total cases
            String queryTotalCases = "Select Count(*) From cases;";//query
            SQLiteCommand command = new SQLiteCommand(queryTotalCases, connection);//establish query
            SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable
            int totalCases = 0;
            while (reader.Read())//reads the next row from the result set
            {
                totalCases = totalCases + reader.GetInt32(0);
            }

            //unique ages
            String queryUniqueAges = "Select DISTINCT(age) From cases;";//query
            SQLiteCommand command1 = new SQLiteCommand(queryUniqueAges, connection);//establish query
            SQLiteDataReader reader1 = command1.ExecuteReader();//execute query and save the result to the reader variable
            List<int> uniqueAges = new List<int>();
            while (reader1.Read())//reads the next row from the result set
            {
                uniqueAges.Add(reader1.GetInt32(0));
            }

            //for all unique ages
            string message = "Total Cases: " + totalCases;

            for (int i = 0; i < uniqueAges.Count; i++) // Loop through List with for
            {
                String queryAge = "Select Count(*) From cases  WHERE age='" + uniqueAges[i] + "'";//query
                SQLiteCommand command2 = new SQLiteCommand(queryAge, connection);//establish query
                SQLiteDataReader reader2 = command2.ExecuteReader();//execute query and save the result to the reader variable
                while (reader2.Read())//reads the next row from the result set
                {
                    message += "\nAge: " + uniqueAges[i] + " Frequency: " + reader2.GetInt32(0)+" Percentage: "+ (int)Math.Round((double)(100 * reader2.GetInt32(0)) / totalCases)+"%";
                }
                
            }

            string title = "Age Stats";
            MessageBox.Show(message, title);
            connection.Close();
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            resultsPanel.Controls.Clear();//remove all controls from the panel
            //controls
            int xPos = 0;
            int yPos = 0;
            String query = "";
            List<System.Windows.Forms.Label> indexLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> idLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> nameLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> genderLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Label> dateLabels = new List<System.Windows.Forms.Label>();
            List<System.Windows.Forms.Button> viewRecordButtons = new List<System.Windows.Forms.Button>();
            List<System.Windows.Forms.Button> deleteRecordButtons = new List<System.Windows.Forms.Button>();
            int n = 0;

            String connectionStringg = "Data Source=covidappdb.db;Version=3;";//connection string for database
            SQLiteConnection connection = new SQLiteConnection(connectionStringg);//attempt connection with sqlite database
            connection.Open();//open connection with database

            //build query
            if (!String.IsNullOrEmpty(searchByNameTextBox.Text) && !String.IsNullOrEmpty(searchByAgeTextBox.Text))
            {
                query = "Select id,fullname,gender,datetime From cases WHERE fullname='" + searchByNameTextBox.Text + "' AND age='" + searchByAgeTextBox.Text + "'";//query

            }
            else if (String.IsNullOrEmpty(searchByNameTextBox.Text) && !String.IsNullOrEmpty(searchByAgeTextBox.Text))
            {
                query = "Select id,fullname,gender,datetime From cases WHERE age='" + searchByAgeTextBox.Text + "'";//query

            } else if (!String.IsNullOrEmpty(searchByNameTextBox.Text) && String.IsNullOrEmpty(searchByAgeTextBox.Text))
            {
                query = "Select id,fullname,gender,datetime From cases WHERE fullname='" + searchByNameTextBox.Text + "'";//query

            } else
            {
                query = "Select id,fullname,gender,datetime From cases;";//query

            }

            SQLiteCommand command = new SQLiteCommand(query, connection);//establish query
            SQLiteDataReader reader = command.ExecuteReader();//execute query and save the result to the reader variable

            while (reader.Read())//reads the next row from the result set
            {

                xPos = 0;
                yPos = n * 40;
                indexLabels.Add(new System.Windows.Forms.Label());
                indexLabels[n].BackColor = Color.White;
                indexLabels[n].Width = 10; // Width of button
                indexLabels[n].Left = xPos;
                indexLabels[n].Top = yPos;
                indexLabels[n].Text = n + 1 + "";
                resultsPanel.Controls.Add(indexLabels[n]);

                idLabels.Add(new System.Windows.Forms.Label());
                idLabels[n].BackColor = Color.White;
                indexLabels[n].Width = 10; // Width of button
                idLabels[n].Left = xPos + 20;
                idLabels[n].Top = yPos;
                idLabels[n].Text = reader.GetInt32(0) + "";
                resultsPanel.Controls.Add(idLabels[n]);

                nameLabels.Add(new System.Windows.Forms.Label());
                nameLabels[n].BackColor = Color.White;
                nameLabels[n].Left = xPos + 120;
                nameLabels[n].Top = yPos;
                nameLabels[n].Text = reader.GetString(1);
                resultsPanel.Controls.Add(nameLabels[n]);

                genderLabels.Add(new System.Windows.Forms.Label());
                genderLabels[n].BackColor = Color.White;
                genderLabels[n].Left = xPos + 220;
                genderLabels[n].Top = yPos;
                genderLabels[n].Text = reader.GetString(2);
                resultsPanel.Controls.Add(genderLabels[n]);

                dateLabels.Add(new System.Windows.Forms.Label());
                dateLabels[n].BackColor = Color.White;
                dateLabels[n].Width = 130; // Width of button
                dateLabels[n].Left = xPos + 320;
                dateLabels[n].Top = yPos;
                dateLabels[n].Text = reader.GetString(3);
                resultsPanel.Controls.Add(dateLabels[n]);

                viewRecordButtons.Add(new System.Windows.Forms.Button());
                viewRecordButtons[n].Tag = reader.GetInt32(0) + ""; // Tag of button
                viewRecordButtons[n].Width = 50; // Width of button
                viewRecordButtons[n].Height = 20; // Height of button
                viewRecordButtons[n].Left = xPos + 450;
                viewRecordButtons[n].Top = yPos;
                viewRecordButtons[n].Text = "View";
                viewRecordButtons[n].Click += new System.EventHandler(viewButton);
                resultsPanel.Controls.Add(viewRecordButtons[n]); // panel hold the Buttons

                deleteRecordButtons.Add(new System.Windows.Forms.Button());
                deleteRecordButtons[n].Tag = reader.GetInt32(0) + ""; // Tag of button
                deleteRecordButtons[n].Width = 50; // Width of button
                deleteRecordButtons[n].Height = 20; // Height of button
                deleteRecordButtons[n].Left = xPos + 500;
                deleteRecordButtons[n].Top = yPos;
                deleteRecordButtons[n].Text = "Delete";
                deleteRecordButtons[n].Click += new System.EventHandler(DeleteButton);
                resultsPanel.Controls.Add(deleteRecordButtons[n]); // panel hold the Buttons

                n++;
            }



            connection.Close();//close the connection
        }

        private void resultsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
