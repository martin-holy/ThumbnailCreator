# ThumbnailCreator

When I had same code inside my program, everytime I used it, memory consumption went up, but never down after the work was done.
So I decided to call the creation of an thumbnail like external process.

        var process = new Process {
          StartInfo = new ProcessStartInfo {
            Arguments = $"src|\"{origPath}\" dest|\"{newPath}\" quality|\"{80}\" size|\"{size}\"",
            FileName = "ThumbnailCreator.exe",
            UseShellExecute = false,
            CreateNoWindow = true
          }
        };

        process.Start();
        process.WaitForExit(1000);
