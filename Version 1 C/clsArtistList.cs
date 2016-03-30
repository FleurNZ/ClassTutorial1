using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string fileName = "gallery3.xml";
        public void EditArtist(string prKey)
        {
            clsArtist lcArtist; // = new clsArtist(this);//this seems wrong.
            //clsArtist lcArtist;
            lcArtist = (clsArtist)this[prKey]; // not needed with generic collections.
            if (lcArtist != null)
                lcArtist.EditDetails();
            else
                MessageBox.Show("Sorry no artist by this _ArtistName");
        }
       
        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);
            try
            {
                if (lcArtist.ArtistName != "")//don't know what to do hear.
                {
                    Add(lcArtist.ArtistName, lcArtist);//don't know what to do hear.
                    MessageBox.Show("Artist added!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Duplicate Key!");
            }
        }
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public void Save()
        {
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =//Soap.SoapFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();//Soap.SoapFormatter();not valid with generics

                lcFormatter.Serialize(lcFileStream, this);//removed _ArtistList
                lcFileStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "File Save Error");
            }
        }

        // factory method
        public static clsArtistList Retrieve()//correct
        {

            clsArtistList lcArtistList;//added
            try
            {

                System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter = //System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(); //new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                //updateDisplay(); removed since there is now a factory method.
                lcFileStream.Close();
            }

            catch (Exception e)
            {
            
               //need to move to form using catch exception
                MessageBox.Show(e.Message, "File Retrieve Error");
                lcArtistList = new clsArtistList();///remember its l not one.
               
            }
            return lcArtistList;
        }
    }
}
