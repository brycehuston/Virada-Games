using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virada_Games
{
    [Serializable]
    class Customers : Product
    {
        private string custID;
        private string familyName;
        private string firstName;
        private string emailAddress;

        //Constructor without arguements
        public Customers()
        {
            custID = "";
            familyName = "";
            firstName = "";
            emailAddress = "";
        }

        //Constructor with arguements
        public Customers(string custID, string familyName, string firstName, string emailAddress)
        {
            this.custID = custID;
            this.familyName = familyName;
            this.firstName = firstName;
            this.emailAddress = emailAddress;
        }

        //Getters
        public string getCustID()
        {
            return custID;
        }

        public string getFamilyName()
        {
            return familyName;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getEmailAddress()
        {
            return emailAddress;
        }

        //Setters
        public void setCustID(string custID)
        {
            this.custID = custID;
        }

        public void setFamilyName(string familyName)
        {
            this.familyName = familyName;
        }

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void setEmailAddress(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public override string ToString()
        {
            return getCustID() + " " + getFamilyName() + " " + getFirstName();
        }
    }
}
