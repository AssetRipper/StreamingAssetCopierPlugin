using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("StreamingAssetCopierPlugin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("StreamingAssetCopierPlugin")]
[assembly: AssemblyCopyright("Copyright ©  2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
[assembly: Guid("5EEC6823-FC07-4E24-84EF-745223CE96D9")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: AssetRipper.Library.Attributes.RegisterPlugin(typeof(StreamingAssetCopierPlugin.StreamingPlugin))]