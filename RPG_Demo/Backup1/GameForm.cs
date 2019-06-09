using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Axiom.Math;
using RolePlayingGame.GuiDANCE;

namespace RolePlayingGame
{
    public partial class GameForm : Form
    {
        public GuiRenderBox RenderBox
        {
            get { return renderBox; }
            set { renderBox = value; }
        }

        public GameForm()
        {
            InitializeComponent();
        }

        //private Input input;
        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //    input = new Input(this);
        //}

        //protected override void OnClick(EventArgs e)
        //{
        //    base.OnClick(e);
        //}

        //protected override void OnKeyDown(KeyEventArgs e)
        //{
        //    base.OnKeyDown(e);
        //    if (input != null && input.IsKeyPressed(Input.Keys.X))
        //    {
        //        System.Diagnostics.Debug.WriteLine("X Pressed");
        //    }
        //}
    }
}
