using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmSculpture : Version_1_C.frmWork
    {

        
        public frmSculpture()
        {
            InitializeComponent();
        }

        public clsSculpture lcWork;//I think this goes hear.
      

        protected override void updateForm()//allows the method to override work updateForm with specific painting data.
        {
            base.updateForm();
            if (txtWeight.Text  != "" && txtMaterial.Text !="")///will need proper validation later ask Matthias about this.

            {
                txtWeight.Text = lcWork.Weight.ToString();
                txtMaterial.Text = lcWork.Material;
            }
            

        }

        protected override void pushData()
        {
            base.pushData();
            //is this a okay solution for now?
            if (txtWeight.Text != "" && txtMaterial.Text != "")
            {
                clsSculpture lcWork = (clsSculpture)_Work;
                lcWork.Weight = Single.Parse(txtWeight.Text);
                lcWork.Material = txtMaterial.Text;
            }

            else
            {
                MessageBox.Show("Please enter the Weight and Material in order to save");
                
            }

        }


    }
}

