using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class Blog
    {

        [Key]
        
        public int id { get; set; }


        [Required(ErrorMessage ="Enter Blog Content")]
        [Display(Name = "Blog Content")]
        public string blog_content { get; set; }


        [Required(ErrorMessage = "Enter Title")]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Image URL")]
        public string image { get; set; }





    }
}
