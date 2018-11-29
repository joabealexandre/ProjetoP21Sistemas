using Models;
using System;

namespace Controller
{
    public class CausaMorteController
    {
        public void SalvarEnumsBanco()
        {
            foreach (CausaMorte item in (CausaMorte[])Enum.GetValues(typeof(CausaMorte)))
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
