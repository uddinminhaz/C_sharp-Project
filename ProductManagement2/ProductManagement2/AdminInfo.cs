using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement2
{
   public class AdminInfo
    {
        private string uName;
        private string uFirstName;
        private string uLastName;
        private int aID;
        private string pword;
        private string uStatus;

        public string UName
        {
            set { this.uName = value; }
            get { return this.uName; }
        }
        public string UFirstName
        {
            set { this.uFirstName = value; }
            get { return this.uFirstName; }
        }
        public string ULastName
        {
            set { this.uLastName = value; }
            get { return this.uLastName; }
        }
        public string Pword
        {
            set { this.pword = value; }
            get { return this.pword; }
        }
        public int AID
        {
            set { this.aID = value; }
            get { return this.aID; }
        }
        public string UStatus
        {
            set { this.uStatus = value; }
            get { return this.uStatus; }
        }

    }
}
