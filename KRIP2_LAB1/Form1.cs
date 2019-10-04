using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;


namespace KRIP2_LAB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BigInteger a = BigInteger.Parse(textBox3.Text), p = BigInteger.Parse(textBox1.Text), x = BigInteger.Parse(textBox2.Text);
            //       double divider = 2;
          //  double x = Double.Parse(textBox2.Text);

          //  char[] strArr = String_a.ToCharArray();
     //       StringBuilder sb = new StringBuilder();


            string BinaryValue = null;
            BigInteger x1 = 0;
            while (x > 0)
            {
                
                x1 = x % 2;
                if (x == 0)
                    break;
                BinaryValue = BinaryValue + x1.ToString();
                x /= 2;
            //    x = Math.Truncate(x);
            }
           
            int n = BinaryValue.Length;

            BigInteger y = 1, s = a;
            for(int i = 0; i < n; i++)
            {
                if(BinaryValue[i] == '1')
                {
                    y = (y * s) % p;
                }
                s = (s % p * s % p) % p;
            }      
                textBox8.Text = y.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BigInteger a = BigInteger.Parse(textBox5.Text);
            BigInteger b = BigInteger.Parse(textBox4.Text);
            BigInteger ost = 0, ost_2 = 0, mul = 1, a1 = 0, b1 = 0;
            if (b < a)
            {
                ost = a; ost_2 = 0; mul = 1; a1 = a; b1 = b;
            }
            else
            {
                ost = b; ost_2 = 0; mul = 1; a1 = b; b1 = a;
            }
                while (ost != 0)
            {
                mul = 1;
                if (b1 * 2 < a1)
                {
                    mul = 2;
                    for (int i = 3; ; i++)
                    {
                        if(b1 * i < a1)
                        {
                            mul = i;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                ost_2 = ost;
                ost = a1 - b1 * mul;
                a1 = b1;
                b1 = ost;
            }

            textBox9.Text = ost_2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BigInteger[] U = new BigInteger[2];
            BigInteger[] V = new BigInteger[2];
            BigInteger[] T = new BigInteger[2];
            BigInteger q = 0;
            BigInteger a = BigInteger.Parse(textBox6.Text);
            BigInteger b = BigInteger.Parse(textBox7.Text);
            BigInteger ost = 0, ost_2 = 0, mul = 0, a1 = 0, b1 = 0;
            if (a > b)
            {
                U[0] = a;
                U[1] = 0;
                V[0] = b;
                V[1] = 1;
                ost = a; ost_2 = 0; mul = 1; a1 = a; b1 = b;
            }
            else
            {
                U[0] = b;
                U[1] = 0;
                V[0] = a;
                V[1] = 1;
                ost = b; ost_2 = 0; mul = 1; a1 = b; b1 = a;
            }
            
            while (ost != 0)
            {
                mul = 1;
                if (b1 * 2 < a1)
                {
                    mul = 2;
                    for (int i = 3; ; i++)
                    {
                        if (b1 * i < a1)
                        {
                            mul = i;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                ost_2 = ost;
                ost = a1 - b1 * mul;
                a1 = b1;
                b1 = ost;
            }

            if(ost_2 != 1)
            {
                textBox10.Text = "Числа не взаимно простые";
            }
            else
            {
                BigInteger inversion = 0;
                while (V[0] != 0)
                {
                    inversion = T[1];
                    q = U[0] / V[0];
                    T[0] = U[0] % V[0];
                    T[1] = U[1] - q * V[1];
                    U[0] = V[0];
                    U[1] = V[1];
                    V[0] = T[0];
                    V[1] = T[1];
                }
                if (inversion < 0)
                    inversion += a;
                textBox10.Text = inversion.ToString();
            }
        }
    }
}
