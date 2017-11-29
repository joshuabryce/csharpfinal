using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        bool jumping = false;
        int pipeSpeed = 10;
        int gravity = 5;
        int Inscore = 0;
        bool gameStopped = false;

        public Form1()
        {
            InitializeComponent();
            endText1.Text = "Game over!";
            endText2.Text = "your final score is: " + Inscore;
            gameDesigner.Text = "game designed by josh";
            endText1.Visible = false;
            endText2.Visible = false;
            gameDesigner.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;
            scoreText.Text = "" + Inscore;

            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 500;
                Inscore += 1;
            }
            else if(pipeTop.Left < -95){
                pipeTop.Left = 600;
                Inscore += 1;
            }
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }
        }

        private void inGameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
                gravity = -25;
            }
            if (e.KeyCode == Keys.Space && gameStopped == true)
            {
                timer1.Start();
                endText1.Visible = false;
                endText2.Visible = false;
                gameDesigner.Visible = false;
                gameStopped = false;

                flappyBird.Location = new Point(21, 271);
                pipeTop.Location = new Point(304, -3);
                pipeBottom.Location = new Point(304, 320);

                //21, 271
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                jumping = false;
                gravity = 10;
            }
        }

        private void endGame()
        {
            timer1.Stop();
            endText1.Visible = true;
            endText2.Visible = true;
            gameDesigner.Visible = true;
            gameStopped = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
