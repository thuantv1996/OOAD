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
using System.Xml;

namespace ClinicManagement
{
    public partial class SetupForm : Form
    {
        string DataSource = "";
        string Id = "";
        string Password = "";
        public SetupForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get data 
            DataSource = txtDataSource.Text.ToString();
            Id = txtId.Text.ToString();
            Password = txtPassword.Text.ToString();

            if (DataSource == null || DataSource == "")
            {
                MessageBox.Show("Vui lòng nhập Data Source");
                return;
            }
            // connection string
            string connection = "Data Source=" + DataSource + ";Initial Catalog=QLPHONGKHAM;Integrated Security=True";
            if (comboBox1.SelectedIndex == 1)
            {
                connection += "; User ID =" + Id + ";";
                connection += " Password =" + Password + ";";
            }

            if (!TestConnection(connection))
            {
                MessageBox.Show("Thông số cấu hình sai! \nVui lòng kiểm tra lại");
                return;
            }
            try
            {
                string con = "metadata=res://*/QLPK.csdl|res://*/QLPK.ssdl|res://*/QLPK.msl;provider=System.Data.SqlClient;provider connection string=\" data source=" + DataSource
                + ";initial catalog=QLPHONGKHAM;integrated security=True;";
                if (comboBox1.SelectedIndex == 1)
                {
                    con += "user id =" + Id + ";";
                    con += "password =" + Password + ";";
                }
                con += "MultipleActiveResultSets=True;App=EntityFramework\"";
                using (XmlWriter xmlWriter = XmlWriter.Create("connections.config"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("connectionStrings");
                    xmlWriter.WriteStartElement("add");
                    xmlWriter.WriteAttributeString("name", "QLPHONGKHAMEntities");
                    xmlWriter.WriteAttributeString("providerName", "System.Data.EntityClient");
                    xmlWriter.WriteAttributeString("connectionString", con);
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
                System.IO.File.WriteAllText("connectionString.txt", DataSource);
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                Application.Exit();
            }
        }
           
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private bool TestConnection(string Connection)
        {
            try
            {
                SqlConnection con = new SqlConnection(Connection);
                con.Open();
                if(con.State == ConnectionState.Open)
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                System.Console.Write(e);
                return false;
            }
            return true;
        }
    }
}
