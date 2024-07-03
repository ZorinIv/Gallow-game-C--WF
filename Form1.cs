using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Виселица
{
    public partial class Form1 : Form
    {
        public string word;
        public string mask;
        public char letter;
        public int count_try;
        public string[] words;
        public List<Button> press_buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }
         
        private void button33_Click(object sender, EventArgs e)
        {
            
            Button B = (Button)sender;
            letter = Convert.ToChar(B.Text);
            B.BackColor = Color.Red;
            B.Enabled = false;
            press_buttons.Add(B);
            if (!word.Contains(letter)) { count_try++; }
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    mask = mask.Remove(i,1).Insert(i,letter.ToString());
                    textBox1.Text = mask;
                }
            }
            textBox2.Text = (10 - count_try).ToString();   
            if (mask == word)
            {
                MessageBox.Show("ПОБЕДА!");
                textBox1.Clear();
                textBox2.Clear();
                foreach (Button button in press_buttons)
                {
                    button.Enabled = true;
                    button.BackColor = Color.Yellow;
                }
            }
            if (count_try == 10)
            {
                MessageBox.Show("ПОРАЖЕНИЕ!\n Загаданное слово " + word );
                textBox1.Clear();
                textBox2.Clear();
                foreach (Button button in press_buttons)
                {
                    button.Enabled = true;
                    button.BackColor = Color.Yellow;
                }
            }
            switch (count_try)
            {
                case 1: { pictureBox1.Image = Image.FromFile("1.jpg"); break; }
                case 2: { pictureBox1.Image = Image.FromFile("2.jpg"); break; }
                case 3: { pictureBox1.Image = Image.FromFile("2.jpg"); break; }
                case 4: { pictureBox1.Image = Image.FromFile("4.jpg"); break; }
                case 5: { pictureBox1.Image = Image.FromFile("5.jpg"); break; }
                case 6: { pictureBox1.Image = Image.FromFile("6.jpg"); break; }
                case 7: { pictureBox1.Image = Image.FromFile("6.jpg"); break; }
                case 8: { pictureBox1.Image = Image.FromFile("8.jpg"); break; }
                case 9: { pictureBox1.Image = Image.FromFile("9.jpg"); break; }
                case 10: { pictureBox1.Image = Image.FromFile("10.jpg"); break; }
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            count_try = 0;
            mask = null;
            word = " ";
            textBox1.Clear();
            textBox2.Clear();
            pictureBox1.Image = Image.FromFile("start.png");
            words = File.ReadAllLines("gallows1.txt", Encoding.Default);
            Random random = new Random();
            word = words[random.Next(0,words.Length)];
            for (int i = 0; i < word.Length; i++)
            {
                mask += '-'; 
            }
            textBox1.Text = mask;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
