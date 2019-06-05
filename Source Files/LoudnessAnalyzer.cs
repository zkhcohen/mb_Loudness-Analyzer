using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace MusicBeePlugin
{

    public partial class Plugin
    {
        

        private MusicBeeApiInterface mbApiInterface;
        private PluginInfo about = new PluginInfo();

        // Declarations
        //private Control panel;
        //public int panelHeight;
        string [] data = new string[7];
        public string[] files;


        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            mbApiInterface = new MusicBeeApiInterface();
            mbApiInterface.Initialise(apiInterfacePtr);
            about.PluginInfoVersion = PluginInfoVersion;
            about.Name = "mb_Loudness_Analyzer";
            about.Description = "This plugin uses the FFMPEG EBU R128 library to scan and tag loudness data on selected tracks.";
            about.Author = "Zachary Cohen";
            about.TargetApplication = "Loudness Analyzer";   // current only applies to artwork, lyrics or instant messenger name that appears in the provider drop down selector or target Instant Messenger
            about.Type = PluginType.General;
            about.VersionMajor = 1;  // your plugin version
            about.VersionMinor = 3;
            about.Revision = 3;
            about.MinInterfaceVersion = MinInterfaceVersion;
            about.MinApiRevision = MinApiRevision;
            about.ReceiveNotifications = (ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.TagEvents);
            about.ConfigurationPanelHeight = 0;   // height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function

            _workingDirectory = mbApiInterface.Setting_GetPersistentStoragePath() + @"Dependencies\";
            _fileDirectory = mbApiInterface.Setting_GetPersistentStoragePath() + @"Dependencies\LoudnessTextFiles\";


            return about;
        }
        
        public static string _workingDirectory { get; private set; }
        public static string _fileDirectory { get; private set; }
        private ConfigMgr configMgr;

        public int _selectedNum { get; set; }
        public int _checkNum { get; set; }


        // called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        // its up to you to figure out whether anything has changed and needs updating
        public void SaveSettings()
        {
            // save any persistent settings in a sub-folder of this path
            string dataPath = mbApiInterface.Setting_GetPersistentStoragePath();
        }

        // MusicBee is closing the plugin (plugin is being disabled by user or MusicBee is shutting down)
        public void Close(PluginCloseReason reason)
        {
        }

        // uninstall this plugin - clean up any persisted files
        public void Uninstall()
        {
        }
        

        // receive event notifications from MusicBee
        // you need to set about.ReceiveNotificationFlags = PlayerEvents to receive all notifications, and not just the startup event
        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            switch (type)
            {
                
                case NotificationType.PluginStartup:
                    
                    ToolStripMenuItem mainMenuItem = (ToolStripMenuItem)mbApiInterface.MB_AddMenuItem("context.main/EBU R128", null, null);
                    mainMenuItem.DropDown.Items.Add("Tag", null, menu_Click);
                    mainMenuItem.DropDown.Items.Add("Average Selected Files", null, menu2_Click);
                    mainMenuItem.DropDown.Items.Add("Current Loudness of Selected Files", null, menu4_Click);
                    mainMenuItem.DropDown.Items.Add("Settings", null, menu3_Click);


                    break;
                    
            }
        }
        

        private void menu_Click(object sender, System.EventArgs e)
        {

            MessageBox.Show("Tagging selected files...");
            files = null;
            TagFiles();

        }

        private void menu2_Click(object sender, System.EventArgs e)
        {
            files = null;
            AverageFiles();

        }

        // Settings accessed from Context Menu
        private void menu3_Click(object sender, System.EventArgs e)
        {

            SettingsPanel configWindow = new SettingsPanel(_workingDirectory);
            configWindow.ShowDialog();

        }

        // Find current loudness
        private void menu4_Click(object sender, System.EventArgs e)
        {

            GetCurrentLoudness();

        }

        // Configuration
        public bool Configure(IntPtr panelHandle)
        {

            SettingsPanel configWindow = new SettingsPanel(_workingDirectory);
            configWindow.ShowDialog();


            return true;
        }



        // Sets location of Ffmpeg
        public string FfmpegPath()
        {

            string ffmpegPath;

            if (File.Exists(_workingDirectory + @"path.txt"))
            {

                ffmpegPath = File.ReadAllText(_workingDirectory + @"path.txt");

            }
            else
            {

                ffmpegPath = _workingDirectory + "ffmpeg";

            }

            return ffmpegPath;

        }

        public void AnalyzeSong(int currentSong)
        {
            

             System.Diagnostics.Process process = new System.Diagnostics.Process();
             System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
             startInfo.WorkingDirectory = _workingDirectory;
             startInfo.WindowStyle = ProcessWindowStyle.Hidden;
             startInfo.FileName = "cmd.exe";
             startInfo.Arguments = @"/C ffmpeg -i " + @"""" + files[currentSong] + @"""" + " -af ebur128=peak=true -f null - 2>&1 | FINDSTR /BIC:\" \" > " + @"""" + _fileDirectory + CurrentTitle(currentSong) + ".txt" + @"""";
             
             process.StartInfo = startInfo;
             process.EnableRaisingEvents = true;
             process.Start();

             process.Exited += (sender, e) => { ParseValues(currentSong); };
            


        }

        private Dictionary<string, MetaDataType> tagsDictionary = new Dictionary<string, MetaDataType>
        {
            { "Custom1" , MetaDataType.Custom1 },
            { "Custom2" , MetaDataType.Custom2 },
            { "Custom3" , MetaDataType.Custom3 },
            { "Custom4" , MetaDataType.Custom4 },
            { "Custom5" , MetaDataType.Custom5 },
            { "Custom6" , MetaDataType.Custom6 },
            { "Custom7" , MetaDataType.Custom7 },
            { "Custom8" , MetaDataType.Custom8 },
            { "Custom9" , MetaDataType.Custom9 },
            { "Custom10" , MetaDataType.Custom10 },
            { "Custom11" , MetaDataType.Custom11 },
            { "Custom12" , MetaDataType.Custom12 },
            { "Custom13" , MetaDataType.Custom13 },
            { "Custom14" , MetaDataType.Custom14 },
            { "Custom15" , MetaDataType.Custom15 },
            { "Custom16" , MetaDataType.Custom16 }
        };
        

        public void ParseValues(int currentSong)
        {

            configMgr = new ConfigMgr();
            Dictionary<int, string> DeserializedDict = configMgr.DeserializeIntoDict(_workingDirectory + @"\DRconfig.xml", new Dictionary<int, string>());

            int I = 0;

           

            using (var reader = new StreamReader(_fileDirectory + CurrentTitle(currentSong) + ".txt"))
            {


                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.StartsWith("    I:") | line.StartsWith("    Threshold:") | line.StartsWith("    LRA:") | line.StartsWith("    LRA low:") | line.StartsWith("    LRA high:") | line.StartsWith("    Peak:"))
                    {
                        line = Regex.Replace(line, @"[a-zA-Z /\s/g :]", "");
                        data[I] = line;
                        I++;
                    }

                }

                int i = 0;

                foreach (var o in DeserializedDict)
                {

                   
                    string unit = null;

                    //MessageBox.Show("Key: " + o.Key + "\nVal: " + o.Value.ToString());

                    if (o.Value != "None" && o.Key != 7 && o.Key != 8)
                    {

                        if(o.Key == 2) { unit = " LU"; } else if (o.Key == 6) { unit = " dBFS"; } else { unit = " LUFS"; }

                        string temp;
                        MetaDataType tag;
                        DeserializedDict.TryGetValue(i, out temp);
                        tagsDictionary.TryGetValue(temp, out tag);

                        //MessageBox.Show("Temp: " + temp + "\nTag: " + tag + "\nData: " + data[i]);

                        mbApiInterface.Library_SetFileTag(files[currentSong], tag, data[i] + unit);

                        
                    }

                    i += 1;

                }

                

                mbApiInterface.Library_CommitTagsToFile(files[currentSong]);

                mbApiInterface.MB_RefreshPanels();

                
                _checkNum += 1;

                if (_checkNum == _selectedNum)
                {

                    MessageBox.Show("Tagging Complete!");

                }


                //MessageBox.Show(data[0] + "\n" + data[1] + "\n" + data[2] + "\n" + data[3] + "\n" + data[4] + "\n" + data[5]);
                return;
            }
            
        }

        public void AverageFiles()
        {
            double avg = 0;

            string temp, check = null;
            MetaDataType tag;

            configMgr = new ConfigMgr();
            Dictionary<int, string> DeserializedDict = configMgr.DeserializeIntoDict(_workingDirectory + @"\DRconfig.xml", new Dictionary<int, string>());

            DeserializedDict.TryGetValue(7, out check);
            
            
            DeserializedDict.TryGetValue(2, out temp);
            tagsDictionary.TryGetValue(temp, out tag);
            

            if (!mbApiInterface.Library_QueryFilesEx("domain=SelectedFiles", ref files))
            {
                files = new string[0];
            }

            
            if (files.Length == 0)
            {
                MessageBox.Show("No files selected.");
                return;
            }

            for (int i = 0; i < files.Length; i++)
            {
                string taggedVal = mbApiInterface.Library_GetFileTag(files[i], tag);

                try
                {
                    
                    avg += Convert.ToDouble(Regex.Replace(taggedVal, @"[a-zA-Z /\s/g :]", ""));

                }
                catch (System.FormatException e)
                {

                    MessageBox.Show("Please tag all of the files first!");
                    return;

                }
                

            }

            avg = (avg / files.Length);

            if (check == "None")
            {
                MessageBox.Show("[NO TAG CONFIGURED - Files Not Tagged] \n\nAverage DR of selected files: " + Convert.ToString(Math.Round(avg, 2)) + " LU");
                return;
            }

            
            //Write tag to files:
            for (int i = 0; i < files.Length; i++)
            {
                DeserializedDict.TryGetValue(7, out temp);
                tagsDictionary.TryGetValue(temp, out tag);
                
                mbApiInterface.Library_SetFileTag(files[i], tag, Math.Round(avg, 2) + " LU");
                mbApiInterface.Library_CommitTagsToFile(files[i]);
            }

            //MessageBox.Show("Temp: " + temp + "\nTag: " + tag + "\nData: " + data[i]);


            mbApiInterface.MB_RefreshPanels();

            MessageBox.Show("[FILES TAGGED] \n\nAverage DR of selected files: " + Convert.ToString(Math.Round(avg, 2)) + " LU");
            

            return; 
            
        }


        public void GetCurrentLoudness()
        {

            string tempculture = Thread.CurrentThread.CurrentCulture.Name;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            string temp, check = null;
            MetaDataType tag, tag2;

            configMgr = new ConfigMgr();
            Dictionary<int, string> DeserializedDict = configMgr.DeserializeIntoDict(_workingDirectory + @"\DRconfig.xml", new Dictionary<int, string>());

            DeserializedDict.TryGetValue(0, out temp);
            DeserializedDict.TryGetValue(8, out check);


            if ((check == "None") || (temp == "None"))
            {
                MessageBox.Show("Please configure tag in EBU R128 Settings.");
                return;
            }


            
            tagsDictionary.TryGetValue(temp, out tag);
            tagsDictionary.TryGetValue(check, out tag2);


            if (!mbApiInterface.Library_QueryFilesEx("domain=SelectedFiles", ref files))
            {
                files = new string[0];
            }


            if (files.Length == 0)
            {
                MessageBox.Show("No files selected.");
                return;
            }

            for (int i = 0; i < files.Length; i++)
            {
                // Add regex to remove non-numeric characters from tags.
                string taggedVal = Regex.Replace(mbApiInterface.Library_GetFileTag(files[i], tag), @"[a-zA-Z /\s/g :]", "");
                string gainVal = Regex.Replace(mbApiInterface.Library_GetFileProperty(files[i], FilePropertyType.ReplayGainTrack), @"[a-zA-Z /\s/g :]", "");
                
                gainVal = Regex.Replace(gainVal, ",", ".");
            
                //MessageBox.Show("Tagged Value: " + taggedVal + "\nGain Value: " + gainVal);

                try
                {
                    double cur = Convert.ToDouble(taggedVal) + Convert.ToDouble(gainVal);

                    mbApiInterface.Library_SetFileTag(files[i], tag2, Math.Round(cur, 2) + " LUFS");
                    mbApiInterface.Library_CommitTagsToFile(files[i]);

                }
                catch (System.FormatException e)
                {

                    MessageBox.Show("Please tag all of the files first! \n ");
                    return;

                }


            }
            

            mbApiInterface.MB_RefreshPanels();

            MessageBox.Show("Files tagged.");

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(tempculture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(tempculture);

            return;

        }


        private bool TagFiles()
        {

            int i = 0;
            _checkNum = 0;

            if (!mbApiInterface.Library_QueryFilesEx("domain=SelectedFiles", ref files))
            {
                files = new string[0];
            }

            _selectedNum = files.Length;


            if (files.Length == 0)
            {
                MessageBox.Show("No files selected.");
                return false;
            }
            
            for (i = 0; i < files.Length; i++)
            {
                string file = files[i];

                if (!File.Exists(_fileDirectory + CurrentTitle(i) + ".txt"))
                {

                    AnalyzeSong(i);


                }
                else
                {

                    ParseValues(i);
                   // MessageBox.Show("C: " + _checkNum + "\nS: " + _selectedNum);

                }
                
            }
            

            mbApiInterface.MB_RefreshPanels();

            return true;
        }


        public string CurrentTitle(int currentSong)
        {

            //MessageBox.Show("Current Song: " + currentSong);
            //MessageBox.Show("Array Length: " + files.Length);

            var rawTitle = mbApiInterface.Library_GetFileTag(files[currentSong], MetaDataType.TrackTitle) + "-" +
                       mbApiInterface.Library_GetFileTag(files[currentSong], MetaDataType.Artist) + "-" +
                       mbApiInterface.Library_GetFileProperty(files[currentSong], FilePropertyType.Kind) + "-" +
                       mbApiInterface.Library_GetFileProperty(files[currentSong], FilePropertyType.Duration);



            var processedTitle = Regex.Replace(rawTitle, @"[ / : * % ? < > | ! ]", "");
            processedTitle = processedTitle.Replace("\"", "");


            return processedTitle;

        }



    }
    
}


