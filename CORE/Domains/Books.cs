using CORE.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DAL
{
    public partial class Books
    {
        public string Image_Path {
            
                get
                {
                  return FilePaths.Book + Image;
                }
        }
    }
}
