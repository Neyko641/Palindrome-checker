using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int num_length(int num)
        {
            int len = 0;
            
            while (num > 0)
            {
                len++;
                num /= 10;
            }

            return len;
        }

        bool check_palindrome(Stack<int> s1, Stack<int> s2)
        {
            richTextBox1.Text += Environment.NewLine + "s3_rev size IN CHECK: " + s2.Count + " " + s2.Peek();

            while (s1.Count != 0)
            {
                if (s1.Peek() != s2.Peek())
                {

                    richTextBox1.Text += Environment.NewLine + "s3_rev size IN CHECK: " + s2.Count + " " + s2.Peek();

                    return false;
                }

                s1.Pop();
                s2.Pop();
            }

            return true;

        }

        public void make_palindrome(int number)
        {

            int a = number;
            int b = a;
            int len = num_length(a) - 1;
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            while (len >= 0)
            {

                int tmp1 = a / Convert.ToInt32(Math.Pow(10, len));
                if (num_length(tmp1) > 1)
                    tmp1 %= 10;

                s1.Push(tmp1);

                richTextBox1.Text += Environment.NewLine + "Number " + tmp1 + " has been pushed to s1  ";


                len--;
            }
            richTextBox1.Text += Environment.NewLine + Environment.NewLine;
            while (b > 0)
            {

                int tmp2 = b % 10;
                s2.Push(tmp2);

                richTextBox1.Text += Environment.NewLine + "Number " + tmp2 + " has been pushed to s2 ";

                b /= 10;
            }


            richTextBox1.Text += Environment.NewLine + Environment.NewLine;

            int save_num = 0;

            Stack<int> s3 = new Stack<int>();

            while ((save_num == 1) || s1.Count != 0)
            {
                int tmp = 0;
                if (s1.Count != 0) tmp = s1.Pop() + s2.Pop() + save_num;
                else
                {
                    tmp += save_num;
                }

                if (tmp > 9)
                {
                    save_num = 1;
                    tmp %= 10;
                }
                else save_num = 0;


                s3.Push(tmp);

                richTextBox1.Text += Environment.NewLine + "Number " + tmp + " has been pushed to s3  ";


            }



            richTextBox1.Text += Environment.NewLine + Environment.NewLine;

            Stack<int> s3_rev = new Stack<int>();
            Stack<int> s3_rev_copy = new Stack<int>();


            while (s3.Count != 0)
            {
                int x = s3.Pop();
                s3_rev.Push(x);
                richTextBox1.Text += Environment.NewLine + "s3_rev e pushnat  ";

                s3_rev_copy.Push(x);
            }

            while (s3_rev_copy.Count != 0)
            {
                int x = s3_rev_copy.Pop();
                s3.Push(x);
            }


            Stack<int> s4 = new Stack<int>();
            richTextBox1.Text += Environment.NewLine + "s3_rev size: " + s3_rev.Count + " " + s3_rev.Peek();

            if (check_palindrome(s3, s3_rev) == true)
            {
                richTextBox1.Text += Environment.NewLine + "The number is palindrome. ";
            }
            else
            {
                richTextBox1.Text += Environment.NewLine + "The number is NOT palindrome. ";

                richTextBox1.Text += Environment.NewLine + "s3_rev size: " + s3_rev.Count + " " + s3_rev.Peek();

                int new_num = 0;
                int new_num_len = s3_rev.Count;
                int i = 0;

                while (s3_rev.Count != 0)
                {
                    int x = s3_rev.Pop();

                    richTextBox1.Text += Environment.NewLine + "pe6o be6e tuk" + s3_rev.Count + " " + x;


                    new_num += x * Convert.ToInt32(Math.Pow(10, i));
                    
                    i++;

                }

                richTextBox1.Text += Environment.NewLine + "The algorithm will run once more with number " + new_num;

                make_palindrome(new_num);


            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = "";
            int num = Convert.ToInt32(textBox1.Text);
            make_palindrome(num);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
