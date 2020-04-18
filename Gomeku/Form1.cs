﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomeku
{
    public partial class Form1 : Form
    {

        Board board = new Board();

        public Form1()
        {
            InitializeComponent();
        }

        // color of next piece
        private bool isBlack = true;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isBlack)
            {
                this.Controls.Add(new BlackPiece(e.X, e.Y));
                isBlack = false;
            }
            else
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y));
                isBlack = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}