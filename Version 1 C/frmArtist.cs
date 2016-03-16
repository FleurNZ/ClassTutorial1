using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        //private clsArtistList _ArtistList;
        private clsWorksList _WorksList;
        private byte sortOrder; // 0 = Name, 1 = Date maybe this should be _SortOrder...
        //clsWorksList _SortOrder;// not sure if this is right.
        private  clsArtist _Artist;//is this meant to be clsartist?

       
        private void updateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (sortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        public void updateForm()
        {
            txtName.Text = _Artist.ArtistName;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            //_ArtistList = _Artist.ArtistList;
            _WorksList = _Artist.WorksList;
             sortOrder = _WorksList.SortOrder;////this does not make sense...sortOrder instead of _SortOrder
        }

        public void pushData()
        {
            _Artist.ArtistName = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
            sortOrder = _WorksList.SortOrder;////this does not make sense...sortOrder instead of _SortOrder should this still be hear..
            //DialogResult = DialogResult.OK;//nto sure if this should be hear..
        }

        public void SetDetails(clsArtist prArtist)///issue with the values within Artistlist relating to the specific artist not been transfered to _Artist.
        {
            _Artist = prArtist;
            updateForm();
            updateDisplay();
            ShowDialog();
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _WorksList.DeleteWork(lstWorks.SelectedIndex);
            updateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
            updateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();//something wrong having to hit close twice for a new artist to be added.
                DialogResult = DialogResult.OK;//first time through result is 1 second time through result is OK???? so shuts.
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that _ArtistName already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _WorksList.EditWork(lcIndex);
                updateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            sortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

    }
}