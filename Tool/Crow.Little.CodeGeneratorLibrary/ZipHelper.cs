using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
namespace Crow.Little.CodeGeneratorLibrary
{
    using System.IO;
    /// <summary>
    /// Zip文件压缩、解压
    /// </summary>
    public sealed class ZipHelper
    {
        #region AAA
        ///// <summary>
        ///// 解压类型
        ///// </summary>
        //public enum UnzipType
        //{
        //    /// <summary>
        //    /// 解压到当前压缩文件所在的目录
        //    /// </summary>
        //    ToCurrentDirctory,
        //    /// <summary>
        //    /// 解压到与压缩文件名相同的新的目录，如果有多个文件，将为每个文件创建一个目录
        //    /// </summary>
        //    ToNewDirctory
        //}

        ///// <summary>
        ///// 压缩文件,默认目录为当前目录，文件名为当前目录名，压缩级别为6
        ///// </summary>
        ///// <param name="fileOrDirectory">要压缩的文件或文件夹</param>
        //public static void Zip(params string[] fileOrDirectory)
        //{
        //    Zip(6, fileOrDirectory);
        //}

        ///// <summary>
        ///// 压缩文件,默认目录为当前目录，文件名为当前目录名
        ///// </summary>
        ///// <param name="zipLevel">压缩的级别</param>
        ///// <param name="fileOrDirectory">要压缩的文件或文件夹</param>
        //public static void Zip(int zipLevel, params string[] fileOrDirectory)
        //{
        //    if (fileOrDirectory == null)
        //        return;
        //    else if (fileOrDirectory.Length < 1)
        //        return;
        //    else
        //    {
        //        string str = fileOrDirectory[0];
        //        if (str.EndsWith("\\"))
        //            str = str.Substring(0, str.Length - 1);
        //        str += ".zip";
        //        Zip(str, zipLevel, fileOrDirectory);
        //    }
        //}

        ///// <summary>
        ///// 压缩文件,默认目录为当前目录
        ///// </summary>
        ///// <param name="zipedFileName">压缩后的文件</param>
        ///// <param name="zipLevel">压缩的级别</param>
        ///// <param name="fileOrDirectory">要压缩的文件或文件夹</param>
        //public static void Zip(string zipedFileName, int zipLevel, params string[] fileOrDirectory)
        //{
        //    if (fileOrDirectory == null)
        //        return;

        //    else if (fileOrDirectory.Length < 1)
        //        return;

        //    else
        //    {
        //        string str = fileOrDirectory[0];
        //        if (str.EndsWith("\\"))
        //            str = str.Substring(0, str.Length - 1);
        //        str = str.Substring(0, str.LastIndexOf("\\"));
        //        Zip(zipedFileName, str, zipLevel, fileOrDirectory);
        //    }
        //}

        ///// <summary>
        ///// 压缩文件
        ///// </summary>
        ///// <param name="zipedFileName">压缩后的文件</param>
        ///// <param name="zipLevel">压缩的级别</param>
        ///// <param name="currentDirectory">当前所处目录</param>
        ///// <param name="fileOrDirectory">要压缩的文件或文件夹</param>
        //public static void Zip(string zipedFileName, string currentDirectory, int zipLevel, params string[] fileOrDirectory)
        //{
        //    ArrayList AllFiles = new ArrayList();

        //    //获取所有文件
        //    if (fileOrDirectory != null)
        //    {
        //        for (int i = 0; i < fileOrDirectory.Length; i++)
        //        {
        //            if (File.Exists(fileOrDirectory[i]))
        //                AllFiles.Add(fileOrDirectory[i]);
        //            else if (Directory.Exists(fileOrDirectory[i]))
        //                GetDirectoryFile(fileOrDirectory[i], AllFiles);
        //        }
        //    }

        //    if (AllFiles.Count < 1)
        //        return;

        //    ZipOutputStream zipedStream = new ZipOutputStream(File.Create(zipedFileName));
        //    zipedStream.SetLevel(zipLevel);
        //    for (int i = 0; i < AllFiles.Count; i++)
        //    {
        //        string file = AllFiles[i].ToString();
        //        FileStream fs;
        //        //打开要压缩的文件
        //        try
        //        {
        //            fs = File.OpenRead(file);
        //        }
        //        catch
        //        {
        //            continue;
        //        }

        //        try
        //        {
        //            byte[] buffer = new byte[fs.Length];
        //            fs.Read(buffer, 0, buffer.Length);

        //            //新建一个entry
        //            string fileName = file.Replace(currentDirectory, "");
        //            if (fileName.StartsWith("\\"))
        //                fileName = fileName.Substring(1);

        //            ZipEntry entry = new ZipEntry(fileName);
        //            entry.DateTime = DateTime.Now;

        //            //保存到zip流
        //            fs.Close();
        //            zipedStream.PutNextEntry(entry);
        //            zipedStream.Write(buffer, 0, buffer.Length);
        //        }
        //        catch
        //        {
        //        }
        //        finally
        //        {
        //            fs.Close();
        //            fs.Dispose();
        //        }
        //    }

        //    zipedStream.Finish();
        //    zipedStream.Close();
        //}

        ///// <summary>
        ///// 压缩文件夹
        ///// </summary>
        ///// <param name="curretnDirectory">当前所在的文件夹</param>
        //public static void ZipDirectory(string curretnDirectory)
        //{
        //    if (curretnDirectory == null)
        //        return;

        //    string dir = curretnDirectory;
        //    if (dir.EndsWith("\\"))
        //        dir = dir.Substring(0, dir.Length - 1);

        //    string file = dir.Substring(dir.LastIndexOf("\\") + 1) + ".zip";
        //    dir += "\\" + file;

        //    Zip(dir, 6, curretnDirectory);
        //}

        ///// <summary>
        ///// 压缩文件夹
        ///// </summary>
        ///// <param name="curretnDirectory">当前所在的文件夹</param>
        //public static void ZipDirectory(string curretnDirectory, int zipLevel)
        //{
        //    if (curretnDirectory == null)
        //        return;

        //    string dir = curretnDirectory;
        //    if (dir.EndsWith("\\"))
        //        dir = dir.Substring(0, dir.Length - 1);
        //    dir += ".zip";

        //    Zip(dir, zipLevel, curretnDirectory);
        //}

        ///// <summary>
        ///// 递归获取一个目录下的所有文件
        ///// </summary>
        ///// <param name="parentDirectory"></param>
        ///// <param name="toStore"></param>
        //private static void GetDirectoryFile(string parentDirectory, ArrayList toStore)
        //{
        //    string[] files = Directory.GetFiles(parentDirectory);
        //    for (int i = 0; i < files.Length; i++)
        //        toStore.Add(files[i]);

        //    string[] directorys = Directory.GetDirectories(parentDirectory);
        //    for (int i = 0; i < directorys.Length; i++)
        //        GetDirectoryFile(directorys[i], toStore);
        //}

        ///// <summary>
        ///// 解压文件
        ///// <param name="type">解压类型</param>
        ///// <param name="zipFile">要解压的文件</param>
        //public static void UnZip(UnzipType type, params string[] zipFile)
        //{
        //    ZipInputStream zipStream;
        //    ZipEntry entry;

        //    for (int i = 0; i < zipFile.Length; i++)
        //    {
        //        zipStream = new ZipInputStream(File.OpenRead(zipFile[i]));

        //        //获取目录名,并创建该目录
        //        string directoryName = "";
        //        if (type == UnzipType.ToNewDirctory)
        //            directoryName = zipFile[i].Substring(0, zipFile[i].LastIndexOf("."));
        //        else
        //            directoryName = zipFile[i].Substring(0, zipFile[i].LastIndexOf("\\"));

        //        if (!Directory.Exists(directoryName))
        //            Directory.CreateDirectory(directoryName);

        //        //读出每一个文件
        //        while ((entry = zipStream.GetNextEntry()) != null)
        //        {
        //            if (entry.Name.EndsWith("/"))
        //            {
        //                string folderName = entry.Name.Remove(entry.Name.Length - 1);
        //                string dirPath = Path.Combine(directoryName, folderName);
        //                if (!Directory.Exists(dirPath))
        //                    Directory.CreateDirectory(dirPath);
        //                continue;
        //            }

        //            //获取文件名
        //            string fileName = entry.Name;
        //            if (directoryName.EndsWith("\\"))
        //                fileName = directoryName + fileName;
        //            else
        //                fileName = directoryName + "\\" + fileName;
        //            if (fileName == String.Empty)
        //                continue;

        //            //创建一个文件
        //            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
        //                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
        //            FileStream streamWriter = File.Create(fileName);

        //            //写入文件
        //            int size = 2048;
        //            byte[] data = new byte[2048];
        //            while (true)
        //            {
        //                size = zipStream.Read(data, 0, data.Length);
        //                if (size > 0)
        //                {
        //                    streamWriter.Write(data, 0, size);
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //            }
        //            streamWriter.Close();
        //        }
        //        zipStream.Close();
        //    }
        //}

        ///// <summary>
        ///// 解压文件
        ///// <param name="zipFile">要解压的文件,默认解压到新文件夹,每个文件对应生成一个文件夹</param>
        //public static void UnZip(params string[] zipFile)
        //{
        //    UnZip(UnzipType.ToNewDirctory, zipFile);
        //}
        #endregion

        #region 加压解压方法
        /// <summary>
        /// 功能：压缩文件（暂时只压缩文件夹下一级目录中的文件，文件夹及其子级被忽略）
        /// </summary>
        /// <param name="dirPath">被压缩的文件夹夹路径</param>
        /// <param name="zipFilePath">生成压缩文件的路径，为空则默认与被压缩文件夹同一级目录，名称为：文件夹名+.zip</param>
        /// <param name="err">出错信息</param>
        /// <returns>是否压缩成功</returns>
        public static bool ZipFile(string dirPath, string zipFilePath, out string err)
        {
            err = "";
            if (dirPath == string.Empty)
            {
                err = "要压缩的文件夹不能为空！";
                return false;
            }
            if (!Directory.Exists(dirPath))
            {
                err = "要压缩的文件夹不存在！";
                return false;
            }
            //压缩文件名为空时使用文件夹名＋.zip
            if (zipFilePath == string.Empty)
            {
                if (dirPath.EndsWith("\\"))
                {
                    dirPath = dirPath.Substring(0, dirPath.Length - 1);
                }
                zipFilePath = dirPath + ".zip";
            }

            try
            {
                string[] filenames = Directory.GetFiles(dirPath);
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    s.SetLevel(9);
                    byte[] buffer = new byte[4096];
                    foreach (string file in filenames)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 功能：解压zip格式的文件。
        /// </summary>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="unZipDir">解压文件存放路径,为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹</param>
        /// <param name="err">出错信息</param>
        /// <returns>解压是否成功</returns>
        public static bool UnZipFile(string zipFilePath, string unZipDir, out string err)
        {
            err = "";
            if (zipFilePath == string.Empty)
            {
                err = "压缩文件不能为空！";
                return false;
            }
            if (!File.Exists(zipFilePath))
            {
                err = "压缩文件不存在！";
                return false;
            }
            //解压文件夹为空时默认与压缩文件同一级目录下，跟压缩文件同名的文件夹
            if (unZipDir == string.Empty)
                unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            if (!unZipDir.EndsWith("\\"))
                unZipDir += "\\";
            if (!Directory.Exists(unZipDir))
                Directory.CreateDirectory(unZipDir);

            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
                {

                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(unZipDir + directoryName);
                        }
                        if (!directoryName.EndsWith("\\"))
                            directoryName += "\\";
                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(unZipDir + theEntry.Name))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }//while
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }//解压结束
        #endregion
    }
}