using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmPhotograph : Version_1_C.frmWork
    {

        public frmPhotograph()
        {
            initializeComponent();/// this may break things have changed to lowercase i
        }

        public clsPhotograph lcWork;//I think this goes hear.
        
        protected override void updateForm()//allows the method to override work updateForm with specific painting data.
        {
            base.updateForm();
            if (txtHeight.Text != "" && txtType.Text != "")
            { 
               
            txtHeight.Text = lcWork.Height.ToString();
            txtType.Text = lcWork.Type;

            }
        }

        protected override void pushData()
        {
            base.pushData();
            if (txtWidth.Text != "" && txtHeight.Text != "" && txtType.Text != "")
            {
                clsPainting lcWork = (clsPainting)_Work;
                lcWork.Width = Single.Parse(txtWidth.Text);
                lcWork.Height = Single.Parse(txtHeight.Text);
                lcWork.Type = txtType.Text;
            }
            else
            {
                MessageBox.Show("Please enter the Width, Height and Type in order to save");

            }
        }


    }
}

