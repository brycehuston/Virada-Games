using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virada_Games
{
    [Serializable]
    class Accessories : Product
    {
        private string platformType;

        //Constructor without arguments
        public Accessories()
        {
            platformType = "";
        }

        //Constructor with arguments
        public Accessories(string platformType)
        {
            this.platformType = platformType;
        }

        //Getters
        public string getPlatformType()
        {
            return platformType;
        }

        //Setter
        public void setPlatformType(string platformType)
        {
            this.platformType = platformType;
        }
    }
}
