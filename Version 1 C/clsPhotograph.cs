using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

     [NonSerialized()]
     private static frmPhotograph _PhotographDialog;

        public float Width
        {
            get
            {
                return _Width;
            }

            set
            {
                _Width = value;
            }
        }

        public float Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }
        


        public override void EditDetails()
        {
            //where ever there is new used you will get an error once converted to singleton so you need to correct.
            //singleton does not need this code change too
            //frmPhtograph.Instance.SetDetails(this);
            if (_PhotographDialog == null)
                _PhotographDialog = new frmPhotograph();
            _PhotographDialog.SetDetails(this);
        }
    }
}
