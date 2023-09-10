using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public class Paginate<T>
    {
        public Paginate()
        {
            
        }

        public int Size { get; set; }//data sayısı
        public int Index { get; set; }//hangi sayfa
        public int Count { get; set; }//kayıt sayısı
        public int Pages { get; set; }//Sayfa sayısı
        public IList<T> Items { get; set; }
        public bool HasPrevious => Index > 0;//önceki sayfa var mı
        public bool HasNext => Index+1 > Pages;//sonraki sayfa var mı
    }
}
