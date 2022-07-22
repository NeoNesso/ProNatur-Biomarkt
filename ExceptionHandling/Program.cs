// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string logPath = "log.txt";
string fileName = "test.txt";
string path = "folder/folder2/"; // invalid

try
{
    string finalPath = Path.Combine(path + fileName);
    File.Create(finalPath);
    File.AppendAllText(finalPath, "Hallo Welt");
    File.AppendAllText(logPath, "Log: Successfully created file.\n");

}
catch (IOException ex)
{
    File.AppendAllText(logPath, "Log: File already in use." + ex + "\n");
}
catch (Exception e)
{
    Directory.CreateDirectory(path);
    File.AppendAllText(logPath, "Log: Something went wrong during file creation: Exception: " +e+ "\n");
}

File.AppendAllText(logPath, "Log: Tried to create file.\n");
