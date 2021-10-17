using AssetRipper.Library;
using System.IO;
using System.Linq;

namespace StreamingAssetCopierPlugin
{
	internal class StreamingPlugin : PluginBase
	{
		public static readonly string[] SupportedFileExtensions = new string[] { ".png", ".jpg", ".mp3", ".ogg", ".wav", ".mp4" };
		public const string OutputFolderName = "StreamingAssetsCopied";

		public override string Name => "StreamingCopier";

		public override void Initialize()
		{
			CurrentRipper.OnFinishExporting += new System.Action(DoPostExport);
		}

		private void DoPostExport()
		{
			Info($"Copying compatible streaming assets");
			string streamingAssetsPath = CurrentRipper.GameStructure?.PlatformStructure?.StreamingAssetsPath;
			string exportPath = CurrentRipper.Settings.ExportPath;
			if (string.IsNullOrEmpty(streamingAssetsPath) || string.IsNullOrEmpty(exportPath) || !Directory.Exists(streamingAssetsPath))
				return;

			string[] streamingFiles = Directory.GetFiles(streamingAssetsPath, "*", SearchOption.AllDirectories).Where(path => HasCompatibleExtension(path)).ToArray();
			if (streamingFiles.Length == 0)
				return;

			Info($"Found {streamingFiles.Length} compatible files to copy");
			string outputPath = Path.Combine(exportPath, OutputFolderName);
			foreach(string file in streamingFiles)
			{
				string relativePath = Path.GetRelativePath(streamingAssetsPath, file);
				string newPath = Path.Combine(outputPath, relativePath);
				string newDirectory = Path.GetDirectoryName(newPath);
				Info($"Copying to {newPath}");
				Directory.CreateDirectory(newDirectory);
				File.Copy(file, newPath);
			}
		}

		private static bool HasCompatibleExtension(string path)
		{
			if (string.IsNullOrEmpty(path))
				return false;
			foreach(var extension in SupportedFileExtensions)
			{
				if (path.EndsWith(extension))
					return true;
			}
			return false;
		}
	}
}
