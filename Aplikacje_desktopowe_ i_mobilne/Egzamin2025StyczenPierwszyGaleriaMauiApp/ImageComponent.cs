using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Egzamin2025StyczenPierwszyGaleriaMauiApp
{
    internal class ImageComponent : BindableObject
    {
        public int Id { get; set; }
        public string Alt { get; set; }
        public string FileName { get; set; }
        public int Category { get; set; }

        private int downloads;
        public int Downloads
        {
            get { return downloads; }
            set { downloads = value; OnPropertyChanged(); }
        }

        public ICommand DownloadCommand { get; set; }
    }
}
