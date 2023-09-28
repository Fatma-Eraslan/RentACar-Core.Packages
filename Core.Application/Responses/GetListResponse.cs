using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Responses
{
    public class GetListResponse<T>: BasePageableModel
    {
        private IList<T> _item;

        public IList<T> Item 
        { 
            get => _item??=new List<T>();//itemler yoksa list oluştur
            set => _item = value; 
        }
    }
}
