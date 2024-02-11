using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Helpers.FileHelper
{
    public class FileManager : IFileHelper
    {
        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string ImagePath = guid + extension;
                string filePath = Path.Combine(root,ImagePath);

                using (FileStream fileStream = File.Create(filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return ImagePath;
                }
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath)) 
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath,string root)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

    }
}
