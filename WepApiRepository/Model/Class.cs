using System;
using System.Collections.Generic;

namespace WepApiRepository.Model
{
    public partial class Class
    {
        public Class()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}
