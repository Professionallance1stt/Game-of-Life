using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOLLakheemDelk
{
    public partial class LakheemDelkGOL : Form
    {
        //Everything Works but for whatever reason for it to display you have to hit next do not know the fix :( 
        public LakheemDelkGOL()
        {
            InitializeComponent();

            #region settings Code
            //Reading Property 
            graphicsPanel1.BackColor = Properties.Settings.Default.InputBackColor1;
            torodialToolStripMenuItem.Checked = Properties.Settings.Default.InputGridFormation;
            gridToolStripMenuItem1.Checked = Properties.Settings.Default.InputGridOutline;
            gridToolStripMenuItem.Checked = Properties.Settings.Default.InputGridOutline;
            cellColor = Properties.Settings.Default.InputCellColor;
            timer.Interval = Properties.Settings.Default.InputTimeInterval;
            width = Properties.Settings.Default.InputUniverseSizewidth;
            height = Properties.Settings.Default.InputUniverseSizeHeight;
            seeders = Properties.Settings.Default.THESEED;
            #endregion

            // Setup the timer
            // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
            graphicsPanel1.Invalidate();
        }
        
        public int gettime() 
        {
            int times;
            times = timer.Interval;
            return times;
        }
            
        #region This is the defaults of the GOL
        //Getting Todays date for the save function

        DateTime thisDay = DateTime.Today;

        #region neighbor counting methods
        private int CountNeighborsToroidal(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffest = -1; yOffest <= 1; yOffest++)
            {
                for (int xOffest = -1; xOffest <= 1; xOffest++)
                {
                    int xCheck = x + xOffest;
                    int yCheck = y + yOffest;

                    if (xOffest == 0 && yOffest == 0)
                    {
                        continue;
                    }
                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }
                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;
                    }
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }


                    if (universe[xCheck, yCheck] == true)
                    {
                        count++;
                    }


                }
            }



            return count;
        }

        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0;
            int xLen = universe.GetLength(0);
            int yLen = universe.GetLength(1);
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    if (xCheck < 0)
                    {
                        continue;
                    }
                    if (yCheck < 0)
                    {
                        continue;
                    }
                    if (xCheck >= xLen)
                    {
                        continue;
                    }
                    if (yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }
        #endregion


        public int width;
        public int height;
        public int seeders;
        


        // The universe array
        bool[,] universe = new bool[5, 5];
        //I can just add a public int for width and height 
        //bool[,] scratch = new bool[5, 5];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();


        // Generation count
        int generations = 0;

        //Count the amount of live Cells
        private void HUDs()
        {

            //Creating the HUD Display
            StringBuilder huds = new StringBuilder();
            huds.Append("Generations = " + generations.ToString());
            huds.Append("\nCells Alive = " + liveCellsCount());
            huds.Append("\n Dimensions of the Universe: " + width + " X " + height);
            if (torodialToolStripMenuItem.Checked)
            {
                huds.Append("\nThe current calculation is Toroidal");
            }
            else if (finiteToolStripMenuItem.Checked)
            {

                huds.Append("\nThe current calculation is finite");
            }
            if (hUDToolStripMenuItem.Checked || hUDToolStripMenuItem1.Checked)
            {
                HUD.Visible = true;
                HUD.Text = huds.ToString().Replace(Environment.NewLine, "<br />");
                HUD.Refresh();
            }
            else if (!(hUDToolStripMenuItem.Checked))
            {
                HUD.Visible = false;
                HUD.Refresh();

            }


        }
        private int liveCellsCount()
        {
            int cellsCount = 0;
            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    if (universe[x, y] == true)
                    {
                        cellsCount++;
                    }
                }
            }

            return cellsCount;
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            HUD.Refresh();

            // Increment generation count
            generations++;
            //realized i could not but in the above scratchpad so I put it down here.
            bool[,] scratchy = new bool[width, height];

            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {

                    int count = 0;
                    if (torodialToolStripMenuItem.Checked)
                    {
                        count = CountNeighborsToroidal(x, y);

                    }
                    else if (finiteToolStripMenuItem.Checked)
                    {
                        count = CountNeighborsFinite(x, y);

                    }

                    if (universe[x, y])
                    {
                        if (count == 2 || count == 3)
                        {
                            scratchy[x, y] = true;
                        }
                        if (count < 2 || count > 3)
                        {
                            scratchy[x, y] = false;
                        }
                    }
                    else
                    {
                        if (count == 3)
                        {
                            scratchy[x, y] = true;
                        }
                    }
                }
            }
            bool[,] temp = universe;
            universe = scratchy;
            scratchy = temp;


            // Update status strip generations
            toolStripStatusLabel1.Text = "Generations = " + generations.ToString();
            toolCellsAlive.Text = "Cells Alive = " + liveCellsCount();
            toolstime.Text = "Time Interval = " + timer.Interval;
            labelSeeds.Text = "Seed: " + seeders;
            graphicsPanel1.Invalidate();
            HUDs();

        }



        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
            HUD.Refresh();
            HUDs();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;  //The neighbor Counter
                    Font font = new Font("Arial", 20f);

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;


                    //this counts the neighbors
                    int neighbors = 0;

                    if (torodialToolStripMenuItem.Checked)
                    {
                        neighbors = CountNeighborsToroidal(x, y);

                    }
                    else if (finiteToolStripMenuItem.Checked)
                    {
                        neighbors = CountNeighborsFinite(x, y);

                    }
                    if (neighborCountToolStripMenuItem.Checked || neighborCountToolStripMenuItem1.Checked)
                    {
                        e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Black, cellRect, stringFormat);

                    }
                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                        if (neighborCountToolStripMenuItem.Checked || neighborCountToolStripMenuItem1.Checked)
                        {
                            e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Black, cellRect, stringFormat);

                        }
                    }


                    // Outline the cell with a pen
                    if (gridToolStripMenuItem.Checked || gridToolStripMenuItem1.Checked)
                    {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

                    }




                }
            }


            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
            HUDs();
        }


        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {


            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];



                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
            toolCellsAlive.Text = "Cells Alive = " + liveCellsCount();
            HUDs();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region simple commands such as play and new
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Makes a blank space of the area
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;
            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
                graphicsPanel1.Invalidate();
            }
            generations = generations - generations;
            toolStripStatusLabel1.Text = "Generations = " + generations.ToString();
        }

        //Starts the timer and thus the next generations
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Start();
            timer.Enabled = true;
        }

        //Creates a pause function
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;
        }

        //Controls the next function
        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Enabled = false;
            NextGeneration();
        }

        private void checker()
        {
            if (!(hUDToolStripMenuItem.Checked) || !(hUDToolStripMenuItem1.Checked))
            {
                hUDToolStripMenuItem1.Checked = false;
                hUDToolStripMenuItem.Checked = false;

            }

            if (!(gridToolStripMenuItem.Checked) || !(gridToolStripMenuItem1.Checked))
            {
                gridToolStripMenuItem1.Checked = false;
                gridToolStripMenuItem.Checked = false;

            }

            if (!(neighborCountToolStripMenuItem.Checked) || !(neighborCountToolStripMenuItem1.Checked))
            {
                neighborCountToolStripMenuItem1.Checked = false;
                neighborCountToolStripMenuItem.Checked = false;

            }

        }
        #endregion

        #region Randomizer functions
        //randomize from seed
        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Randomizer gig = new Randomizer();
            seeders  = gig.seeder;
            Random checkers = new Random(seeders);
            if (DialogResult.OK == gig.ShowDialog())
            {
               
                bool[,] scratchy = new bool[width, height];
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        int testing = checkers.Next(0, 2);
                        if (testing == 0)
                        {
                            scratchy[x, y] = true;
                        }
                        else
                        {
                            scratchy[x, y] = false;
                        }
                    }
                }
                bool[,] temp = universe;
                universe = scratchy;
                scratchy = temp;
                seeders  = gig.seeder;
                graphicsPanel1.Invalidate();
            }
        }
        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random checkers = new Random();
         
            bool[,] scratchy = new bool[width, height];
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int testing = checkers.Next(0, 2);
                    if (testing == 0)
                    {
                        scratchy[x, y] = true;
                    }
                    else
                    {
                        scratchy[x, y] = false;
                    }
                }
            }
            bool[,] temp = universe;
            universe = scratchy;
            scratchy = temp;
            graphicsPanel1.Invalidate();
        }
        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Random checkers = new Random(seeders);
          
            bool[,] scratchy = new bool[width, height];
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    int testing = checkers.Next(0, 2);
                    if (testing == 0)
                    {
                        scratchy[x, y] = true;
                    }
                    else
                    {
                        scratchy[x, y] = false;
                    }
                }
            }
            bool[,] temp = universe;
            universe = scratchy;
            scratchy = temp;
            graphicsPanel1.Invalidate();
        }
        #endregion

        #region file tool strip methods
        //Same as save tool
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files| *.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
                writer.WriteLine("!The date that this was saved on was: " + thisDay);
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    string currentRow = string.Empty;
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                        }
                        else
                        {
                            currentRow += '.';
                        }
                        writer.WriteLine(currentRow);
                    }
                }
                writer.Close();
            }


        }

        //save as tool
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files| *.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
                writer.WriteLine("!The date that this was saved on was: " + thisDay);
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    string currentRow = string.Empty;
                    for (int y = 0; y < universe.GetLength(1); y++)
                    {
                        if (universe[x, y] == true)
                        {
                            currentRow += 'O';
                        }
                        else
                        {
                            currentRow += '.';
                        }

                    }
                    writer.WriteLine(currentRow);
                }
                writer.Close();
            }


        }

        // Open tool
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);
                int maxWidth = 0;
                int maxHeight = 0;
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    if (row.Contains("!") == true)
                    {
                        continue;
                    }
                    maxHeight++;
                    maxWidth = row.Length;
                }
                // this is to make sure that the thing does not trip out when doing it, also resets the different arrays
                universe = new bool[maxWidth, maxHeight];
                width = maxWidth;
                height = maxHeight;
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                int yse = 0;
                while (!reader.EndOfStream)
                {
                    // Takes care of the height issue


                    string row = reader.ReadLine();
                    if (row.Contains("!") == true)
                    {
                        continue;
                    }
                    for (int xPos = 0; xPos < row.Length; xPos++)
                    {
                        if (row[xPos] == 'O')
                        {
                            universe[xPos, yse] = true;
                        }
                        else if (row[xPos] == '.')
                        {
                            universe[xPos, yse] = false;
                        }


                    }
                    yse++;
                }

                //Extra security when updating the new array


                graphicsPanel1.Invalidate();
                reader.Close();
            }


        }
        #endregion

        #region Controls Colors
        //Controls the grid background color
        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();


        }

        //Cell Color changer
        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }
        #endregion

        #region options method
        //Options setter
        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Options dlg = new Options();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                universe = new bool[dlg.width, dlg.height];
                width = dlg.width;
                height = dlg.height;
                timer.Interval = dlg.timesinterval;
            }
            graphicsPanel1.Invalidate();
        }
        #endregion

        #region bonus conditions of checkers
        //Make sure toroidal is unchecnked
        private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            torodialToolStripMenuItem.Checked = false;

        }

        //Make sure the finite is unchecked
        private void torodialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            finiteToolStripMenuItem.Checked = false;
        }

        private void hUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hUDToolStripMenuItem1.Checked = true;
            checker();
        }

        private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            neighborCountToolStripMenuItem1.Checked = true;
            checker();
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            neighborCountToolStripMenuItem1.Checked = true;
            checker();
        }

        private void hUDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            hUDToolStripMenuItem.Checked = true;
            checker();
        }

        private void gridToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridToolStripMenuItem.Checked = true;
            checker();
        }

        private void neighborCountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            neighborCountToolStripMenuItem.Checked = true;
            checker();
        }

        #endregion


        #region settings code

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsPanel1.BackColor = Properties.Settings.Default.InputBackColor1;

            torodialToolStripMenuItem.Checked = Properties.Settings.Default.InputGridFormation;



            gridToolStripMenuItem1.Checked = Properties.Settings.Default.InputGridOutline;

            gridToolStripMenuItem.Checked = Properties.Settings.Default.InputGridOutline;

            cellColor = Properties.Settings.Default.InputCellColor;

            timer.Interval = Properties.Settings.Default.InputTimeInterval;

            width = Properties.Settings.Default.InputUniverseSizewidth;

            height = Properties.Settings.Default.InputUniverseSizeHeight;
        }
        private void Defaults_Click(object sender, EventArgs e)
        {
            graphicsPanel1.BackColor = Properties.Settings.Default.BackColor1;

            torodialToolStripMenuItem.Checked = Properties.Settings.Default.GridFormation;

            gridToolStripMenuItem1.Checked = Properties.Settings.Default.GridOutline;

            gridToolStripMenuItem.Checked = Properties.Settings.Default.GridOutline;

            cellColor = Properties.Settings.Default.CellColor;

            timer.Interval = Properties.Settings.Default.TimeInterval;

            width = Properties.Settings.Default.UniverseSizewidth;

            height = Properties.Settings.Default.UniverseSizeHeight;
        }
        private void LakheemDelkGOL_FormClosed(object sender, FormClosedEventArgs e)
        {//Update Property
            Properties.Settings.Default.InputBackColor1 = graphicsPanel1.BackColor;

            Properties.Settings.Default.InputGridOutline = gridToolStripMenuItem1.Checked;

            Properties.Settings.Default.InputCellColor = cellColor;

            Properties.Settings.Default.InputTimeInterval = timer.Interval;

            Properties.Settings.Default.InputUniverseSizewidth = width;

            Properties.Settings.Default.InputUniverseSizeHeight = height;

            Properties.Settings.Default.Save();

            Properties.Settings.Default.THESEED = seeders;
        }



        #endregion



        #region code that breaks the formation when I try to delete it 

        //if I delete this the form will make an error, not going to take a risk this far in
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void HUD_Click(object sender, EventArgs e)
        {

        }

        #endregion

        //Click through the label
        private void HUD_MouseDown(object sender, MouseEventArgs e)
        {
            graphicsPanel1_MouseClick(sender, e);
        }
    }
}
