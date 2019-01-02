using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Email { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModify { get; set; }

        public List<Checkouts> Checkouts { get; set; }
    }
}
