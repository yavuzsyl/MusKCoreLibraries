using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireExample.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWaterMarkJob(string fileName, string waterMarkText)
        {
           return Hangfire.BackgroundJob.Schedule(() => ApplyWaterMark(fileName, waterMarkText), TimeSpan.FromSeconds(5));
        }
        public static void ApplyWaterMark(string fileName, string waterMarkText)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\", "images", fileName);

            using (var bitmap = Bitmap.FromFile(path))
            {
                using (var tempBitmap = new Bitmap(bitmap.Width, bitmap.Height))
                {
                    using (var grp = Graphics.FromImage(tempBitmap))
                    {
                        grp.DrawImage(bitmap, 0, 0);

                        var font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
                        var color = Color.FromArgb(255, 0, 0);
                        var brush = new SolidBrush(color);
                        var point = new Point(20, bitmap.Height - 50);

                        grp.DrawString(waterMarkText, font, brush, point);

                        tempBitmap.Save(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\watermark", fileName));
                    }
                }
            }
        }
    }
}
