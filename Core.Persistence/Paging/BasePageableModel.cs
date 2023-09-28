using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public abstract class BasePageableModel
    {
        public int Size { get; set; }//data sayısı
        public int Index { get; set; }//hangi sayfa
        public int Count { get; set; }//kayıt sayısı
        public int Pages { get; set; }//Sayfa sayısı
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
