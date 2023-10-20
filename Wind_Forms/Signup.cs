using System;
using System.Windows.Forms;

namespace Wind_Forms
{
    public partial class Signup : Form
    {
        db data = new db();
        public Signup()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }
        private void Signup_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) {
                textBox3.Text = listView1.SelectedItems[0].Text;
                textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void Signup_Load(object sender, EventArgs e)
        {
            data.load_data("select * from tblReg", listView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qryCreate = "insert into tblReg values('" + textBox1.Text + "', '" + textBox2.Text + "')";
            string qryUpdate = "update tblReg Set email = '" + textBox1.Text + "', password = '" + textBox2.Text + "' where id = '" + textBox3.Text + "'";
            data.saveData(qryCreate, qryUpdate, textBox3);
            data.load_data("select * from tblReg", listView1);

            textBox3.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.Text != "")
            {
                data.load_data("select * from tblReg where id = '" + textBox4.Text + "'", listView1);
            } else
            {
                data.load_data("select * from tblReg", listView1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data.delete("DELETE FROM tblReg where id = '" + textBox3.Text + "'", textBox3);
            data.load_data("select * from tblReg", listView1);
            textBox3.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
