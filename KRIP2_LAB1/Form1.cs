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
            double a = Double.Parse(textBox3.Text), x = Double.Parse(textBox2.Text), p = Double.Parse(textBox1.Text), rezult = 0;
            double divider = 2;
               
            List<double> div = new List<double>();
            while ((a % divider) == 0)
            {
                a = a / divider;
                div.Add(divider);
                //div[numb] = divider;
               // numb++;
            }

            divider = 3;
            int c = (int)Math.Sqrt(a) + 1;

            while(divider < c)
            {
                if ((a % divider) == 0)
                {
                    if (a / divider * divider - a == 0)
                    {
                        div.Add(divider);
                        // div[numb] = divider;
                        // numb++;
                        a = a / divider;
                        c = (int)Math.Sqrt(a) + 1;
                    }
                    else
                        divider += 2;
                }
                else
                    divider += 2;
            }

            div.Add(a);
            double mul = 1;
            int j = 0;
            for(int i = 0; i < div.Count; i++)
            {
                if (x % 2 == 0)
                {
                    for (j = 0; j < x; j += 2)
                    {
                        mul = (mul * Math.Pow(div[i], 2)) % p;
                    }
                }
                else
                {
                    for (j = 0; j < (x - 2); j += 2)
                    {
                        mul = (mul * Math.Pow(div[i], 2)) % p;
                    }
                    mul = (mul * div[i]) % p;
                }
                    
            }
                // rezult = Math.Pow(a, x) % p;          
                textBox8.Text = mul.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BigInteger a = BigInteger.Parse(textBox5.Text);
            BigInteger b = BigInteger.Parse(textBox4.Text);

            BigInteger ost = a, ost_2 = 0, mul = 1, a1 = a, b1 = b;
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
            U[0] = a;
            U[1] = 0;
            V[0] = b;
            V[1] = 1;

            BigInteger ost = a, ost_2 = 0, mul = 1, a1 = a, b1 = b;
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
