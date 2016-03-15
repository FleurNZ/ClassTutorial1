using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmWork : Form
    {

        public frmWork()
        {
            InitializeComponent();/// have not changed to see what happens...
        }

        protected clsWork _Work;
        //public void SetDetails(string prName, DateTime prDate, decimal prValue)
        //{
        //    txtName.Text = prName;
        //    txtCreation.Text = prDate.ToShortDateString();
        //    txtValue.Text = Convert.ToString(prValue);
        //}

        //public void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue)
        //{
        //    prName = txtName.Text;
        //    prDate = Convert.ToDateTime(txtCreation.Text);
        //    prValue = Convert.ToDecimal(txtValue.Text);
        //}

        protected virtual void updateForm()//maybe clswork and par hear and above??
        {
            txtName.Text = _Work.Name;
            txtCreation.Text = _Work.Date.ToShortDateString();
            txtValue.Text = _Work.Value.ToString();//Convert.ToString(_Work.Value);
        }
        //virtual so that the derived forms can override them and protected so that the can be used by the derived forms.
        protected virtual void pushData()///maybe clswork and par hear and above??
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtCreation.Text);//Convert.ToDateTime(txtCreation.Text)
            _Work.Value = Decimal.Parse(txtValue.Text);//same done hear as above.
        }

        public void SetDetails(clsWork prWork)//should this be lowercase s 
        {
            _Work = prWork;
            updateForm();
            ShowDialog();


        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                pushData();
                Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        public virtual bool isValid()
        {
            return true;
        }
    
    }
}