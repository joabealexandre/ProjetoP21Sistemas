using System.Collections.Generic;
using DAL;
using Models;

namespace Controller
{
    public class MorteController
    {
        private DALMorte morteDAL;

        public MorteController()
        {
            morteDAL = new DALMorte();
        }

        public void SalvarMorteNoBanco(Morte morte)
        {
            morteDAL.Save(morte);
        }

        public void SalvarMorteNoBanco(List<Morte> morte)
        {
            foreach (var item in morte)
            {
                SalvarMorteNoBanco(item);
            }
        }

    }
}
