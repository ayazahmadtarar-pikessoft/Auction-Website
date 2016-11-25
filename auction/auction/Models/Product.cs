using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace auction.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string status { get; set; }
        public DateTime  Publisheddate { get; set; }
        public string Discription { get; set; }
        public decimal Price { get; set; }


        public int PictureId { get; set; }
        public IEnumerable<HttpPostedFile> Image { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }

        public int categoryid { get; set; }



        [ForeignKey("categoryid")]
        public virtual Category Category { get; set; }

        public int userID { get; set; }

        [ForeignKey("userID")]
        public virtual User User { get; set; }


        public int PA_ID { get; set; }

        [ForeignKey("PA_ID")]
        public virtual Product_Auction Product_Auction { get; set; }


    }
}