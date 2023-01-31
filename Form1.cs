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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool _moveLeft;
        private bool _moveRight;
        private bool _moveUp;
        private bool _moveDown;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "";

            _movementTimer.Tick += _movementTimer_Tick;
        }

        private void _movementTimer_Tick(object sender, EventArgs e)
        {
            _DoMovement();
        }

        private void _DoMovement()
        {
            if (_moveLeft) Player.MoveLeft(label1);
            if (_moveRight) Player.MoveRight(label1);
            if (_moveUp) Player.MoveUp(label1);
            if (_moveDown) Player.MoveDown(label1);
        }

        public void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled) return;
            //{
            //    // Ignore key repeats...let the timer handle that
            //    return;
            //}



            switch (e.KeyCode)
            {
                case Keys.Up:
                    _moveUp = true;
                    break;
                case Keys.Down:
                    _moveDown = true;
                    break;
                case Keys.Left:
                    _moveLeft = true;
                    break;
                case Keys.Right:
                    _moveRight = true;
                    break;
            }

            _DoMovement();
            _movementTimer.Start();
        }

        public void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _moveUp = false;
                    break;
                case Keys.Down:
                    _moveDown = false;
                    break;
                case Keys.Left:
                    _moveLeft = false;
                    break;
                case Keys.Right:
                    _moveRight = false;
                    break;
            }

            if (!(_moveUp || _moveDown || _moveLeft || _moveRight))
            {
                _movementTimer.Stop();
            }
        }

        private class Player
        {
            internal static void MoveDown(Label label1)
            {
                label1.Text = label1.Text + "0";
            }

            internal static void MoveLeft(Label label1)
            {
                label1.Text = label1.Text + "0";
            }

            internal static void MoveRight(Label label1)
            {
                label1.Text = label1.Text + "0";
            }

            internal static void MoveUp(Label label1)
            {
                label1.Text = label1.Text + "0";
            }
        }
    }
}
