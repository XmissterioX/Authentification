using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product: IEntity
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }
    }
}