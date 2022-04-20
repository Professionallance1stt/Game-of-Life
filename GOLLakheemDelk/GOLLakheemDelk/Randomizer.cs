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
    public partial class Randomizer : Form
    {
        LakheemDelkGOL tester = new LakheemDelkGOL();
        public Randomizer()
        {
            InitializeComponent();
            RandomValue.Value = Properties.Settings.Default.THESEED;
            
        }
        public int seeder 
        {

            get { return (int)RandomValue.Value; }
            set { RandomValue.Value = value; }
        
        }
        private void RandomValue_ValueChanged(object sender, EventArgs e)
        {
            seeder = (int)RandomValue.Value;
            tester.seeders = (int)RandomValue.Value;
        }

        private void Randomss_Click(object sender, EventArgs e)
        {
            Random yeah = new Random();
            seeder = yeah.Next(1000);
            RandomValue.Value = seeder;
        }

        private void Randomizer_FormClosed(object sender, FormClosedEventArgs e)
        {
          Properties.Settings.Default.THESEED = (int)RandomValue.Value;
        }
    }
}
