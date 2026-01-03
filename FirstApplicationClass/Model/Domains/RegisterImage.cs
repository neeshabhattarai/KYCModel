using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApplicationClass.Model.Domains
{
    public class RegisterImage
    {
        public string Id {get;set;}
        [NotMapped]
        public IFormFile file { get; set; }

        public string FileName { get; set;}

        public string FilePath { get; set;}

        public long FileSize { get; set;}

        public string FileExtensions { get; set;}

    }
}
