using System;
using System.Collections.Generic;

namespace WepApiRepository.Model
{
    public partial class Student
    {
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ClassId { get; set; }
        public string? Address { get; set; }

        public virtual Class Class { get; set; } = null!;
    }
}