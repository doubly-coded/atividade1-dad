using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalhodesk
{
    public partial class Form1 : Form
    {
        private float numero;
        private List<CheckBox> professoresCheckboxes;
        private List<CheckBox> professorasCheckboxes;

        public Form1()
        {
            InitializeComponent();

            timer1.Start();

            comboBox1.Items.Add("Professor");
            comboBox1.Items.Add("Professora");
            professoresCheckboxes = new List<CheckBox> { checkBox1, checkBox2, checkBox3 };
            professorasCheckboxes = new List<CheckBox> { checkBox4, checkBox5, checkBox6 };
            groupBox1.Visible = false;
            groupBox2.Visible = false;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = DateTime.Now.ToLongTimeString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            numero = (float)double.Parse(textBox1.Text);
            listBox1.Items.Add(numero.ToString());
            textBox1.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione um número", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string pegar = listBox1.SelectedItem.ToString();
                listBox1.Items.Remove(pegar.ToString());
            }


        }

        private void button12_Click(object sender, EventArgs e)
        {

            int soma = 0;

                if (listBox1.Items.Count < 3)
                {
                MessageBox.Show("Insira no mínimo três números", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                foreach (object value in listBox1.Items)
                {
                    soma += int.Parse(value.ToString());
                }

                     label2.Text = soma.ToString();
                }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (listBox2.Items.Count < 1)
            {
                MessageBox.Show("Selecione um professor ou professora", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            professorasCheckboxes.ForEach(checkBox =>
            {
                checkBox.Enabled = true;
                checkBox.Checked = false;
            });
            professoresCheckboxes.ForEach(checkBox =>
            {
                checkBox.Enabled = true;
                checkBox.Checked = false;
            });

            List<string> lines = new List<String>();
            foreach (object liItem in listBox2.Items)
                lines.Add(liItem.ToString());

            String path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\professores.txt";

            File.WriteAllLines(path, lines.ToArray());
            listBox2.Items.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Professor":
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    break;
                case "Professora":
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    break;
                default:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    break;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Professor":
                    professoresCheckboxes.ForEach(checkBox => {
                        if (checkBox.Checked && checkBox.Enabled)
                        {
                            listBox2.Items.Add(checkBox.Text);
                            checkBox.Enabled = false;
                        }
                    });
                    break;
                case "Professora":
                    professorasCheckboxes.ForEach(checkBox => {
                        if (checkBox.Checked && checkBox.Enabled)
                        {
                            listBox2.Items.Add(checkBox.Text);
                            checkBox.Enabled = false;
                        }
                    });
                    break;
                default:
                    MessageBox.Show("Selecione uma categoria", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
