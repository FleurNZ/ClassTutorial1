using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsDateComparer : IComparer<clsWork>
    {
        //public int Compare(Object x, Object y)
        public int Compare(clsWork x, clsWork y)
        {
            //clsWork lcWorkX = (clsWork)x;
            //clsWork lcWorkY = (clsWork)y;
            //DateTime lcDateX = lcWorkX.Date;
            //DateTime lcDateY = lcWorkY.Date;
            DateTime lcDateX = x.Date;
            DateTime lcDateY = y.Date;
            // this line below appears by itself
            return lcDateX.CompareTo(lcDateY);
        }
    }
}
