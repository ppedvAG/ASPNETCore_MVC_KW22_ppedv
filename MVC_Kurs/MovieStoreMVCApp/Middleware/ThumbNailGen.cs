

using System.Drawing;

namespace MovieStoreMVCApp.Middleware
{
    public class ThumbNailGen
    {
        private readonly RequestDelegate _next;

        public ThumbNailGen(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string img = httpContext.Request.Query["img"][0];

            var pfad = AppDomain.CurrentDomain.GetData("RootVerzeichnis") + @"\images\" + img;

            if (!File.Exists(pfad))
                pfad = AppDomain.CurrentDomain.GetData("RootVerzeichnis") + @"\images\" + "Default.jpg";

            using (var sr = new FileStream(pfad, FileMode.Open))
            {
                //Bitmap ist von -> using System.Drawing;
                using (var image = new Bitmap(sr))
                {
                    // Wie groß soll konventiertes Bild sein
                    var resized = new Bitmap(100, 100);

                    using (var graphics = Graphics.FromImage(resized))
                    {
                        graphics.DrawImage(image, 0, 0, 100, 100);
                        var ms = new MemoryStream();

                        resized.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                        await httpContext.Response.Body.WriteAsync(ms.ToArray());
                    }
                }
            }
            //return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ThumbNailGenExtensions
    {
        public static IApplicationBuilder UseThumbNailGen(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ThumbNailGen>();
        }
    }
}
