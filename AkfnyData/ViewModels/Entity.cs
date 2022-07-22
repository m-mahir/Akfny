using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.ViewModels
{
    public class Entity<T> : IEntity<T> where T : struct
    {
        [Key]
        public T Id { get ; set ; }
        public DateTime? CreationDate { get ; set ; }
        public DateTime? ModificationDate { get ; set ; }
    }
}
