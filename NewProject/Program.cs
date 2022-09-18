using System.IO;

if (args.Length == 0)
{
    System.Console.WriteLine("project name is required.");
    return;
}

var projectName = args[0];

Directory.CreateDirectory(projectName);

foreach (var file in Directory.EnumerateFiles("NewProject/template", "*.t", SearchOption.AllDirectories))
{
    var src = file;
    var dest = Path.GetFileName(src);
    // 末尾の.tを除去
    dest = dest.Substring(0, dest.Length - 2);
    dest = dest.Replace("{{name}}", projectName);
    dest = Path.Combine(projectName, dest);
    System.Console.WriteLine($"{src} {dest}");
    File.Copy(src, dest);
}
