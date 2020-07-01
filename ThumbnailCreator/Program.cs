using System;
using System.Collections.Generic;
using System.IO;

namespace ThumbnailCreator {
  class Program {
    static void Main(string[] args) {
      //src|"d:\!test\20150831_114319_Martin.jpg" dest|"d:\!test\20150831_114319_Martin_thumb.jpg" quality|80 size|400 rotationAngle|0
      try {
        var arguments = new Dictionary<string, string>();

        foreach (string argument in args) {
          string[] splitted = argument.Split('|');

          if (splitted.Length == 2) {
            arguments[splitted[0]] = splitted[1];
          }
        }

        int size = int.Parse(arguments["size"]);
        string srcPath = arguments["src"];
        string destPath = arguments["dest"];
        long quality = long.Parse(arguments["quality"]);
        int rotationAngle = int.Parse(arguments["rotationAngle"]);

        if (!File.Exists(srcPath)) return;

        string dir = Path.GetDirectoryName(destPath);
        if (dir == null) return;

        Directory.CreateDirectory(dir);

        try {
          var thumb = new ShellThumbnail();
          thumb.CreateThumbnail(srcPath, destPath, size, quality, rotationAngle);
          thumb.Dispose();
        } catch (Exception) {
          //file can have 0 size
        }
      }
      catch (Exception) {
        // ignored
      }
    }
  }
}
