using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArticles.Core
{
    public class Author
    {
        [Display(Name = "المعرف")]
        public int Id { get; set; }
        [Display(Name = "معرف المستخدم")]
        public string UserId { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }
        [Display(Name = "الصورة")]
        public string ProfileImageUrl { get; set; }
        [Display(Name = "السيرة الذاتية")]
        public string Bio { get; set; }
        [Display(Name = "فيسبوك")]
        public string Facbook { get; set; }
        [Display(Name = "انستكرام")]
        public string Instagram { get; set; }
        [Display(Name = "تويتر")]
        public string Twitter { get; set; }

        // Navigation
        public virtual List<AuthorPost> AuthorPosts { get; set; }

    }
}
