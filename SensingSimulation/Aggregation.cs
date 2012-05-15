using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SensingSimulation
{
    public partial class Aggregation : Form
    {
        public string currentNodeName = "";

        //public Dictionary<string, UInt16> d16 = new Dictionary<string, UInt16>();
        public Dictionary<string, byte> d8 = new Dictionary<string, byte>();
        /*
        {
            // action indexes
            { "_null_action", 0 },
            { "_assign1", 1 },
            { "_assign2", 2 },
            { "_deliver", 4 },
            { "_messageIn", 5 },
            { "_gtr", 6 },
            { "_ngtr", 7 },
            { "_copyMessageIn", 8 },
            { "_forward", 9 },
            // aggregation states
            { "IDLE_STATE", 0 },
            { "ASSIGN_STATE", 1 },
            { "ASSIGN_TH", 2 },
            { "ASSIGN_CO", 3 },
            { "CHECK", 4 },
            { "SENDPAUSE", 5 },
            { "START_STATE", 6 },
            { "NEXT_STATE", 7 },
            // data names
            { "CONSUMPTION", 5 },
            { "THRESH", 	6 },
            { "GRAB", 7 },
            { "PAUSE", 8 },
            // variable indexes
            { "_DATANAME", 0 },
            { "_IN1", 1 },
            { "_IN2", 2 },
            { "_OUT1", 3 },
            { "_VAR1", 4 },
            { "_VAR2", 5 },
            { "_VAR3", 6 },
            { "_VAR4", 7 },
            { "_VAR5",  8 }
        };
        */

            

        
        
        
        
        public Aggregation()
        {
            InitializeComponent();
            //this.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            PopulateContextMenu();
            //foreach (KeyValuePair<string, int> p in d8)
            //{
            //    ToolStripItem t = this.contextMenuStrip1.Items.Add(p.Key);
            //    t.Click += new System.EventHandler(this.toolMenuItemClick);

            //    this.toolStripComboBox1.Items.Add(p.Key);

            //}


        }

        public void PopulateContextMenu()
        {
            this.contextMenuStrip1.Items.Clear();
            foreach (KeyValuePair<string, byte> p in d8)
            {
                //this.contextMenuStrip1.Items.
                ToolStripItem t = this.contextMenuStrip1.Items.Add(p.Key);
                t.Click += new System.EventHandler(this.toolMenuItemClick);

                this.toolStripComboBox1.Items.Add(p.Key);

            }
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            //toolStripComboBox1.SelectedItem.ToString();

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text += toolStripComboBox1.SelectedItem.ToString();

        }

        private void toolMenuItemClick(object sender, EventArgs e)
        {
            ToolStripItem t = sender as ToolStripItem;
            string stringToInsert = t.ToString() + "  ";
            int pos = this.textBox1.SelectionStart;
            this.textBox1.Text = this.textBox1.Text.Insert(pos, stringToInsert);
            pos += stringToInsert.Length;
            this.textBox1.SelectionStart = pos;
            this.textBox1.SelectionLength = 0;

        }

        private bool prepareFSM(ref byte[] outdata, ref byte outIndex, ref string ErrorMsg)
        {
            char[] x = null;
            string[] sub;
            sub = this.textBox1.Text.Split(x, StringSplitOptions.RemoveEmptyEntries);
            string state = "";
            for (int i = 0; i < sub.Count(); )
            {
                switch (sub[i])
                {
                    case ":inmsg":
                    case ":states":
                    case ":actions":
                    case ":datanames":
                        state = sub[i];
                        i++;
                        break;
                    case ":data":
                        outdata[2] = outIndex;
                        state = sub[i];
                        i++;
                        break;
                    case ":outmsg":
                        outdata[1] = outIndex;
                        state = sub[i];
                        i++;
                        break;
                    case ":transitions":
                        outdata[3] = outIndex;
                        state = sub[i];
                        i++;
                        break;
                    default:
                        switch (state)
                        {
                            case ":inmsg":
                            case ":outmsg":
                            case ":data":
                                byte position = outIndex;
                                if (d8.ContainsKey(sub[i + 1]))
                                {
                                    outdata[outIndex++] = d8[sub[i + 1]];
                                    outdata[outIndex++] = 0;
                                }
                                else
                                {
                                    ushort val;
                                    if (UInt16.TryParse(sub[i + 1], out val))
                                    {
                                        outdata[outIndex++] = (byte)(val & 0xFF);
                                        outdata[outIndex++] = (byte)(val >> 8);
                                    }
                                    else
                                    {
                                        ErrorMsg = sub[i + 1] + ": Undefined";
                                        return false;
                                    }
                                }
                                d8[sub[i]] = position;
                                i += 2;
                                break;
                            /*
                            case ":inmsg":
                            case ":outmsg":
                                if (d8.ContainsKey(sub[i + 1]))
                                {
                                    outdata[outIndex] = d8[sub[i + 1]];
                                }
                                else
                                {
                                    byte val;
                                    if (byte.TryParse(sub[i + 1], out val))
                                    {
                                        outdata[outIndex] = val;
                                    }
                                    else
                                    {
                                        ErrorMsg = sub[i + 1] + ": Undefined";
                                        return false;
                                    }
                                }
                                d8[sub[i]] = outIndex;
                                outIndex++;
                                i += 2;
                                break;
                            */
                            case ":states":
                            case ":actions":
                            case ":datanames":
                                {
                                    byte val;
                                    if (d8.ContainsKey(sub[i + 1]))
                                    {
                                        val = d8[sub[i + 1]];
                                    }
                                    else
                                    {
                                        if (!byte.TryParse(sub[i + 1], out val))
                                        {
                                            ErrorMsg = sub[i + 1] + ": Undefined";
                                            return false;
                                        }
                                    }
                                    d8[sub[i]] = val;
                                    i += 2;
                                }
                                break;
                            case ":transitions":
                                for (int count = 0; count < 5; count++)
                                {
                                    byte val;
                                    if (d8.ContainsKey(sub[i]))
                                    {
                                        outdata[outIndex++] = d8[sub[i++]];
                                    }
                                    else
                                    {
                                        if (byte.TryParse(sub[i++], out val))
                                        {
                                            outdata[outIndex++] = val;
                                        }
                                        else
                                        {
                                            ErrorMsg = sub[i - 1] + ": Undefined";
                                            return false;
                                        }
                                    }
                                }
                                //outdata[outIndex++] = d8[sub[i++]];
                                //outdata[outIndex++] = d8[sub[i++]];
                                //outdata[outIndex++] = d8[sub[i++]];
                                //outdata[outIndex++] = d8[sub[i++]];
                                //outdata[outIndex++] = d8[sub[i++]];
                                break;
                            default:
                                break;

                        }
                        break; // default in main switch
                } // main switch
            } // for loop

            outdata[0] = outIndex;

            return true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] outdata = new byte[200];
            byte outIndex = 4;
            string ErrorMsg = "";
            if (!prepareFSM(ref outdata, ref outIndex, ref ErrorMsg))
            {
                MessageBox.Show(ErrorMsg);
                return;
            }
            
            TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + currentNodeName + ".txt");
            wtr.WriteLine("14");
            for (int i = 0; i < outIndex; i++)
            {
                wtr.Write(outdata[i].ToString() + " ");
                //wtr.WriteLine(outdata[i].ToString());
                //wtr.WriteLine(i.ToString() + ":   " + outdata[i].ToString());
            }
            wtr.Close();

            //unsigned char packet[28] = {
            //28, 10, 12, 18, 5, 0, 6, 0, 7, 0, 8, 0, 44, 1, 255, 0, 232, 3, 0, 1, 4, 14, 1, 1, 2, 12, 16, 0
            //};




            //TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + currentNodeName + ".txt");
            //wtr.WriteLine("unsigned char packet[" + outdata[0].ToString() + "] = {");
            //wtr.Write(outdata[0].ToString());
            //for (int i = 1; i < outIndex; i++)
            //{
            //    wtr.Write(", ");
            //    wtr.Write(outdata[i].ToString());
            //}
            //wtr.WriteLine();
            //wtr.WriteLine("};");
            //wtr.Close();

            this.Close();





        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] outdata = new byte[200];
            byte outIndex = 4;
            string ErrorMsg = "";
            d8.Clear();
            if (!prepareFSM(ref outdata, ref outIndex, ref ErrorMsg))
            {
                MessageBox.Show(ErrorMsg);
                return;
            }

            this.PopulateContextMenu();


        }

    }
}





/*
??? size
??? out
??? data
??? trans
:inmsg
con CONSUMPTION
thr THRESHOLD
gra GRAB
:outmsg
pau PAUSE
:data
v1 999
v2 24
v3 0
v4 0
v5 0
blank 0
:states
s1 0
s2 1
s3 2
s4 3
:transitions
s1 messageIn gra blank s2
s2
 */




//UInt16 f = 1000;
//byte y = (byte)(f >> 8);
//byte z = (byte)(f & 0xFF);
//string ss = y.ToString() + " " + z.ToString();
//MessageBox.Show(ss);
//return;


//unsigned short u16;
//u16 = ((int)u8[0] << 8) | (int)u8[1];
//u8_b[0] = (char)(u16 >> 8);
//u8_b[1] = (char)(u16 & 0xFF);

//MessageBox.Show(yy);
