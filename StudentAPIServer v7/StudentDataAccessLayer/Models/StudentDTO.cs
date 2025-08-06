using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataAccessLayer.Models {
    public class StudentDTO {

        public StudentDTO(int id, string name, int age, int grade) {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }
    }
}
