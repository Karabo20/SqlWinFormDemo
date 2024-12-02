using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace SqlWinFormDemo
{
    public partial class AddPerson : Form
    {
        public AddPerson()
        {
            InitializeComponent();
        }



        string connString = "Server=Room5320\\SQLEXPRESS; Database=Trial;Trusted_Connection=True";
        string insertQuery = "insert into People (name, surname) values (@name, @sname)";

        string deleteQuery = "delete from People where ID = 10";

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Person person1 = new Person(txtName.Text, txtSurname.Text);

            using (SqlConnection connect = new SqlConnection(connString))
            {
                

                connect.Open();
                connect.Execute(insertQuery, new { name = txtName.Text, sname = txtSurname.Text });
                //connect.Execute(deleteQuery);
                connect.Close();
                txtName.Clear();
                txtSurname.Clear();
                


            }

           




        }
    }
}
