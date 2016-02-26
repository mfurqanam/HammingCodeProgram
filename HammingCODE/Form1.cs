using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        static int paritybits = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string mys = textBox1.Text;
            string[] my = new string[mys.Length];
            char[] m = new char[mys.Length];
            int i = 0, k = 0, c = 1, b = 0, d = 4, flag = 0;
            double r = 0, y = 0, j = 0;    
                       
            for (i = 0; i < mys.Length; i++)
                {

                    my[i] = (mys[i].ToString());
                    if (my[i] != "1" && my[i] != "0" )
                     
                        {
                            textBox3.Text = "You can enter only binary bits";
                            flag = 1;
                            break;
                        }
                }

            if (flag == 0)

            {
                label2.Text = "";
                textBox2.Clear();
                if (mys.Length == 2)
                    paritybits = 3;
                else if (mys.Length == 1)
                    paritybits = 2;
                else
                {
                    for (i = 0; i <= mys.Length; i++)
                    {
                        r = Math.Pow(2, i);
                        y = i + mys.Length + 1;
                        if (r >= y)
                        {
                            paritybits = i;
                            break;
                        }
                    }
                }

                int[] data = new int[mys.Length + paritybits + 10];
                for (i = 3, k = 0; i <= mys.Length + paritybits; i++, k++)
                {
                    data[i] = Convert.ToInt16(my[k]);

                    if (i == d - 1)
                    {
                        i++;
                        d *= 2;
                    }

                }


                for (i = c; b < paritybits; i = c)
                {

                    for (k = c; k <= mys.Length + paritybits; k++)
                    {
                        data[i] = data[i] ^ data[k];
                        if (k % c == c - 1)
                        {
                            k += c;
                        }

                    }

                    b++;

                    c = (c * 2);
                }


                for (i = 1; i <= mys.Length + paritybits; i++)
                {


                    textBox2.Text = textBox2.Text + data[i].ToString();

                }

               textBox3.Text = textBox2.Text;
                if (mys == "")
                {
                    textBox3.Text = "Please enter some binary bits";
                } 

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string mys1 = textBox2.Text;
            string[] my1 = new string[mys1.Length];
            int i = 0, k = 0, a = 0, c = 1, b = 0, d = 4;
            int[] C_Values = new int[paritybits + 10];
            bool flag=false;

            for (i = 0; i < mys1.Length; i++)
            {
                my1[i] = mys1[i].ToString();
                if (my1[i] != "1" && my1[i] != "0" )
                {
                    label2.Text = "You can enter only binary bits";
                    flag = true;
                    break;
                }

            }
         if(   flag == false)
            {
                int[] data = new int[mys1.Length + 10];

                for (i = 1, k = 0; k < mys1.Length; i++, k++)
                {
                    data[i] = Convert.ToInt16(my1[k]);

                }


                for (i = c; b < paritybits; i = c)
                {

                    for (k = c; k <= mys1.Length; k++)
                    {
                        C_Values[b] = C_Values[b] ^ data[k];
                        if (k % c == c - 1)
                        {
                            k += c;
                        }

                    }

                    if (C_Values[b] == 1)
                    {
                        a += i;
                    }
                    b++;
                    c = (c * 2);

                }
                if (a == 0)
                {
                    label2.Text = "All bits are correct";
                }
                else
                {
                    label2.Text = "Bit no. "+a.ToString() + " is incorrect";
                }
//if (mys1 == "")
                {
                   // label2.Text = "Please enter some binary bits";
                }
                if (textBox2.Text.Length != textBox3.Text.Length || mys1 == "")
                {
                    label2.Text = "Put recieved bits in the textbox";
                }
                
            }
        }
    }
}
