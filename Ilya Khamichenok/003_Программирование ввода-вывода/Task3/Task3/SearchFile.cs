﻿namespace Task3
{
    public static class SearchFile
    {
        public static string SearchPath(string diskPath, string searchPattern)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(diskPath);

            var files = directoryInfo.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
            var fullNames = files.Select(f => f.FullName);

            return string.Join(Environment.NewLine, fullNames);
        }
    }
}
