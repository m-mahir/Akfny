using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
   public interface IEntity <TId>
    {
        TId Id { get; set; }
       // TId CreatedBy { get; set; }
        DateTime? CreationDate { get; set; }
      //  TId? ModifiedBy { get; set; }
        DateTime? ModificationDate { get; set; }
    }
}
