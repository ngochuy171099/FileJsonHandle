using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHanderJson.Entity
{
    class Student
    {
        private int _id;
        private string _name;
        private string _email;
        private string _phone;
        

        public int id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string email { get => _email; set => _email = value; }
        public string phone { get => _phone; set => _phone = value; }
    }
}
