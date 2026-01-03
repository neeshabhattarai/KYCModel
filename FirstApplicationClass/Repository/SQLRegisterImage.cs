using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Repository.Interface;
using FirstApplicationClass.Service;

namespace FirstApplicationClass.Repository
{
    public class SQLRegisterImage:IImage
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly IWebHostEnvironment env;
        private readonly ApplicationDbContext context;

        public SQLRegisterImage(IHttpContextAccessor httpContext,IWebHostEnvironment env,ApplicationDbContext context)
        {
            this.httpContext = httpContext;
            this.env = env;
            this.context = context;
        }

        public async Task<RegisterImage> Upload(RegisterImage registerImage)
        {
            var fileName = $"{Guid.NewGuid().ToString()}-{registerImage.file.FileName}";
           var PathHolder=Path.Combine(env.ContentRootPath,"Images",fileName);

            using var stream = new FileStream(PathHolder, FileMode.Create);
            registerImage.file.CopyToAsync(stream);
            var urlPath = $"{httpContext.HttpContext.Request.Scheme}://{httpContext.HttpContext.Request.Host}{httpContext.HttpContext.Request.PathBase}/Images/{fileName}";
            registerImage.FilePath= urlPath;
            registerImage.FileName= urlPath;
            await context.RegisterImages.AddAsync(registerImage);
            await context.SaveChangesAsync();
            return registerImage;

        }
    }
}
