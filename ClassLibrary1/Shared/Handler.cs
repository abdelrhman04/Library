using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Shared
{
    public  static class Handler
    {
        public static string Upload<T>(this T Images,IFormFile file, Enums ddd, string path = null)
        {
            try
            {
               

                if (file.Length > 0)
                {

                    string BinaryPath = Guid.NewGuid().ToString() + file.FileName;

                    FileStream fs = new FileStream(
                      Path.Combine(Directory.GetCurrentDirectory(),
                      "wwwroot", "Image",ddd.ToString(), BinaryPath)
                      , FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    if (!string.IsNullOrEmpty(path))
                    {
                            FileInfo delete = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot", "Image", ddd.ToString(), path));
                            delete.Delete();
                    }
                    file.CopyTo(fs);
                    fs.Position = 0;
                    fs.Close();
                    return BinaryPath;
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                throw;
                // StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
