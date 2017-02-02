using System.Windows.Forms;

namespace DialogService
{
    public class SelectFolderService : ISelectFolderService
    {
        public string SelectFolder()
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    return dlg.SelectedPath;
                }
            }
            return string.Empty;
        }
    }
}
