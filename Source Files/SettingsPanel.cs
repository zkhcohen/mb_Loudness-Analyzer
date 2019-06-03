using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicBeePlugin
{
    public partial class SettingsPanel : Form
    {

        // Initialize the configMgr class.
        private ConfigMgr configMgr;

        public string configPath()
        {
            string path = Directory.GetCurrentDirectory() + @"\DRconfig.xml";
            //MessageBox.Show(path);

            return path;

        }


        public SettingsPanel(string path)
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(path);
            configMgr = new ConfigMgr();

            this.FormClosing += new FormClosingEventHandler(SettingsPanel_FormClosing);

            populateLists();
            setDefaultText();
        }


        public List<ComboBox> allCombo = new List<ComboBox>();
        private bool _saved { get; set; }


        // Reads the pre-existing config.xml file and sets the text in each field based on that data.
        private void setDefaultText()
        {

            var deserializedObject = configMgr.DeserializeConfig(configPath());
            
            ILbox.SelectedItem = deserializedObject.ILCP;
            ILTbox.SelectedItem = deserializedObject.ILThresholdCP;
            DRbox.SelectedItem = deserializedObject.LRACP;
            LRTbox.SelectedItem = deserializedObject.LRThresholdCP;
            LRALbox.SelectedItem = deserializedObject.LRALowCP;
            LRAHbox.SelectedItem = deserializedObject.LRAHighCP;
            Pbox.SelectedItem = deserializedObject.PeakCP;
            ALbox.SelectedItem = deserializedObject.AverageCP;
            CLbox.SelectedItem = deserializedObject.CurrentCP;


        }


        private void populateLists()
        {

            allCombo.InsertRange(allCombo.Count, new ComboBox[] { ILbox, ILTbox, DRbox, LRTbox, LRALbox, LRAHbox, Pbox, ALbox, CLbox });

            foreach (ComboBox CB in allCombo)
            {

                CB.Items.Clear();

                CB.Items.Add("None");

                for (int i = 1; i < 17; i++)
                {

                    string NextVal = "Custom" + i;

                    CB.Items.Add(NextVal);


                }

            }

        }


        private bool CheckForDuplicates()
        {

            List<String> selectedItemsList = new List<String>();

            foreach (Control c in Controls)
            {
                
                if (c is ComboBox && ((ComboBox)c).SelectedItem.ToString() != "None")
                {
                    selectedItemsList.Add(((ComboBox)c).SelectedItem.ToString());
                }

            }

            return (selectedItemsList.GroupBy(n => n).Any(c => c.Count() > 1) == true) ?  true : false;
        
        }

        private void saveSettings()
        {

            if (CheckForDuplicates())
            { MessageBox.Show("Please remove duplicate values before saving."); }
            else
            {

                configMgr.ILCP = ILbox.SelectedItem.ToString();
                configMgr.ILThresholdCP = ILTbox.SelectedItem.ToString();
                configMgr.LRACP = DRbox.SelectedItem.ToString();
                configMgr.LRThresholdCP = LRTbox.SelectedItem.ToString();
                configMgr.LRALowCP = LRALbox.SelectedItem.ToString();
                configMgr.LRAHighCP = LRAHbox.SelectedItem.ToString();
                configMgr.PeakCP = Pbox.SelectedItem.ToString();
                configMgr.AverageCP = ALbox.SelectedItem.ToString();
                configMgr.CurrentCP = CLbox.SelectedItem.ToString();

                configMgr.Save(configPath());

            }

        }


        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            _saved = true;
            saveSettings();
                
        }
        

        private void PromptUser()
        {


            DialogResult dr = MessageBox.Show("Do you want to save your settings?",
                      "Save Changes", MessageBoxButtons.YesNo);

            switch (dr)
            {
                case DialogResult.Yes:

                    saveSettings();

                    break;

                case DialogResult.No:

                    _saved = true;

                    break;
            }
            
        }

        
        public void ILTbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void DRbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void Pbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void LRAHbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void LRALbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void LRTbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void ILbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void ALbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }
        public void CLbox_SelectedIndexChanged(object sender, EventArgs e) { _saved = false; }


        public void SettingsPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_saved == false)
            {
                PromptUser();
            }
        }
        
    }
}

