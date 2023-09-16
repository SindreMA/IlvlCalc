using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace IlvlCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            { }
            else { e.Handled = e.KeyChar != (char)Keys.Back; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sHead = textBox1.Text.ToString();
                int Head = Convert.ToInt32(sHead);

                string sNeck = textBox2.Text.ToString();
                int Neck = Convert.ToInt32(sNeck);

                string sShoulder = textBox3.Text.ToString();
                int Shoulder = Convert.ToInt32(sShoulder);

                string sBack = textBox4.Text.ToString();
                int Back = Convert.ToInt32(sBack);

                string sChest = textBox11.Text.ToString();
                int Chest = Convert.ToInt32(sChest);

                string sWrist = textBox12.Text.ToString();
                int Wrist = Convert.ToInt32(sWrist);

                string sHands = textBox6.Text.ToString();
                int Hands = Convert.ToInt32(sHands);

                string sWaist = textBox7.Text.ToString();
                int Waist = Convert.ToInt32(sWaist);

                string sLegs = textBox8.Text.ToString();
                int Legs = Convert.ToInt32(sLegs);

                string sFeet = textBox9.Text.ToString();
                int Feet = Convert.ToInt32(sFeet);

                string sFinger = textBox13.Text.ToString();
                int Finger = Convert.ToInt32(sFinger);

                string sRing = textBox14.Text.ToString();
                int Ring = Convert.ToInt32(sRing);

                string sTrinket1 = textBox15.Text.ToString();
                int Trinket1 = Convert.ToInt32(sTrinket1);

                string sTrinket2 = textBox16.Text.ToString();
                int Trinket2 = Convert.ToInt32(sTrinket2);

                string sWeapon = textBox17.Text.ToString();
                int Weapon = Convert.ToInt32(sWeapon);
                int all = 16;
                int all2 = 15;



                if (string.IsNullOrWhiteSpace(textBox18.Text) == true)
                {
                    int sumint1 = (Head) + (Neck) + (Shoulder) + (Back) + (Chest) + (Wrist) + (Hands) + (Waist) + (Legs) + (Feet) + (Finger) + (Ring) + (Trinket1) + (Trinket2) + (Weapon);
                    int sumdev = (sumint1) / (all2);
                    string sum = sumdev.ToString();
                    label20.Text = sum;
                }
                else
                {
                    string sOffhand = textBox18.Text.ToString();
                    int Offhand = Convert.ToInt32(sOffhand);

                    int sumint1 = (Head) + (Neck) + (Shoulder) + (Back) + (Chest) + (Wrist) + (Hands) + (Waist) + (Legs) + (Feet) + (Finger) + (Ring) + (Trinket1) + (Trinket2) + (Weapon) + (Offhand);
                    int sumdev = (sumint1) / (all);
                    string sum = sumdev.ToString();
                    label20.Text = sum;
                }
            }
            catch
            {
            }

            try
            {

                Information info = new Information();
                info.Data1 = textBox1.Text;
                info.Data2 = textBox2.Text;
                info.Data3 = textBox3.Text;
                info.Data4 = textBox4.Text;
                info.Data5 = textBox11.Text;
                info.Data6 = textBox12.Text;
                info.Data7 = textBox17.Text;
                info.Data8 = textBox18.Text;
                info.Data9 = textBox6.Text;
                info.Data10 = textBox7.Text;
                info.Data11 = textBox8.Text;
                info.Data12 = textBox9.Text;
                info.Data13 = textBox13.Text;
                info.Data14 = textBox14.Text;
                info.Data15 = textBox15.Text;
                info.Data16 = textBox16.Text;
                SavveXML.Save(info, "data.xml");
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog oFD = new SaveFileDialog();
            oFD.InitialDirectory = @"c:\\";
            oFD.Filter = "Xml Files (*.xml)|*.xml";
            oFD.FilterIndex = 2;
            oFD.RestoreDirectory = true;
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Information info = new Information();
                    info.Data1 = textBox1.Text;
                    info.Data2 = textBox2.Text;
                    info.Data3 = textBox3.Text;
                    info.Data4 = textBox4.Text;
                    info.Data5 = textBox11.Text;
                    info.Data6 = textBox12.Text;
                    info.Data7 = textBox17.Text;
                    info.Data8 = textBox18.Text;
                    info.Data9 = textBox6.Text;
                    info.Data10 = textBox7.Text;
                    info.Data11 = textBox8.Text;
                    info.Data12 = textBox9.Text;
                    info.Data13 = textBox13.Text;
                    info.Data14 = textBox14.Text;
                    info.Data15 = textBox15.Text;
                    info.Data16 = textBox16.Text;
                    SavveXML.Save(info, oFD.FileName);
                }
                catch
                { }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                textBox1.Text = info.Data1;
                textBox2.Text = info.Data2;
                textBox3.Text = info.Data3;
                textBox4.Text = info.Data4;
                textBox11.Text = info.Data5;
                textBox12.Text = info.Data6;
                textBox17.Text = info.Data7;
                textBox18.Text = info.Data8;
                textBox6.Text = info.Data9;
                textBox7.Text = info.Data10;
                textBox8.Text = info.Data11;
                textBox9.Text = info.Data12;
                textBox13.Text = info.Data13;
                textBox14.Text = info.Data14;
                textBox15.Text = info.Data15;
                textBox16.Text = info.Data16;
                read.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"c\\";
            openFile.Filter = "Xml Files (*.xml)|*.xml";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Information));
                    FileStream read = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    Information info = (Information)xs.Deserialize(read);
                    textBox1.Text = info.Data1;
                    textBox2.Text = info.Data2;
                    textBox3.Text = info.Data3;
                    textBox4.Text = info.Data4;
                    textBox11.Text = info.Data5;
                    textBox12.Text = info.Data6;
                    textBox17.Text = info.Data7;
                    textBox18.Text = info.Data8;
                    textBox6.Text = info.Data9;
                    textBox7.Text = info.Data10;
                    textBox8.Text = info.Data11;
                    textBox9.Text = info.Data12;
                    textBox13.Text = info.Data13;
                    textBox14.Text = info.Data14;
                    textBox15.Text = info.Data15;
                    textBox16.Text = info.Data16;
                    read.Close();
                }
                catch { }
            }
        }
    }
}
