using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProductManagement2
{
    class UpdateDBlink
    {
        string r;
        ProductManagementDataContext ptx;

        public UpdateDBlink()
        {
            this.ptx = new ProductManagementDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Imran Imo\Desktop\projectimo2\projectimo1\projectimo\Project\ProductManagement2\ProductManagement2\ProdectM.mdf;Integrated Security=True;Connect Timeout=30");
        
        }

        public AdminInfo getAdmin(string x)
        {
            Admin a = new Admin();
            AdminInfo ai = new AdminInfo();
            try
            {
                var str = from u in ptx.Admins
                          where u.user_name == x
                          select u;
                a = str.First();
                ai.UName = a.user_name;
                ai.UFirstName = a.First_Name;
                ai.ULastName = a.Last_name;
                ai.Pword = a.AdminPassword;
                ai.AID = a.AdminId;
                ai.UStatus = a.Status;
            }
            catch 
            {
                ai.UName = null;
            }

            return ai;
        }

        public User getUser(string x)
        {
            CustomerInfo u = new CustomerInfo();
            User ui = new User();
            try
            {
                var str = from a in ptx.CustomerInfos
                          where a.user_name == x
                          select a;
                u = str.First();
                ui.Id = u.id;
                ui.Name = u.user_name;
                ui.FirstName = u.First_name;
                ui.LastName = u.Last_name;
                ui.Password = u.password;
                ui.Email = u.email;
                ui.Address = u.address;
                ui.MobileNo = u.mobile;
                ui.Gender = u.gender;
                ui.Status_ = u.Status;
            }
            catch
            {
                ui.Name = null;
            }

            return ui;
        }


        public string getPassword(string x)
        {
            CustomerInfo u = new CustomerInfo();
            try
            {
                var str = from a in ptx.CustomerInfos
                          where a.user_name == x
                          select a;
                u = str.First();
            }
            catch
            {
                u.password = null;
            }

            return u.password;
        }

       
       

        public int getLatAdminId()
        {
            Admin ax = new Admin();
            int x;

            try
            {
                var str = from a in ptx.Admins
                          select a.AdminId;

                List<int> li = str.ToList();
                x = li.Last();
                
            }
            catch
            {
                x = 0;
            }


            return x;
        }

        public List<object> GetList()
        {
            var x = from a in ptx.ProductInfos
                    join b in ptx.DiscountProducts
                    on a.PId equals b.PPId
                    select new { a.PId, a.Name, a.Quantity, a.SellingPrice, b.New_Price, b.Discount__, a.ProductType, a.Division, a.Districts };

            List<object> o = new List<object>();
            o.AddRange(x.ToList());
            return o;
        }

        public object GetProducts(string n)
        {
            var x = from a in ptx.ProductInfos
                    join b in ptx.DiscountProducts
                    on a.PId equals b.PPId
                    select new { a.PId, a.Name, a.Quantity,a.SellingPrice,b.New_Price,b.Discount__,a.ProductType,a.Division,a.Districts};

            object o = x.ToList();
            return o;
        }



        public string UpdateAdmin(string x, string y, string z)
        {
            try
            {
                Admin t = new Admin();
                var str = from a in ptx.Admins
                          where a.user_name == x
                          select a;
                t = str.First();
                t.user_name = x;
                t.First_Name = y;
                t.Last_name = z;

                ptx.SubmitChanges();
                r = "Successfull";
            }

            catch
            {
                r = "notupdated";
            }

            return r;
        }


        public string UpdateAdminPassword(string x, string y, string z)
        {
            try
            {
                Admin t = new Admin();
                var str = from a in ptx.Admins
                          where a.AdminPassword == x
                          select a;
                t = str.First();
                t.AdminPassword= y;
                ptx.SubmitChanges();
                r = "Successfull";
            }

            catch
            {
                r = "notupdated";
            }

            return r;
        }

        public string UpdateUserPassword(string x, string y, string z)
        {
            try
            {
                CustomerInfo t1 = new CustomerInfo();

                var str = from a in ptx.CustomerInfos
                          where a.password == x
                          select a;
                t1 = str.First();
                t1.password = y;
                ptx.SubmitChanges();
                r = "Successfull";
            }

            catch
            {
                r = "notupdated";
            }

            return r;
        }





        public string UpdateProduct(string x, string y, string z,string b,string c,string d, string m,string n)
        {

            try
            {
                ProductInfo t = new ProductInfo();
                var str = from a in ptx.ProductInfos
                          where a.PId == x
                          select a;
                t = str.First();


                t.Name = y;
                t.ProductType = z;
                t.Quantity = Convert.ToInt32(b);
                t.BuyingPrice = Convert.ToSingle(c);
                t.SellingPrice = Convert.ToSingle(d);
                t.Division = m;
                t.Districts = n;

                ptx.SubmitChanges();
                r = "Successfully product updated";
            }

            catch
            {
                r = "notupdated";
            }

            return r;
        }




        

   }   

}
