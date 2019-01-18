﻿using System;
using System.IO;
using Java.IO;
using MnMLilon.Service.Interface;
using MnMLilon.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileManageService))]
namespace MnMLilon.Droid
{
    public class LocalFileManageService: ILocalFileManageService
    {
        public byte[] GetFileDataArray(string fileName)
        {
            var googleDrivePath = "sdcard/Android/data/com.google.android.apps.docs/files/" + fileName;

            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path + "/Download/";
            var fullPath = System.IO.Path.Combine(sdCardPath, fileName);
            if (System.IO.File.Exists(fullPath))
            {
                return GetStreamArray(fullPath);
            }
            else if (System.IO.File.Exists(googleDrivePath))
            {
                return GetStreamArray(googleDrivePath);
            }

            return new MemoryStream().ToArray();
        }

        private static byte[] GetStreamArray(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}