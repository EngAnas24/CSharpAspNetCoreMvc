using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace ImageTest.Model.Model
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public string Code { get; set; }
    }
}
