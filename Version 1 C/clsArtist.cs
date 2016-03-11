using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _ArtistName;
        private string _Speciality;
        private string _Phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;

        private clsArtistList _ArtistList;// should need this but _ArtistList errors elsewhere in clsArtist if commented out 
        
        private static frmArtist _ArtistDialog = new frmArtist();

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }

        public string ArtistName
        {
            get
            {
                return _ArtistName;//should this just be Name??
            }

            set
            {
                _ArtistName = value;
            }
        }

        public string Speciality
        {
            get
            {
                return _Speciality;
            }

            set
            {
                _Speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return _TotalValue;
            }

           
        }

        public clsWorksList WorksList
        {
            get
            {
                return _WorksList;
            }

           
        }

        public clsArtistList ArtistList
        {
            get
            {
                return _ArtistList;
            }

        }

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();//errors after creating properies and removing set option.
            _ArtistList = prArtistList;// is this how they should be named?
            EditDetails();
        }
        
        public void EditDetails()
        {
            _ArtistDialog.SetDetails(this);//(clsArtist)this[prkey]what do I do with this hear?
            if (_ArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                _TotalValue = WorksList.GetTotalValue();
            }
        }

        //public string GetKey()
        //{
        //    return ArtistName;
        //}

        //public decimal GetWorksValue()
        //{
        //    return TotalValue;
        //}
    }
}
