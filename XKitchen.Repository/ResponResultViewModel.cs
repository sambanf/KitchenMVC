using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XKitchen.Repository
{
    public class ResponResultViewModel
    {
        public ResponResultViewModel()
        {
            Success = true;
            Message = "No Message";
        }
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Entity { get; set; }
    }
}
