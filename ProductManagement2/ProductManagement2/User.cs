using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement2
{
   public class User
    {
        private string user_name;
        private string First_name;
        private string Last_name;
        private string password;
        private string email;
        private string mobileNo;
        private string dateOfBirth;
        private string gender;
        private string address;
        private string Status;
        private int id;


        public User()
        {

        }

        public User(string user_name, string First_name, string Last_name, string password, string email,
            string mobileNo, string dateOfBirth, string gender, string address,string Status,int id)
        {
            this.user_name = user_name;
            this.First_name = First_name;
            this.Last_name = Last_name;
            this.password = password;
            this.email = email;
            this.mobileNo = mobileNo;
            this.gender = gender;
            this.address = address;
            this.Status = Status;
            this.id = id;
        }

        


        public string Name
        {
            set { this.user_name = value; }
            get { return this.user_name; }
        }
        public int Id
        {
            set { this.id = value; }
            get { return this.id; }
        }
        public string FirstName
        {
            set { this.First_name = value; }
            get { return this.First_name; }
        }
        public string LastName
        {
            set { this.Last_name = value; }
            get { return this.Last_name; }
        }

        public string Password
        {
            set { this.password = value; }
            get { return this.password; }
        }

        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }

        public string MobileNo
        {
            set { this.mobileNo = value; }
            get { return this.mobileNo; }
        }

        public string DateOfBirth
        {
            set { this.dateOfBirth = value; }
            get { return this.dateOfBirth; }
        }

        public string Gender
        {
            set { this.gender = value; }
            get { return this.gender; }
        }

        public string Address
        {
            set { this.address = value; }
            get { return this.address; }
        }

        public string Status_
        {
            set { this.Status = value; }
            get { return this.Status; }
        }



    }
}
