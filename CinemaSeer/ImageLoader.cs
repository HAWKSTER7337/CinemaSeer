using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CinemaSeer;

public class ImageLoader : IDisposable
{
    private struct TaskAndFileInfo
    {
        public string JpegFilePath;
        public Process GallaryProcess;
    }
    
    private List<TaskAndFileInfo> allCreatedJpegFiles = new();
    
    public void LoadImageInGallary(byte[] imageData)
    {
        var tempFilePath = SaveImageToTemporaryFile(imageData);
        var filePathAndFileInfo = OpenImageInDefaultViewer(tempFilePath);
        allCreatedJpegFiles.Add(filePathAndFileInfo);
        Console.WriteLine($"File {filePathAndFileInfo.JpegFilePath} is in the terminated items");
    }

    public void RemoveAllCreatedJpegFiles()
    {
        foreach (var file in allCreatedJpegFiles)
        {
            file.GallaryProcess.CloseMainWindow();
            File.Delete(file.JpegFilePath);
        }
        allCreatedJpegFiles.Clear();
        Console.WriteLine("All Images have been deleted and removed from the list");
    }

    private static string SaveImageToTemporaryFile(byte[] imageData)
    {
        var tempFileName = Path.GetTempFileName();
        var tempFilePath = Path.ChangeExtension(tempFileName, "jpg");

        File.WriteAllBytes(tempFilePath, imageData);
        Console.WriteLine($"Image saved to temporary file: {tempFilePath}");
        return tempFilePath;
    }

    private static TaskAndFileInfo OpenImageInDefaultViewer(string filePath)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            }
        };
        process.Start();
        
        var taskAndFileInfo = new TaskAndFileInfo();
        taskAndFileInfo.JpegFilePath = filePath;
        taskAndFileInfo.GallaryProcess = process;
        return taskAndFileInfo;
    }

    public void Dispose()
    {
        RemoveAllCreatedJpegFiles();
    }
}