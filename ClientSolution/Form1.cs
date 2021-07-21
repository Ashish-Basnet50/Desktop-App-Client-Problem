using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClientSolution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = COSYSSERVER\SQLEXPRESS; Initial Catalog = PractiseSharmaji; Integrated Security = True");
        public int Sno;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            GetClientListRecord();

        }

        private void GetClientListRecord()
        {
            SqlCommand cmd = new SqlCommand("select * from ClientProblemList", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            ClientlogGridview.DataSource = dt;

        }
        //Insert Query
        private void btninsert_Click(object sender, EventArgs e)
        {
            if (Isvalid())
            {
                Status st = comboBox1.SelectedItem.ToString() == "Running" ? Status.Running : Status.Completed;
                
                SqlCommand cmd = new SqlCommand("insert into ClientProblemList(CoOperativeName, Problem, TemporarySolution, PermanentSolution, Comment, StatusId) values(@CoOperativeName, @Problem, @TemporarySolution, @PermanentSolution, @Comment, @StatusId)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CoOperativeName", txtcoopname.Text);
                cmd.Parameters.AddWithValue("@Problem", txtproblem.Text);
                cmd.Parameters.AddWithValue("@TemporarySolution", txttemporarysolution.Text);
                cmd.Parameters.AddWithValue("@PermanentSolution", txtpermanentsolution.Text);
                cmd.Parameters.AddWithValue("@Comment", txtcomment.Text);
                cmd.Parameters.AddWithValue("@StatusId", st);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Coopname is successfully saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetClientListRecord();
                ResetFormControls();
            }
        }
        //Validation Part
        private bool Isvalid()
        {
            if (txtcoopname.Text==string.Empty)
            {
                MessageBox.Show("Coopname is requried","Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
            {
                MessageBox.Show("Status  is requried", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //Reset Operation
        private void btnreset_Click(object sender, EventArgs e)
        {
            ResetFormControls();

        }

        private void ResetFormControls()
        {
            Sno = 0;
            txtcoopname.Clear();
            txtpermanentsolution.Clear();
            txtcomment.Clear();
            txtproblem.Clear();
            txttemporarysolution.Clear();
            comboBox1.SelectedItem= null;
            txtcoopname.Focus();
        }
        //GridView Ko Sap Record Show Garana Ko lagi
        private void ClientlogGridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Sno = Convert.ToInt32(ClientlogGridview.SelectedRows[0].Cells[0].Value);
            txtcoopname.Text = ClientlogGridview.SelectedRows[0].Cells[1].Value.ToString();
            txtcomment.Text = ClientlogGridview.SelectedRows[0].Cells[2].Value.ToString();
            txtpermanentsolution.Text = ClientlogGridview.SelectedRows[0].Cells[3].Value.ToString();
            txtproblem.Text = ClientlogGridview.SelectedRows[0].Cells[4].Value.ToString();
            txttemporarysolution.Text = ClientlogGridview.SelectedRows[0].Cells[5].Value.ToString();
            comboBox1.Text= ClientlogGridview.SelectedRows[0].Cells[6].Value.ToString();
        }
        //update operation
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (Sno>1)
            {
                Status st = comboBox1.SelectedItem.ToString() == "Running" ? Status.Running : Status.Completed;
                SqlCommand cmd = new SqlCommand("update ClientProblemList set CoOperativeName=@CoOperativeName, Problem=@Problem, TemporarySolution=@TemporarySolution, PermanentSolution=@PermanentSolution, Comment=@Comment, StatusId=@StatusId where Sno=@Sno", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CoOperativeName", txtcoopname.Text);
                cmd.Parameters.AddWithValue("@Problem", txtproblem.Text);
                cmd.Parameters.AddWithValue("@TemporarySolution", txttemporarysolution.Text);
                cmd.Parameters.AddWithValue("@PermanentSolution", txtpermanentsolution.Text);
                cmd.Parameters.AddWithValue("@Comment", txtcomment.Text);
                cmd.Parameters.AddWithValue("@StatusId", st);
                cmd.Parameters.AddWithValue("@Sno", this.Sno);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("ClientProblemList is update successfully", "updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetClientListRecord();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Please Select an ClientProblemList to update his information", "select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Delete Operation
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (Sno>1)
            {
              
                SqlCommand cmd = new SqlCommand("delete from ClientProblemList  where Sno=@Sno", con);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("@Sno", this.Sno);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("ClientProblemList is delete from the system ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetClientListRecord();
                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Please Select an ClientProblemList to delete", "select?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
    //Declare Combo Box StatusId
    public enum Status
    {
        Running=1,
        Completed=2
    }



}
