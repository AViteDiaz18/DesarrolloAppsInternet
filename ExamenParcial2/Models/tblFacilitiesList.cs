using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamenParcial2.Models
{
    public class tblFacilitiesList
    {
        [Key]
        [Display(Name="ID")]
        public int IngFacilityID {get; set;}
        [StringLength(50, MinimumLength=3)]
        [Display(Name="Descripcion")]
        public string strFacilityDesc {get; set;}
        public ICollection<tblLINK_RoomsFacilities> TblLINK_RoomsFacilities {get; set;}
    }
}