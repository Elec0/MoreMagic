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
            School.registerSchool(new Life2School());
            School.registerSchool(new TransmutationSchool());
        }
    }
}
