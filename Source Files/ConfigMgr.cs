using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace MusicBeePlugin
{


    [Serializable()]
    public class ConfigMgr
    {

        public String ILCP { get; set; }
        public String ILThresholdCP { get; set; }
        public String LRACP { get; set; }
        public String LRThresholdCP { get; set; }
        public String LRALowCP { get; set; }
        public String LRAHighCP { get; set; }
        public String PeakCP { get; set; }
        public String AverageCP { get; set; }
        public String CurrentCP { get; set; }


        public bool Save(string path)
        {
            ConfigMgr.SerializeConfig(this, path);

            MessageBox.Show("Settings Saved.");

            return true;
        }


        public static void SerializeConfig(ConfigMgr data, string path)
        {

            using (StreamWriter file = new StreamWriter(path, false))
            {
                XmlSerializer controlsDefaultsSerializer = new XmlSerializer(typeof(ConfigMgr));
                controlsDefaultsSerializer.Serialize(file, data);
                file.Close();
            }

        }


        public ConfigMgr DeserializeConfig(string path)
        {

            try
            {
                StreamReader file = new StreamReader(path);
                XmlSerializer xSerial = new XmlSerializer(typeof(ConfigMgr));
                object oData = xSerial.Deserialize(file);
                var thisConfig = (ConfigMgr)oData;
                file.Close();
                return thisConfig;
            }
            catch (Exception e)
            {

                Console.Write(e.Message);
                return null;
            }

        }




        public Dictionary<int, string> DeserializeIntoDict(string path, Dictionary<int, string> DeserializedDict)
        {
            
            var deserializedObject = DeserializeConfig(path);
            
            DeserializedDict.Add(0, deserializedObject.ILCP);
            DeserializedDict.Add(1, deserializedObject.ILThresholdCP);
            DeserializedDict.Add(2, deserializedObject.LRACP);
            DeserializedDict.Add(3, deserializedObject.LRAHighCP);
            DeserializedDict.Add(4, deserializedObject.LRALowCP);
            DeserializedDict.Add(5, deserializedObject.LRThresholdCP);
            DeserializedDict.Add(6, deserializedObject.PeakCP);
            DeserializedDict.Add(7, deserializedObject.AverageCP);
            DeserializedDict.Add(8, deserializedObject.CurrentCP);

            return DeserializedDict;
            
        }

    }


}