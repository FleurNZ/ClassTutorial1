using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    //change to sealed class step 3 singleton
    public partial class frmPainting : Version_1_C.frmWork
    {



        //change to private for singleton step one
        //private static readonly frmPhotograph Instance = new frmPhotograph;
        public frmPainting()
        {
            InitializeComponent();
        }
        public clsPainting lcWork;//I think this goes hear.
        //public clsPainting _Painting;
        //public virtual void SetDetails(string prName, DateTime prDate, decimal prValue,
        //                               float prWidth, float prHeight, string prType)
        //{
        //    base.SetDetails(prName, prDate, prValue);
        //    txtWidth.Text = Convert.ToString(prWidth);
        //    txtHeight.Text = Convert.ToString(prHeight);
        //    txtType.Text = prType;
        //}

        //public virtual void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue,
        //                               ref float prWidth, ref float prHeight, ref string prType)
        //{
        //    base.GetDetails(ref prName, ref prDate, ref prValue);
        //    prWidth = Convert.ToSingle(txtWidth.Text);
        //    prHeight = Convert.ToSingle(txtHeight.Text);
        //    prType = txtType.Text;
        //}

        protected override void updateForm()//allows the method to override work updateForm with specific painting data.
        {
            base.updateForm();
            if (txtWidth.Text != "" && txtHeight.Text != "" && txtType.Text != "")
            {
                txtWidth.Text = lcWork.Width.ToString();//txtWidth.Text = Convert.ToString(_Painting.Width);
                txtHeight.Text = lcWork.Height.ToString();//txtHeight.Text = Convert.ToString(_Painting.Height);
                txtType.Text = lcWork.Type;//_Painting.Type
            }
            
        }

        protected override void pushData()
        {
            base.pushData();
            if (txtWidth.Text != "" && txtHeight.Text != "" && txtType.Text != "")///should be able to simplify this...
            {
                clsPainting lcWork = (clsPainting)_Work;// _Painting.Width = Convert.ToSingle(txtWidth.Text);
                lcWork.Width = Single.Parse(txtWidth.Text);// _Painting.Height = Convert.ToSingle(txtHeight.Text);
                lcWork.Height = Single.Parse(txtHeight.Text);// _Painting.Type = txtType.Text;
                lcWork.Type = txtType.Text;
            }
            else
            {
                MessageBox.Show("Please enter the Width, Height and Type in order to save");

            }
        }

       
    }
}

