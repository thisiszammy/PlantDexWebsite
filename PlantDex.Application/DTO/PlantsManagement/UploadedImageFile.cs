using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace PlantDex.Application.DTO.PlantsManagement
{
    public class UploadedImageFile
    {
        public string fileName { get; set;}
        public sbyte[] fileData { get; set;}
        public byte[] _fileData { get; set; }

        public UploadedImageFile()
        {

        }

        public UploadedImageFile(string filePath)
        {
            this.fileName = Path.GetFileName(Normalize(filePath));
        }

        private string Normalize(string input)
        {
            return new string(input
              .Normalize(System.Text.NormalizationForm.FormD)
              .Replace(" ", string.Empty)
              .ToCharArray()
              .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
              .ToArray());
        }
    }
}
