using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Двоичный_поиск_массива
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] k;

        private void clear_Click(object sender, EventArgs e)
        {
            vv_n.Text = "";
            nayti.Text = "";
            pozitsiya2.Text = "";
            pozitsiya3.Text = "";
            kol_iter2.Text = "";
            kol_iter3.Text = "";
            vaqt1.Text = "";
            vaqt2.Text = "";
            massiv.Items.Clear();
        }

        private void create_array_Click(object sender, EventArgs e)
        {
            if (vv_n.Text != "")
            {
                massiv.Items.Clear();
                k = new int[Convert.ToInt32(vv_n.Text) + 1];
                for (int i = 0; i < k.Length; i++)
                    k[i] = i*4;

                if (Convert.ToInt32(vv_n.Text) <= 1000)
                {
                    for (int i = 0; i < k.Length - 1; i++)
                        massiv.Items.Insert(i, k[i + 1]);
                }

            }
        }

        private void start_1_Click(object sender, EventArgs e)
        {
            if (nayti.Text != "")
            {

                double st1 = Convert.ToDouble(DateTime.Now.ToString("ss,ffff"));
                int nnnnn = Convert.ToInt32(nayti.Text), a = 1, b = Convert.ToInt32(vv_n.Text), x = Convert.ToInt32(Math.Ceiling(b / 2.0)), o = 0;
                while (true)
                {
                    o++;
                    if (k[x] == nnnnn)
                    {
                        pozitsiya2.Text = "" + x;
                        kol_iter2.Text = "" + o;
                        break;
                    }
                    else
                    {
                        if (nnnnn > k[x])
                        {
                            if (nnnnn < k[x + 1])
                            {
                                pozitsiya2.Text = "Hе найдено";
                                kol_iter2.Text = "" + o;
                                break;
                            }
                            a = x;
                            x += Convert.ToInt32(Math.Ceiling((b - a) / 2.0));
                        }
                        else
                        {
                            if (nnnnn > k[x + 1])
                            {
                                pozitsiya2.Text = "Hе найдено";
                                kol_iter2.Text = "" + o;
                                break;
                            }
                            b = x;
                            x -= Convert.ToInt32(Math.Ceiling((b - a) / 2.0));
                        }
                    }
                    if (a == b)
                    {
                        pozitsiya2.Text = "Hе найдено";
                        kol_iter2.Text = "" + o;
                        break;
                    }
                }
                vaqt1.Text = Convert.ToString(Convert.ToDouble(DateTime.Now.ToString("ss,ffff")) - st1);
            }
        }

        private void start_2_Click(object sender, EventArgs e)
        {
            if (nayti.Text != "")
            {
                double st2 = Convert.ToDouble(DateTime.Now.ToString("ss,ffff"));
                int nnnnn = Convert.ToInt32(nayti.Text);
                int d = Convert.ToInt32(vv_n.Text);
                int a = 1, b = Convert.ToInt32(Math.Ceiling(d / 3.0));
                int c = Convert.ToInt32(Math.Ceiling(d / 3.0 * 2));
                int o = 0;
                while (true)
                {
                    o++;
                    if (k[b] == nnnnn)
                    {
                        pozitsiya3.Text = "" + b;
                        kol_iter3.Text = "" + o;
                        break;
                    }
                    else if (k[c] == nnnnn)
                    {
                        pozitsiya3.Text = "" + c;
                        kol_iter3.Text = "" + o;
                        break;
                    }
                    else
                    {
                        if (nnnnn < k[b])
                        {
                            if (nnnnn > k[b - 1])
                            {
                                pozitsiya3.Text = "Hе найдено";
                                kol_iter3.Text = "" + o;
                                break;
                            }
                            d = 0 + b;
                            b = a + Convert.ToInt32(Math.Ceiling((d - a) / 3.0));
                            c = a + Convert.ToInt32(Math.Ceiling((d - a) / 3.0 * 2));
                        }
                        else if (nnnnn > k[b] && nnnnn < k[c])
                        {
                            if (nnnnn < k[b + 1] || nnnnn > k[c - 1])
                            {
                                pozitsiya3.Text = "Hе найдено";
                                kol_iter3.Text = "" + o;
                                break;
                            }
                            a = 0 + b;
                            d = 0 + c;
                            b = a + Convert.ToInt32(Math.Ceiling((d - a) / 3.0));
                            c = a + Convert.ToInt32(Math.Ceiling((d - a) / 3.0 * 2));
                        }
                        else if (k[c] < nnnnn)
                        {
                            if (nnnnn < k[c + 1])
                            {
                                pozitsiya3.Text = "Hе найдено";
                                kol_iter3.Text = "" + o;
                                break;
                            }
                            a = 0 + c;
                            b = a + Convert.ToInt32(Math.Ceiling((d - a) / 3.0));
                            c = a + Convert.ToInt32(Math.Ceiling((d - a) / 3.0 * 2));
                        }
                    }
                }
                vaqt2.Text = Convert.ToString(Convert.ToDouble(DateTime.Now.ToString("ss,ffff")) - st2);
            }
        }
    }
}