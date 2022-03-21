using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.WebApp.Store
{
    public abstract record RootState
    {    
        public bool IsLoading { get; init; }

        public string CurrentErrorMessage { get; init; }

        public bool HasCurrentErrors => !string.IsNullOrWhiteSpace(CurrentErrorMessage);
    }
}
