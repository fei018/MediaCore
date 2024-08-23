using MediaCore.ViewModel.LocalMediaScan;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace MediaCore
{
    public class StartupTask
    {
        public static void AddMore(ref IServiceCollection services)
        {
            // http response html 拉丁中文不编码
            services.AddSingleton(HtmlEncoder.Create([UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs]));

            services.AddScoped<LocalMediaScanner>();
        }
    }
}
