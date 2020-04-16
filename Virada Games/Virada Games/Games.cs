using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virada_Games
{
    [Serializable]
    class Games : Product
    {
        private string publisher;
        private string mediaType;

        //Constructor without arguments
        public Games()
        {
            publisher = "";
            mediaType = "";
        }

        //Constructor with arguments
        public Games(string publisher, string mediaType)
        {
            this.publisher = publisher;
            this.mediaType = mediaType;
        }

        //Getters
        public string getPublisher()
        {
            return publisher;
        }

        public string getMediaType()
        {
            return mediaType;
        }

        //Setters
        public void setPublisher(string publisher)
        {
            this.publisher = publisher;
        }

        public void setMediaType(string mediaType)
        {
            this.mediaType = mediaType;
        }
    }
}
