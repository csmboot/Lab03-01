namespace Lab03_01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ID Không Được Trống")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tiêu Đề Không Được Trống")]
        [StringLength(100, ErrorMessage = "Tiêu Đề Sách Không Được Vượt Quá 100 Ký Tự")]
        public string Tilte { get; set; }

        [Required(ErrorMessage = "Description Không Được Trống")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Tác Giả Không Được Trống")]
        [StringLength(30, ErrorMessage = "Tác Giả Sách Không Được Vượt Quá 30 Ký Tự")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Hình Ảnh Không Được Trống")]
        [StringLength(255)]
        public string Images { get; set; }
        [Required(ErrorMessage = "Giá Bán Không Được Trống")]
        [Range(1000,1000000, ErrorMessage = "Giá Bán Sách Không Được Dưới 1000 ký Tự Và Không Quá 1000000 Ký Tự")]
        public int Price { get; set; }
    }
}
