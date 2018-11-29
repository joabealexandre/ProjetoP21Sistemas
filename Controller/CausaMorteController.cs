using Models;
using System;
using DAL;

namespace Controller
{
    public class CausaMorteController
    {
        public void SalvarEnumsBanco()
        {
            foreach (CausaMorte item in (CausaMorte[])Enum.GetValues(typeof(CausaMorte)))
            {
                DALCausaMorte DAL = new DALCausaMorte();
                DAL.Save(item);
            }
        }
    }
}
