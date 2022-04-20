using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLakheemDelk
{
    public partial class Options : Form
    {
        LakheemDelkGOL tester = new LakheemDelkGOL();
        public Options()
        {
            InitializeComponent();
            timesinterval = Properties.Settings.Default.InputTimeInterval;
            width = Properties.Settings.Default.InputUniverseSizewidth;
            height = Properties.Settings.Default.InputUniverseSizeHeight;
            
        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }
       
        //this controls the time Interval change
        public int timesinterval
        {
            get
           {
                return (int)TimeIntervald.Value;

            }
            set
            { 

                TimeIntervald.Value = value;
            }

        }
        //this controls the width change
        public int width
        {
            get
            {
                return (int)Widthd.Value;

            }
            set
            {

                Widthd.Value = value;
            }

        }
        //this controls the height change
        public int height
        {
            get
            {
                return (int)Heightd.Value;

            }
            set
            {

                Heightd.Value = value;
            }

        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.InputTimeInterval = timesinterval;

            Properties.Settings.Default.InputUniverseSizewidth = width;

            Properties.Settings.Default.InputUniverseSizeHeight = height;


            Properties.Settings.Default.Save();
        }
    }
}
