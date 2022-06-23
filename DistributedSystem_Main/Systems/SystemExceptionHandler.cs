using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main.Systems
{
    public class SystemExceptionHandler
    {
        public static string saveFolder = Path.Combine(Directory.GetCurrentDirectory(), "System Exception");

        public static void Startup()
        {
            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
            DeleteOldScreenshotImagesAsync(30); 
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(OnThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandleException);

            TaskScheduler.UnobservedTaskException += (o, e) =>
            {
                e.SetObserved();
                HandleException("Sub Thread", e.Exception.InnerException);
            };
        }

        private static async void DeleteOldScreenshotImagesAsync(int dayLimit = 30)
        {
            await Task.Run(() =>
            {
                List<string> imageFileList = Directory.GetFiles(saveFolder, "*", SearchOption.AllDirectories).ToList();

                foreach (string file in imageFileList)
                {
                    if ((DateTime.Now - new FileInfo(file).LastWriteTime).TotalDays > dayLimit)
                        File.Delete(file);
                }
            });
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception exp = e.Exception as Exception;
            HandleException("Sub Thread", exp);
        }
        private static void OnUnhandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exp = e.ExceptionObject as Exception;
            HandleException("Main Thread", exp);
        }

        private static object lockObj = new object();
        public static void HandleException(string source, Exception exp)
        {
            string screenShootImageSavedPath;
            bool screenShootSuccess = TryGetScreenShot(out screenShootImageSavedPath);
            string logPath = Path.Combine(Environment.CurrentDirectory, "Error.log");
            try
            {
                lock (lockObj)
                {
                    using (FileStream FS = new FileStream(logPath,FileMode.Append,FileAccess.Write,FileShare.ReadWrite))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(FS))
                        {
                            string inner = exp.InnerException?.StackTrace;
                            streamWriter.WriteLine($"{DateTime.Now} |{source}|\r\n[Screenshoot Save]:{(!screenShootSuccess ? "Screen Shoot FAIL...No any Image be Saved" : screenShootImageSavedPath)}\r\n[Message]:{exp.Message}\r\n[StackTrace]:{inner}\r\n{exp.StackTrace}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static bool TryGetScreenShot(out string screenShootImageSavedPath)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            string imageFIleName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + "-Exception-Screenshot.png";
            screenShootImageSavedPath = Path.Combine(saveFolder, imageFIleName);
            Directory.CreateDirectory(saveFolder);
            try
            {
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }
                    bitmap.Save(screenShootImageSavedPath, ImageFormat.Png);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

    }
}
