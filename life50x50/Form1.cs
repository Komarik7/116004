using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace life50x50
{
    public partial class Form1 : Form
    {
        private bool[,] gameboard = new bool[50, 50];
        private bool gamestarted = false;
        private int stage;
        private int changes;
        private int totalAlive;
        private Timer timer = new Timer();


        Pen myPen = new Pen(Color.Gray);
        Brush myBrush = new SolidBrush(Color.Black);
        Graphics g = null;

        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1000;
            menuStrip1.Items[1].Visible = false;
            PrepareGame();
        }

        private void PrepareGame()
        {

            stage = 1;
            totalAlive = 0;
            changes = 0;
            toolStripStatusLabel1.Text = "Поколение "+stage.ToString();
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                    gameboard[i, j] = false;


            gamestarted = false;

            panel1.Refresh();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepareGame();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            myPen.Width = 1;
            g = panel1.CreateGraphics();
            for (int i = 0; i<=1000; i = i+20)
            {
                g.DrawLine(myPen, i, 0, i, 1000);
                g.DrawLine(myPen, 0, i, 1000, i);
            }

            for (int i = 0; i<50; i++)
                for (int j = 0; j<50; j++)
                    if (gameboard [i, j])
                        g.FillEllipse(myBrush, i * 20, j * 20, 20, 20);

            
            
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gamestarted == false)
                if (gameboard[e.X / 20, e.Y / 20] == false)
                {
                    gameboard[e.X / 20, e.Y / 20] = true;
                    totalAlive++;
                    panel1.Refresh();
                }

        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamestarted = true;
            menuStrip1.Items[0].Visible = false;
            menuStrip1.Items[1].Visible = true;
            menuStrip1.Items[2].Enabled = false;
            timer.Start();
        }

        private void TimerEventProcessor(Object o, EventArgs e)
        {
            timer.Stop();
            gameMove();

            stage++;
            toolStripStatusLabel1.Text = "Поколение " + stage.ToString();
            panel1.Refresh();

            if (changes == 0 | totalAlive == 0)
            {
                MessageBox.Show("Игра окончена");
                gamestarted = false;
                menuStrip1.Items[0].Visible = true;
                menuStrip1.Items[1].Visible = false;
                menuStrip1.Items[2].Enabled = true;
            }
            else
                timer.Enabled = true;          

        }

        private void gameMove()
        {
            changes = 0;
            if (totalAlive > 0)
            {
                int total = 0;
                bool[,] nextState = new bool[50, 50];

                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        int cur = checkNearest(i, j);
                        if (gameboard[i, j] == false)
                        {
                            nextState[i, j] = false;
                            if  (cur == 3)
                            {
                                nextState[i, j] = true;
                                total++;
                                changes++;
                            }
                        }
                        else
                        {
                            nextState[i, j] = true;
                            total++;
                            if (cur < 2 ^ cur > 3)
                            {
                                nextState[i, j] = false;
                                changes++;
                                total--;
                            }
                        }

                    }
                }

                gameboard = nextState;
                totalAlive = total;
            }            
        }

        private int checkNearest(int i, int j)
        {
            int total = 0;
            int top = i == 0 ? 49 : i - 1;
            int bot = i == 49 ? 0 : i + 1;
            int left = j == 0 ? 49 : j - 1;
            int right = j == 49 ? 0 : j + 1;

            if (gameboard[top, left]) { total++; }
            if (gameboard[top, j]) { total++; }
            if (gameboard[top, right]) { total++; }
            if (gameboard[i, left]) { total++; }
            if (gameboard[i, right]) { total++; }
            if (gameboard[bot, left]) == true) { total++; }
            if (gameboard[bot, j]) { total++; }
            if (gameboard[bot, right]) { total++; }


            return total;
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamestarted = false;
            timer.Stop();
            menuStrip1.Items[0].Visible = true;
            menuStrip1.Items[1].Visible = false;
            menuStrip1.Items[2].Enabled = true;
        }
    }
}
