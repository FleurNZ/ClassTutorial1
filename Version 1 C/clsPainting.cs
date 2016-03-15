using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;


        [NonSerialized()]
        private static frmPainting _PaintDialog;//renamed
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
            if (_PaintDialog == null)
                _PaintDialog = new frmPainting();
            _PaintDialog.SetDetails(this);
            //if (paintDialog == null)
            //{
            //    paintDialog = new frmPainting();
            //}
            //paintDialog.SetDetails(Name, Date, Value, Width, Height, Type);
            //if(paintDialog.ShowDialog() == DialogResult.OK)
            //{
            //   paintDialog.GetDetails(ref Name, ref Date, ref Value, ref Width, ref Height, ref Type);
            //}
        }
    }
}
