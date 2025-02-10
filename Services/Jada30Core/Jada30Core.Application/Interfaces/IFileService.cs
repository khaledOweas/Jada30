using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jada30Core.Application.Interfaces
{
    public interface IFileService
    {
		/// <summary>
		/// This is used for upload files to a destination directory
		/// </summary>
		/// <param name="files"></param>
		/// <param name="subDirectory"></param>
		void UploadFile(List<IFormFile> files, string subDirectory);
		/// <summary>
		/// This is used for upload specified file to a destination directory
		/// </summary>
		/// <param name="files"></param>
		/// <param name="subDirectory"></param>
		Task<string> UploadFile(IFormFile file, string subDirectory);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory);
        string SizeConverter(long bytes);
        void DeleteFile(string filePath);
    }
}
