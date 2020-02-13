using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic.Schools;

namespace MoreMagic.Schools
{
    class SchoolTools
    {
        public SchoolTools()
        {
            
        }

        public void Populate()
        {
            Magic.Schools.School.registerSchool(new Life2School());
        }
    }
}
