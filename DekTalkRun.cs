using System;
using System.Diagnostics;

public class CPHInline
{
    public bool Execute()
    {
        //Collects chat message contents (rawInput) and the path specified by the user (path)
		//and uses them to create and execute a process. Set argument 'path' in separate subaction so user
		//does not need to touch source code.
        String message = args["rawInput"].ToString();
        String sayEXEPath = args["path"].ToString();
		String sayEXEFile = sayEXEPath + @"\say.exe";
        String cParams = "-d dtalk_us.dic -w tmp.wav [:phoneme on] " + message;
        var cmd = new System.Diagnostics.Process();
        cmd.StartInfo.Arguments = cParams;
        cmd.StartInfo.UseShellExecute = false;
		cmd.StartInfo.WorkingDirectory = sayEXEPath;
        cmd.StartInfo.FileName = sayEXEFile;
        cmd.StartInfo.CreateNoWindow = true;
        cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        cmd.Start();
        cmd.WaitForExit();
        return true;
    }
}