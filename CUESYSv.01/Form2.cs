using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUESYSv._01
{
    public partial class Form2 : Form
    {
        dbConn mysqlConn = new dbConn();
        public Form2()
        {
            InitializeComponent();
            dbConfig();
            mysqlConn.connect();
        }

        public bool dbConfig()
        {
            try
            {
                mysqlConn.varConfigServer = "keabetswet.cucstudents.org";
                mysqlConn.varConfigDatabase = "kea_CUEsys";
                mysqlConn.varConfigUser = "kea_CUEDadmin";
                mysqlConn.varConfigPass = "Password123!";
                return true;
            }
            catch { return false; }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd") /*+ " " + tbTime.Text + ":00";*/ ;
            string varPaid;
            if (checkBox1.Checked == true) { varPaid = "Y"; }
            else { varPaid = "N"; }
            if (mysqlConn.connOpen() == true)
            {
                mysqlConn.insertBooking(tbCust.Text, tbAir.Text, tbOrigin.Text, tbDest.Text, tbFNum.Text, tbSeat.Text, date, tbCost.Text, varPaid);
                MessageBox.Show("You have successfully made a Booking!");
            }
        }
    }
}
