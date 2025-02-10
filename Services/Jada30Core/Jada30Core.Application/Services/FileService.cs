using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServiceStack;
using ServiceStack.Script;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jada30Core.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Identity.Application.Services
{
    public class FileService : IFileService
    {
        #region Property
        private IWebHostEnvironment _hostingEnvironment;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public FileService(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            Configuration = configuration;
        }
        #endregion

        #region Upload File
        public void UploadFile(List<IFormFile> files, string subDirectory)
        {
            string target = Configuration.GetValue<string>("SubDirectory")!;
            //var target = Path.Combine(_hostingEnvironment.ContentRootPath, directory);
            target = $"{target}\\{subDirectory}";
            if (!Directory.Exists(target))
                Directory.CreateDirectory(target);

                files.ForEach(async file =>
            {
                if (file.Length <= 0) return;

				string newFileName = CheckIfFileExist(target, file.FileName);
				using (var stream = new FileStream(Path.Combine(target, newFileName), FileMode.Create, FileAccess.ReadWrite))
                {
                    await file.CopyToAsync(stream);
                }
            });
        }

		public async Task<string> UploadFile(IFormFile file, string subDirectory)
		{
			string newFileName = string.Empty;
			string target = Configuration.GetValue<string>("SubDirectory")!;
			//var target = Path.Combine(_hostingEnvironment.ContentRootPath, directory);
			target = $"{target}\\{subDirectory}";
			if (!Directory.Exists(target))
				Directory.CreateDirectory(target);

			if (file.Length <= 0) return "";

			newFileName = CheckIfFileExist(target, file.FileName);
			using (var stream = new FileStream(Path.Combine(target, newFileName), FileMode.Create, FileAccess.ReadWrite))
			{
				await file.CopyToAsync(stream);
			}
			return newFileName;
		}
		#endregion

		#region Download File
		public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(File.ReadAllText(file));
                        }

                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }

        }
        #endregion

        #region Size Converter
        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
		#endregion

		#region Delete File
		public void DeleteFile(string filePath)
		{
			string target = Configuration.GetValue<string>("SubDirectory")!;
			target = $"{target}\\{filePath}";
			if (File.Exists(target))
				File.Delete(target);
		}
		#endregion

		#region Check If File Exist
		private string CheckIfFileExist(string target, string fileName)
		{
            Guid guid = Guid.NewGuid();
            string extension = Path.GetExtension(fileName);
            string newfilename = guid + extension;
			string filePath = Path.Combine(target, newfilename);
			while (File.Exists(filePath))
            {
				guid = Guid.NewGuid();
				newfilename = guid + extension;
				filePath = Path.Combine(target, newfilename);
			}
			return newfilename;
		}
		#endregion
	}
}
